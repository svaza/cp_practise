using System;
using System.Linq;

namespace Practise.Techgig.CodeGladiators.OpenCodingRound
{
    public class Problem2
    {
        static void Main(String[] args)
        {
            int t = int.Parse(Console.ReadLine());
            while (--t >= 0)
            {
                int noOfMembers = int.Parse(Console.ReadLine());

                var grev = Console.ReadLine().Trim()
                    .Split(' ')
                    .Select(e => long.Parse(e))
                    .OrderBy(e => e)
                    .ToArray();

                var opponent = Console.ReadLine().Trim()
                    .Split(' ')
                    .Select(e => long.Parse(e))
                    .OrderBy(e => e)
                    .ToArray();

                int counter = 0;
                int pointer = 0;
                foreach(var opponentPower in opponent)
                {
                    while(pointer < grev.Length)
                    {
                        if (grev[pointer] > opponentPower)
                        {
                            // Console.WriteLine($"{grev[pointer]} cancelled {opponentPower}");
                            counter++;
                            pointer++;
                            break;
                        }
                        pointer++;
                    }

                    if(pointer >= grev.Length)
                    {
                        break;
                    }
                }

                Console.WriteLine(counter);
            }
        }
    }
}
