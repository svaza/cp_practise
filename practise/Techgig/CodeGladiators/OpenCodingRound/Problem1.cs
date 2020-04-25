using System;
using System.Linq;

namespace Practise.Techgig.CodeGladiators.OpenCodingRound
{
    public class Problem1
    {
        public static void Main(String[] args)
        {
            int numberOfIngredients = int.Parse(Console.ReadLine());
            long[] quantityReq = Console.ReadLine()
                .Trim()
                .Split(' ')
                .Select(e => long.Parse(e))
                .ToArray();

            long[] quantityHas = Console.ReadLine()
                .Trim()
                .Split(' ')
                .Select(e => long.Parse(e))
                .ToArray();

            long prevProducable = quantityHas[0] / quantityReq[0];
            for (int i = 1; i < numberOfIngredients; i++)
            {
                long producable = quantityHas[i] / quantityReq[i];
                if (prevProducable > producable)
                {
                    prevProducable = producable;
                }
            }

            Console.WriteLine(prevProducable);
        }
    }
}
