﻿using Qwirkle.Core.CommonContext.ValueObjects;
using Qwirkle.Core.ComplianceContext.Entities;
using System.Collections.Generic;

namespace Qwirkle.Core.ComplianceContext.Ports
{
    public interface ICompliancePersistance
    {
        bool IsPlayerTurn(int playerId);
        void SetPlayerTurn(int playerId, bool turn);
        void TilesFromPlayerToBoard(int gameId, List<Tile> tiles);
        void UpdatePlayer(Player player);
        void TilesFromBagToPlayer(Player player, int tilesNumber);
        Board GetBoardByGameId(int boardId);
        Player GetPlayerById(int playerId);
        Tile GetTileById(int tileId);
    }
}