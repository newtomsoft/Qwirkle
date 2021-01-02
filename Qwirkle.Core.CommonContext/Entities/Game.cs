﻿using Qwirkle.Core.CommonContext.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Qwirkle.Core.CommonContext.Entities
{
    public class Game
    {
        public int Id { get; }
        public List<TileOnBoard> Tiles { get; set; }
        public List<Player> Players { get; set; }
        public Bag Bag { get; set; }

        public Game(int id, List<TileOnBoard> tiles, List<Player> players, Bag bag = null)
        {
            Id = id;
            Tiles = tiles;
            Players = players;
            Bag = bag;
        }

        public Game(Game game)
        {
            Id = game.Id;
            Tiles = game.Tiles.ToList();
            Players = game.Players;
            Bag = game.Bag;
        }
    }
}