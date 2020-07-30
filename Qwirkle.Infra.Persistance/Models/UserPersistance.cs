﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qwirkle.Infra.Persistance.Models
{
    [Table("User")]
    public class UserPersistance : IdentityUser<int>
    {
        [Column("Pseudo")]
        override public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Help { get; set; }
        public int Points { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }

    }
}
