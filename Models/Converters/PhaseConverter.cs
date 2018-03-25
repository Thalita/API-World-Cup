using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore;
using System.Web;
using Newtonsoft.Json;
using WorldCup2018.Models;
using WorldCup2018.Models.DataBase;

namespace WorldCup2018.Models.Converters
{
    class PhaseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Phase));
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DataBaseManipulate.GetPhase(Convert.ToInt32(reader.Value));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            
        }
    }
}
