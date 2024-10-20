using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multibroadcast
{
    public class Config
    {
        [Description("Multibroadcast - by Discord Name: leejihyuk")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("broadcast settings: Recommended to set to default")]
        public int line_height { get; set; } = 22;

        [Description("This is a Broadcast Flags type.")]

        public Broadcast.BroadcastFlags broadcast_flags { get; set; } = Broadcast.BroadcastFlags.Normal;
    }
}
