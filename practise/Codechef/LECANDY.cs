using System;
using System.Linq;

namespace Practise.Codechef
{
    class LECANDY
    {
        public static void Main()
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                var nc = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToArray();
                int n = nc[0];
                int c = nc[1];
                var a = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToArray();
                if(a.Sum() <= c)
                {
                    Console.WriteLine("Yes");
                } else
                {
                    Console.WriteLine("No");
                }
            }
        }
    }
}
