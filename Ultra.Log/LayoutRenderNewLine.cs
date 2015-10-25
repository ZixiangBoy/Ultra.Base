using NLog;
using NLog.LayoutRenderers;
using System;
using System.Text;

namespace Ultra.Log
{
    [Serializable]
    public class LayoutRenderNewLine : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo ev)
        {
            builder.AppendLine(ev.Message);
        }
    }
}

