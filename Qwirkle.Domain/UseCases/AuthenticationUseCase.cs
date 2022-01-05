﻿namespace Qwirkle.Domain.UseCases;

public class AuthenticationUseCase
{
    private readonly IAuthentication _authentication;

    public AuthenticationUseCase(IAuthentication authentication) => _authentication = authentication;

    public async Task CreateBots() => await _authentication.CreateBotsAsync();


    public async Task<bool> Register(User user, string password) => await _authentication.RegisterAsync(user, password);
    public async Task<bool> RegisterGuest() => await _authentication.RegisterGuestAsync();

    [Obsolete]
    public int GetUserId(object user) => _authentication.GetUserId(user);

    public async Task LogOutAsync() => await _authentication.LogoutOutAsync();

    public async Task<bool> LoginAsync(string pseudo, string password, bool isRemember) => await _authentication.LoginAsync(pseudo, password, isRemember);
}