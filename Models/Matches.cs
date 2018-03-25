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
        public Team TeamOne { get; set; }

        [JsonProperty]
        [JsonConverter(typeof(Converters.TeamConverter))]
        public Team TeamTwo { get; set; }

        public DateTime Date { get; set; } 

        [JsonProperty]
        [JsonConverter(typeof(Converters.PhaseConverter))]
        public Phase Phase {get;set;} 
        
        [JsonProperty]
        [JsonConverter(typeof(Converters.StadiumConverter))]  
        public Stadium Stadium {get;set;}   
    }
}