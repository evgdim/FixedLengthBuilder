using FixedLength;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = FixedLengthBuilder.New().Add(10, "ffffffffff").Add(10, "tttttttttt").Add(5, "12345", '0').Add(10, "20160915");
            string paymentstr = builder.Build();
            Console.WriteLine("|"+ paymentstr + "|");
            Payment payment = FixedLengthParser<Payment>.New(new Payment(), paymentstr)
                                    .SetStringTrim(p => p.FromIban, 0, 10)
                                    .SetStringTrim(p => p.ToIban, 10, 10)
                                    .SetDecimal(p => p.Amount, 20, 5)
                                    .SetDateTime(p => p.Timestamp, 25, 10)
                                    .Get();
            Console.ReadKey();
        }
    }
}
