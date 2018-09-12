using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faceless.Dummy {
    class Program {

        class Test {
            public int int1;
            public string string1;

            public void Add(int i) {
                int1 += i;
            }
        }

        static void Main(string[] args) {
            
            Console.WriteLine(Reverse("Hello, World!"));
            Console.WriteLine(Fib(0, 1, 10));

    
            var t = new Test();
            t.int1 = 1;
            t.string1 = "string value 1";

            t.Add(1);
            Console.WriteLine(t.int1);
            Console.WriteLine(t.string1);

        }
        static string Reverse(string s) {
            var sb = new StringBuilder();
            for(int i = 0; i < s.Length; i++) {
                sb.Append(s[s.Length - (i + 1)]);
            }
            return sb.ToString();
        }

        static int Fib(int a, int b, int count) {
            if(count == 0) {
                return a + b;
            }
            return Fib(b, a + b, count - 1);
        }
    }
}
