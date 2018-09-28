using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Archery.Tools
{
    public sealed class Message
    {
        public MesssageType MessageType { get; private set; }
        public string Text { get; set; }

        public Message(string text, MesssageType messageType)
        {
            MessageType = messageType;
            Text = text;
        }
    }

    public enum MesssageType { SUCCESS, DANGER }
}