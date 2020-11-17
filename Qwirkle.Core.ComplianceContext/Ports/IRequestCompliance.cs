﻿using Qwirkle.Core.ComplianceContext.Entities;
using Qwirkle.Core.ComplianceContext.ValueObjects;
using System.Collections.Generic;

namespace Qwirkle.Core.ComplianceContext.Ports
{
    public interface IRequestCompliance
    {
        List<Player> CreateGame(List<int> usersIds);
        PlayReturn PlayTiles(int playerId, List<(int tileId, sbyte x, sbyte y)> tilesTupleToPlay);
    }
}