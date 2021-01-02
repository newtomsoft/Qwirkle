﻿namespace Qwirkle.Core.CommonContext.Enums
{
    public enum PlayReturnCode
    {
        Ok = 1,
        NotPlayerTurn,
        PlayerDontHaveThisTile,
        TileIsolated,
        TilesDontMakedValidRow,
    }
}