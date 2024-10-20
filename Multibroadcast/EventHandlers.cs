using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginAPI;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace Multibroadcast
{
    internal class EventHandlers
    {

        public void JoinEvent(PlayerJoinedEvent ev)
        {
            MessageEx.AddMessage(ev.Player, 10, "Hello!");
        }

        public void OnAnnouncingDecontamination(LczDecontaminationAnnouncementEvent ev)
        {
            switch (ev.Id)
            {
                case 0:
                    {
                        MessageEx.SendMessage(10, "15 minutes until Lcz closure");
                        break;
                    }
                case 1:
                    {
                        MessageEx.SendMessage(10, "10 minutes until Lcz closure");
                        break;
                    }
                case 2:
                    {
                        MessageEx.SendMessage(10, "5 minutes until Lcz closure");
                        break;
                    }
                case 3:
                    {
                        MessageEx.SendMessage(10, "1 minutes until Lcz closure");
                        break;
                    }
                case 4:
                    {
                        MessageEx.SendMessage(10, "30 seconds until Lcz closes");
                        break;
                    }
            }
        }

        public void OnAnnouncingDecontamination(LczDecontaminationStartEvent ev)
        {
            MessageEx.SendMessage(10, "Lcz closure complete");
        }
    }
}
