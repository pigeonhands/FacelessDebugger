using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faceless.Dummy {
    class Program {

        class Test {
            public int Int1 { get; private set; }
            public string string1;

            public Test() {
                Int1 = 10;
            }

            public void Add(int i) {
                Int1 += i;
            }
        }

        static void Main(string[] args) {

            Console.WriteLine(Reverse("Hello, World!"));
            Console.WriteLine(Fib(0, 1, 10));

    
            var t = new Test();
            t.string1 = "string value 1";

            t.Add(1);
            Console.WriteLine(t.Int1);
            Console.WriteLine(t.string1);


            Generic<string>();
        }

        static object Generic<T>() {
            if(typeof(T) == typeof(string)) {
                Console.WriteLine("string.");
            }
            return new Random();
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
