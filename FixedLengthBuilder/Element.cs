using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedLength
{
    public class Element
    {
        public int IndexBegin { get; set; }
        public int IndexEnd { get; set; }
        public int Length { get; set; }
        public string Value { get; set; }
        public char? Filler { get; set; }

        public Element(int index, int length, string value)
        {
            this.IndexBegin = index;
            this.Length = length;
            this.Value = value;
            this.IndexEnd = IndexBegin + length - 1;
        }

        public Element(int index, int length, string value, char filler) : this(index, length, value)
        {
            this.Filler = filler;
        }

        public override string ToString()
        {
            return Filler.HasValue ? Value.PadLeft(Length, Filler.Value) : Value.PadLeft(Length);
        }
    }
}
