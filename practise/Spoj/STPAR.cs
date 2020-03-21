using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Practise.Spoj
{
    class STPAR
    {
        public static void Main()
        {

            while (Console.ReadLine() != "0")
            {
                var n = Console.ReadLine().Split(' ').Select(e => int.Parse(e)).ToArray();
                Stack<int> stack = new Stack<int>(n.Length);
                int c = -1;
                int l = -1;
                bool invalid = false;
                while (++c < n.Length && !invalid)
                {
                    while (stack.Count > 0)
                    {
                        int p = stack.Peek();
                        if (p < n[c] && c == n.Length - 1)
                        {
                            invalid = true;
                            break;
                        }
                        else if (c < n.Length - 1 && p < n[c] && n[c] > n[c + 1])
                        {
                            invalid = true;
                            break;
                        }
                        else if (c < n.Length - 1 && p >= n[c] && p <= n[c + 1])
                        {
                            stack.Pop();
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (c < n.Length - 1 && n[c] > n[c + 1] && !invalid)
                    {
                        stack.Push(n[c]);
                    }
                    else if (!invalid)
                    {
                        if (l == -1)
                        {
                            l = n[c];
                        }
                        else if (c == n.Length - 1 && n[c] < l)
                        {
                            invalid = true;
                        }
                        else if (n[c] < l)
                        {
                            l = n[c];
                        }
                    }

                }

                Console.WriteLine(invalid ? "no" : "yes");
            }
        }
    }
}
