﻿namespace Qwirkle.Web.Ai.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    private readonly InfoService _infoService;

    public AdminController(InfoService infoService) => _infoService = infoService;


    [HttpGet("Player/{playerId:int}")]
    public ActionResult GetPlayerById(int playerId) => new ObjectResult(_infoService.GetPlayer(playerId));


    [HttpGet("AllUsersIds")]
    public ActionResult GetAllUsersId() => new ObjectResult(_infoService.GetAllUsersId());


    [HttpGet("GamesByUserId/{userId:int}")]
    public ActionResult GetGamesByUserId(int userId) => new ObjectResult(_infoService.GetUserGames(userId));


    [HttpGet("GamesIds")]
    public ActionResult GetGamesIdsContainingPlayers() => new ObjectResult(_infoService.GetGamesIdsContainingPlayers());


    [HttpGet("Game/{gameId:int}")]
    public ActionResult GetGame(int gameId) => new ObjectResult(_infoService.GetGameForSuperUser(gameId));
}