using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore;
using System.Web;
using Newtonsoft.Json;

namespace WorldCup2018.Models.DataBase
{
    public static class Utils
    {
        public static string ReadFile(string path)
        {
            string obj = null;
            using (StreamReader sr = new StreamReader(path))
            {
                obj = sr.ReadToEnd();
            }
            return obj;
        }
    }
}