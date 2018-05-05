﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamWriteTest
{
    public static class JsonObjectExtension
    {
        public static T GetValue<T>(this JObject oj, string path) where T : class
        {
            JToken token = oj.SelectToken(path, true);
            return token.Value<T>();
        }
        public static void ReplaceValue<T>(this JObject oj, string path, T value) where T : class
        {
            JToken token = oj.SelectToken(path, true);
            var valueToken = new JValue(value);
            token.Replace(valueToken);
        }
        
    }
}