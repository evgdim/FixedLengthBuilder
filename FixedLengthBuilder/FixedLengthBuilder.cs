using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedLength
{
    public class FixedLengthBuilder
    {
        public List<Element> Elements { get; set; }
        private int lastIndex;
        private FixedLengthBuilder()
        {
            Elements = new List<Element>();
            lastIndex = 0;
        }

        public static FixedLengthBuilder New()
        {
            return new FixedLengthBuilder();
        }
        public FixedLengthBuilder Add(int length, string value, char? filler = null)
        {
            if (value.Length > length) { value = value.Substring(0, length); }

            if (filler.HasValue)
            {
                Elements.Add(new Element(lastIndex, length, value,filler.Value));
            }
            else
            {
                Elements.Add(new Element(lastIndex, length, value));
            }
            lastIndex = lastIndex + length;
            return this;
        }
        public string Build()
        {
            return String.Join("", Elements);
        }
    }
}
