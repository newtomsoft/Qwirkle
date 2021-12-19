﻿namespace Qwirkle.Domain.ExtensionMethods;

public static class TilesOnBoardExtensionsMethods
{
    public static List<TileOnBoard> FirstConsecutives(this List<TileOnBoard> tiles, Direction direction, sbyte reference)
    {
        var diff = direction == Direction.Right || direction == Direction.Top ? -1 : 1;
        var result = new List<TileOnBoard>();
        if (tiles.Count == 0) return result;
        if ((direction == Direction.Left || direction == Direction.Right) && reference != tiles[0].Coordinates.X + diff) return result;
        if ((direction == Direction.Top || direction == Direction.Bottom) && reference != tiles[0].Coordinates.Y + diff) return result;

        result.Add(tiles[0]);
        for (var i = 1; i < tiles.Count; i++)
        {
            if ((direction == Direction.Left || direction == Direction.Right) && tiles[i - 1].Coordinates.X == tiles[i].Coordinates.X + diff && tiles[i - 1].Coordinates.Y == tiles[i].Coordinates.Y
             || (direction == Direction.Top || direction == Direction.Bottom) && tiles[i - 1].Coordinates.Y == tiles[i].Coordinates.Y + diff && tiles[i - 1].Coordinates.X == tiles[i].Coordinates.X)
                result.Add(tiles[i]);
            else
                break;
        }
        return result;
    }

    public static bool FormCompliantRow(this List<TileOnBoard> tiles)
    {
        for (var i = 0; i < tiles.Count; i++)
            for (var j = i + 1; j < tiles.Count; j++)
                if (!tiles[i].OnlyShapeOrColorEqual(tiles[j])) return false;

        return true;
    }
}