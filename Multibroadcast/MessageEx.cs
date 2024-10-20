using MEC;
using PluginAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Multibroadcast
{
    internal class MessageEx : MonoBehaviour
    {
        static Player ply;
        static List<string> messages = new List<string>();
        static List<float> _visualtimes = new List<float>();

        private void Awake()
        {
            ply = Player.Get(gameObject);
        }

        internal static void SendMessage(ushort time, string content)
        {
            foreach (Player player in Player.GetPlayers())
            {
                MessageEx component = player.GameObject.gameObject.GetComponent<MessageEx>();
                if (!(component == null))
                {
                    float dur = time;
                    messages.Add(content);
                    _visualtimes.Add(dur);
                    Sendrefresh();
                    Timing.CallDelayed(time, delegate ()
                    {
                        messages.Remove(content);
                        _visualtimes.Remove(dur);
                        Sendrefresh();
                    });
                }
            }
        }


        internal static void AddMessage(Player player, ushort time, string content)
        {
            float dur = time;
            messages.Add(content);
            _visualtimes.Add(dur);
            Addrefresh(player.UserId);
            Timing.CallDelayed(time, delegate ()
            {
                messages.Remove(content);
                _visualtimes.Remove(dur);
                Addrefresh(player.UserId);
            });
        }

        internal static void Sendrefresh()
        {
            if (messages.Count() == 0)
            {
                Server.SendBroadcast(string.Empty, 100, Main.Config.broadcast_flags, false);
                return;
            }
            ushort time = 100;
            foreach (ushort num2 in _visualtimes)
            {
                if (num2 < time)
                {
                    time = num2;
                }
            }
            messages.Reverse();
            string text = "";
            int num3 = Main.Config.line_height;
            foreach (string text2 in messages)
            {
                num3--;
                if (num3 == 6)
                {
                    text += text2;
                }
                else
                {
                    text = text + "\n" + text2;
                }
            }
            for (int i = 0; i < num3; i++)
            {
                text += "\n";
            }
            text += "";
            Server.SendBroadcast(text, time, Main.Config.broadcast_flags, false);
            messages.Reverse();
        }

        internal static void Addrefresh(string playerId)
        {
            var player = Player.Get(playerId);
            if (messages.Count() == 0)
            {
                player.SendBroadcast(string.Empty, 100, Main.Config.broadcast_flags, false);
                return;
            }
            ushort time = 100;
            foreach (ushort num2 in _visualtimes)
            {
                if (num2 < time)
                {
                    time = num2;
                }
            }
            messages.Reverse();
            string text = "";
            int num3 = Main.Config.line_height;
            foreach (string text2 in messages)
            {
                num3--;
                if (num3 == 6)
                {
                    text += text2;
                }
                else
                {
                    text = text + "\n" + text2;
                }
            }
            for (int i = 0; i < num3; i++)
            {
                text += "\n";
            }
            text += "";
            player.SendBroadcast(text, time, Main.Config.broadcast_flags, false);
            messages.Reverse();
        }
    }
}
