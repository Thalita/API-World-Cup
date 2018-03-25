using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore;
using Newtonsoft.Json;

namespace WorldCup2018.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Coach {get;set;}
        public string Group { get; set; }
        public string Flag{get;set;}
    }
}