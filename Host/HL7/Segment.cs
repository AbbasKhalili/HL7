using System.Collections.Generic;
using System.Text;

namespace Host.HL7
{
    public class Segment
    {
        private readonly Dictionary<int, string> _fields;

        public string Name => !_fields.ContainsKey(0) ? string.Empty : _fields[0];

        public Segment()
        {
            _fields = new Dictionary<int, string>(100);
        }

        public Segment(string name)
        {
            _fields = new Dictionary<int, string>(100) {{0, name}};
        }

        public string Field(int key)
        {
            if (Name == "MSH" && key == 1) return "|";

            if (!_fields.ContainsKey(key))
            {
                return string.Empty;
            }
            return _fields[key];
        }

        public void Field(int key, string value)
        {
            if (Name == "MSH" && key == 1) return;

            if (!string.IsNullOrEmpty(value))
            {
                if (_fields.ContainsKey(key))
                {
                    _fields.Remove(key);
                }

                _fields.Add(key, value);
            }
        }

        public void DeSerializeSegment(string segment)
        {
            var count = 0;
            var temp = segment.Trim('|');
            var fields = temp.Split('|');

            foreach (var field in fields)
            {
                Field(count, field);
                if (field == "MSH")
                {
                    ++count;
                }
                ++count;
            }
        }

        public string SerializeSegment()
        {
            var max = 0;
            foreach (var field in _fields)
            {
                if (max < field.Key)
                {
                    max = field.Key;
                }
            }

            var temp = new StringBuilder();

            for (var index = 0; index <= max; index++)
            {
                if (_fields.ContainsKey(index))
                {
                    temp.Append(_fields[index]);

                    if (index == 0 && Name == "MSH")
                    {
                        ++index;
                    }
                }
                if (index != max) temp.Append("|");
            }
            return temp.ToString();
        }
    }
}