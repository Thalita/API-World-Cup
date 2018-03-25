using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore;
using Newtonsoft.Json;


namespace WorldCup2018.Models
{
    public class Match
    {
        public int Id { get; set; }

        [JsonProperty]
        [JsonConverter(typeof(Converters.TeamConverter))]
        public virtual Team TeamOne { get; set; }

        [JsonProperty]
        [JsonConverter(typeof(Converters.TeamConverter))]
        public virtual Team TeamTwo { get; set; }

        public DateTime Date { get; set; } 

        [JsonProperty]
        [JsonConverter(typeof(Converters.PhaseConverter))]
        public virtual Phase Phase {get;set;} 
        
        [JsonProperty]
        [JsonConverter(typeof(Converters.StadiumConverter))]  
        public virtual Stadium Stadium {get;set;}   
    }
}