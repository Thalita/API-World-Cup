using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore;

namespace WorldCup2018.Models
{
    public class Partnes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Promotion { get; set; }
    }
}