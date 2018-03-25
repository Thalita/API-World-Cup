using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore;
using System.Web;
using Newtonsoft.Json;
using WorldCup2018.Models;

namespace WorldCup2018.Models.Converters
{
    public static class  GenericConverter
    {
       public static T ConverteJSonParaObject<T>(string jsonString)
        {
            try
            {
                T obj = (T)(JsonConvert.DeserializeObject(jsonString, typeof(T)));
                return obj;
            }
            catch
            {
                throw;
            }
        }
    }
}
