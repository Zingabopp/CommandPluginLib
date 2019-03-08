using System;
using System.Text;
using System.Collections.Generic;

namespace CommandPluginLib
{
    public interface ICommandPlugin
    {
        /// <summary>
        /// Name used to identify the plugin. Messages are prefixed with this to identify the plugin as the source/destination.
        /// </summary>
        string PluginName { get; }

        /// <summary>
        /// List of commands that can be received by this plugin.
        /// </summary>
        Dictionary<string, Action<object, string>> Commands { get; }

        /// <summary>
        /// Code to execute when a message is received.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnMessage(object sender, MessageData e);

        /// <summary>
        /// Executed once the plugin is loaded.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Messages to send to the server.
        /// </summary>
        event Action<object, MessageData> MessageReady;
    }

    /// <summary>
    /// An imitation of WebSocketSharp's MessageEventArgs class to avoid plugins needing to reference it.
    /// </summary>
    public struct MessageData
    {
        public string Source;
        public string Destination;
        public string Data;
        public string Flag;

        /// <summary>
        /// Constructor for MessageData.
        /// </summary>
        /// <param name="_src">Source of the message</param>
        /// <param name="_dest">Destination of the message</param>
        /// <param name="_data">Message data</param>
        public MessageData(string _src, string _dest, string _data, string _flag ="")
        {
            Console.WriteLine("Constructed new message!");
            Source = _src;
            Destination = _dest;
            Data = _data;
            Flag = _flag;
        }

        public override string ToString()
        {
            return ToString(0);
        }

        public string ToString(int spacing)
        {
            string s = "".PadRight(spacing);
            return $"{s}Source: {Source}\n{s}Destination: {Destination}\n{s}Flag: {Flag}\n{s}Data: {Data}";
        }

    }
}