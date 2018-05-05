using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoVip.Core;
using YoVip.Core.Models.Entities;
using YoVip.Core.Services;

namespace StreamWriteTest
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Diagnostics;
    using System.IO;
    using YoVip.Core;
    class Program
    {
        static void Main(string[] args)
        {
            var paths = new List<string>();
            var text = File.ReadAllText(@"Models\WeChat\CardModels\Templates\cash.json");
            var jo = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(text);
            foreach (var token in jo.Children())
            {
                GetJOjbectProperties(token.Children(), paths);
            }

            text = File.ReadAllText(@"Models\WeChat\CardModels\Templates\discount.json");
            jo = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(text);
            foreach (var token in jo.Children())
            {
                GetJOjbectProperties(token.Children(), paths);
            }
            text = File.ReadAllText(@"Models\WeChat\CardModels\Templates\general_coupon.json");
            jo = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(text);
            foreach (var token in jo.Children())
            {
                GetJOjbectProperties(token.Children(), paths);
            }

            text = File.ReadAllText(@"Models\WeChat\CardModels\Templates\gift.json");
            jo = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(text);
            foreach (var token in jo.Children())
            {
                GetJOjbectProperties(token.Children(), paths);
            }
            text = File.ReadAllText(@"Models\WeChat\CardModels\Templates\groupon.json");
            jo = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(text);
            foreach (var token in jo.Children())
            {
                GetJOjbectProperties(token.Children(), paths);
            }
            text = File.ReadAllText(@"Models\WeChat\CardModels\Templates\member_card.json");
            jo = Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(text);
            foreach (var token in jo.Children())
            {
                GetJOjbectProperties(token.Children(), paths);
            }
            var context = string.Join("\r\n", paths.Select((str) =>
            {
                return string.Concat("$.", str.Replace("cash", "{0}")
                .Replace("discount", "{0}")
                .Replace("general_coupon", "{0}")
                .Replace("groupon", "{0}")
                .Replace("member_card", "{0}")
                .Replace("gift", "{0}"));
            }).Distinct().ToList());

        }
        static void GetJOjbectProperties(JEnumerable<JToken> children, IList<string> paths)
        {
            if (children.Count().Equals(0))
            {

                return;
            }
            else
            {
                foreach (var token in children)
                {
                    paths.Add(token.Path);
                    GetJOjbectProperties(token.Children(), paths);
                }
            }
        }
    }
}
