const string underDevelopment = "CorsPolicyDevelopment";
const string underStagingOrProduction = "CorsPolicy";

var appBuilder = WebApplication.CreateBuilder(args);
appBuilder.Host.UseSerilog((_, configuration) => configuration.ReadFrom.Configuration(appBuilder.Configuration));
appBuilder.Services.AddCors(options =>
{
    options.AddPolicy(underStagingOrProduction, builder => builder
            .WithOrigins("https://qwirkle.newtomsoft.fr", "http://qwirkle.newtomsoft.fr", "https://qwirkleapi.newtomsoft.fr", "http://qwirkleapi.newtomsoft.fr", "https://localhost", "http://localhost", "https://localhost:4200", "http://localhost:4200", "http://localhost:5000", "https://localhost:5001")
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
    options.AddPolicy(underDevelopment, builder => builder
            .WithOrigins("http://localhost:4200", "http://localhost:5000", "https://localhost:5001")
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});
appBuilder.Services.AddSignalR();
appBuilder.Services.AddSingleton<INotification, SignalRNotification>();
appBuilder.Services.AddScoped<IRepository, Repository>();
appBuilder.Services.AddScoped<IAuthentication, Authentication>();
appBuilder.Services.AddScoped<AuthenticationUseCase>();
appBuilder.Services.AddScoped<CoreUseCase>();
appBuilder.Services.AddScoped<InfoUseCase>();
appBuilder.Services.AddScoped<BotUseCase>();
appBuilder.Services.AddScoped<ComputePointsUseCase>();
appBuilder.Services.AddScoped<IArtificialIntelligence, ArtificialIntelligence>();
appBuilder.Services.AddControllers();
appBuilder.Services.AddDbContext<DefaultDbContext>(options => options.UseSqlServer(appBuilder.Configuration.GetConnectionString("Qwirkle")));
appBuilder.Services.AddIdentity<UserDao, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 2;
    options.User.RequireUniqueEmail = true;
})
  .AddRoleManager<RoleManager<IdentityRole<int>>>()
  .AddEntityFrameworkStores<DefaultDbContext>()
  .AddDefaultTokenProviders()
  .AddDefaultUI();
appBuilder.Services.AddOptions();
appBuilder.Services.ConfigureApplicationCookie(options => options.LoginPath = "");
appBuilder.Services.AddSession();

var app = appBuilder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(app.Environment.IsDevelopment() ? underDevelopment : underStagingOrProduction);
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<HubQwirkle>("/hubGame");
});

app.Run();