using Newtonsoft.Json;
using RedisMonitor.Core.Extension;
using RedisMonitor.Core.Model;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace RedisMonitor.Core.RedisServer
{
    public class RedisServerConfig
    {
        public static List<RedisServerModel> RedisServers { get; set; }

        public static string ConfigPath = CoreExtension.HttpContext != null
                ? string.Format("{0}/Config/RedisServiceConfig.json", Environment.CurrentDirectory) :string.Format("{0}/Config/RedisServiceConfig.json",Environment.CurrentDirectory);

        static RedisServerConfig()
        {
            LoadConfig();
        }

        public static void LoadConfig()
        {
            string context = File.ReadAllText(ConfigPath, System.Text.Encoding.Default);
            RedisServers = JsonConvert.DeserializeObject<List<RedisServerModel>>(context);
        }
    }
}