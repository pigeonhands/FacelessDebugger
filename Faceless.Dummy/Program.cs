using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faceless.Dummy {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine(Reverse("Hello, World!"));
            Console.WriteLine(Fib(0, 1, 10));
            
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
