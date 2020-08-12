using System;
using System.Collections.Generic;
using System.Text;

namespace Host.HL7
{
    public class Message
    {
        private const string MSH = "MSH";
        private const int MSH_MSG_CONTROL_ID = 10;

        private readonly List<Segment> _segments;

        public Message()
        {
            _segments = new List<Segment>();
        }

        public List<Segment> GetSegments => _segments;

        private Segment Header()
        {
            if (_segments.Count == 0 || _segments[0].Name != MSH)
            {
                return null;
            }
            return _segments[0];
        }

        public string MessageControlId()
        {
            var msh = Header();
            return msh == null ? string.Empty : msh.Field(MSH_MSG_CONTROL_ID);
        }

        public void Add(Segment segment)
        {
            if (!string.IsNullOrEmpty(segment.Name) && segment.Name.Length == 3)
            {
                _segments.Add(segment);
            }
        }

        public void DeSerializeMessage(string message)
        {
            char[] separator = { '\r' };
            var tokens = message.Split(separator, StringSplitOptions.None);

            foreach (var item in tokens)
            {
                var segment = new Segment();
                segment.DeSerializeSegment(item.Trim('\n'));
                Add(segment);
            }
        }

        public string SerializeMessage()
        {
            var builder = new StringBuilder();
            char[] separators = { '\r', '\n' };

            foreach (var segment in _segments)
            {
                builder.Append(segment.SerializeSegment());
                builder.Append("\r\n");
            }
            return builder.ToString().TrimEnd(separators);
        }
    }
}