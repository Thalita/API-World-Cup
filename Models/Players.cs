using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore;

namespace WorldCup2018.Models
{
    public class Player
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Team Team{get;set;}
        public bool FlagTitularPlayer {get;set;}
        public int Number{get;set;}
    }
}