using System;
using System.Collections.Generic;
using System.Text;

namespace Practise.Spoj
{
    public class ONP
    {
        public static void Main()
        {
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                string exp = Console.ReadLine();
                StringBuilder sb = new StringBuilder();
                Stack<char> stack = new Stack<char>(exp.Length);
                for(int i = 0; i< exp.Length; i++)
                {
                    if(exp[i] >= 97 && exp[i] <= 122)
                    {
                        sb.Append(exp[i]);
                    }
                    else if(exp[i] == ')')
                    {
                        while(stack.Count > 0)
                        {
                            char c = stack.Pop();
                            if (c == '(') break;
                            sb.Append(c);
                        }
                    }
                    else
                    {
                        stack.Push(exp[i]);
                    }
                }

                Console.WriteLine(sb);
            }
        }
    }
}
