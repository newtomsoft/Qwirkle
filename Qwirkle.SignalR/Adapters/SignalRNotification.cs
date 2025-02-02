﻿namespace Qwirkle.SignalR.Adapters;

public class SignalRNotification : INotification
{
    private readonly IHubContext<HubQwirkle> _hubContextQwirkle;

    public SignalRNotification(IHubContext<HubQwirkle> hubContextQwirkle)
    {
        _hubContextQwirkle = hubContextQwirkle;
    }

    public void SendPlayerIdTurn(int gameId, int playerId) => _hubContextQwirkle.Clients.Group(gameId.ToString()).SendAsync("ReceivePlayerIdTurn", playerId);
    public void SendTurnSkipped(int gameId, int playerId) => _hubContextQwirkle.Clients.Group(gameId.ToString()).SendAsync("ReceiveTurnSkipped", playerId);
    public void SendTilesPlayed(int gameId, int playerId, Move move) => _hubContextQwirkle.Clients.Group(gameId.ToString()).SendAsync("ReceiveTilesPlayed", playerId, move.Points, move.Tiles);
    public void SendTilesSwapped(int gameId, int playerId) => _hubContextQwirkle.Clients.Group(gameId.ToString()).SendAsync("ReceiveTilesSwapped", playerId);
    public void SendGameOver(int gameId, List<int> winnersPlayersIds) => _hubContextQwirkle.Clients.Group(gameId.ToString()).SendAsync("ReceiveGameOver", winnersPlayersIds);
    
    public void SendInstantGameStarted(int playersNumberForStartGame, int gameId) => _hubContextQwirkle.Clients.Group(HubQwirkle.InstantGameGroupName(playersNumberForStartGame)).SendAsync("ReceiveInstantGameStarted", playersNumberForStartGame, gameId);
    public void SendInstantGameExpected(int playersNumberForStartGame, string userName) => _hubContextQwirkle.Clients.Group(HubQwirkle.InstantGameGroupName(playersNumberForStartGame)).SendAsync("ReceiveInstantGameExpected", userName);
}