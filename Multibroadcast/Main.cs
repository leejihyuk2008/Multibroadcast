using PluginAPI.Core.Attributes;
using PluginAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multibroadcast
{
    internal class Main
    {
        [PluginEntryPoint("Multibroadcast", "1.0.0.0", "Multibroadcast", "leejihyuk")]
        private void Init()
        {
            Singleton = this;
            EventManager.RegisterEvents<EventHandlers>(this);
        }

        public const string Version = "1.0.0.0";

        [PluginConfig]
        public static Config Config;

        public static Main Singleton;
    }
}
