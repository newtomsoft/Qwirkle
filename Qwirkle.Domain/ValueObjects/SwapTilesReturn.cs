﻿namespace Qwirkle.Domain.ValueObjects;

public struct SkipTurnReturn
{
    public int GameId { get; set; }
    public PlayReturnCode Code { get; set; }
}