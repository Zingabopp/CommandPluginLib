using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandPluginLib.Util;

namespace CommandPluginLib
{
    public static class CommandPluginController
    {
        private static List<ICommandPlugin> _pluginList;

        private static List<ICommandPlugin> PluginList
        {
            get
            {
                if (_pluginList == null)
                    _pluginList = new List<ICommandPlugin>();
                return _pluginList;
            }
        }

        public static bool RegisterPlugin(ICommandPlugin plugin)
        {
            if(PluginList.Contains(plugin))
            {
                Logger.Error($"Cannot register plugin {plugin.PluginName}, it is already registered");
                return false;
            }
            PluginList.Add(plugin);
            Logger.Debug($"Registered plugin: {plugin.PluginName}");
            plugin.Start();
            return true;
        }

        public static void MessageFromServer(MessageData msg)
        {
            PluginList.Where(p => p.PluginName == msg.Destination).ToList().ForEach(m => {
                Logger.Debug($"Received message from server, sending to {m.PluginName}: {msg.ToJSON()}");
                m.OnMessage(null, msg);
            });
        }

        public static void MessageToServer(MessageData msg)
        {

        }


    }
}
