using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

class Solution
{
    /// <summary>
    /// Helper class.  AVOID !!!
    /// </summary>
    class ConsoleInput : IDisposable
    {
        public void Dispose()
        {

        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(object o)
        {
            Console.WriteLine(o);
        }

        public void Write(object o)
        {
            Console.Write(o);
        }
    }

    class DescendingComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x == y ? 0 : x > y ? -1 : 1;
        }
    }

    // Complete the climbingLeaderboard function below.
    static int[] climbingLeaderboard(int[] scores, int[] alice)
    {
        List<int> aliceBoard = new List<int>();
        SortedDictionary<int, int> leaderBoardRanks = new SortedDictionary<int, int>(new DescendingComparer());
        int rank = 1;
        foreach (var score in scores)
        {
            if (leaderBoardRanks.ContainsKey(score)) continue;
            leaderBoardRanks.Add(score, rank++);
        }

        var indexedLeaderBoard = leaderBoardRanks.Select((kv, index) => new { Index = index, KeyValue = kv }).ToList();
        int leaderBoardPointer = indexedLeaderBoard.Count-1;
        for (int k = 0; k < alice.Length; k++)
        {
            int aliceScore = alice[k];
            for (int i = leaderBoardPointer; i>=0;)
            {
                if(aliceScore < indexedLeaderBoard[i].KeyValue.Key)
                {
                    aliceBoard.Add(indexedLeaderBoard[i].KeyValue.Value + 1);
                    break;
                }
                else if (aliceScore == indexedLeaderBoard[i].KeyValue.Key)
                {
                    aliceBoard.Add(indexedLeaderBoard[i].KeyValue.Value);
                    break;
                }
                else if (aliceScore > indexedLeaderBoard[i].KeyValue.Key)
                {
                    leaderBoardPointer--;
                    i--;
                }
                else if(i == 0 && alice[alice.Length - 1] > indexedLeaderBoard[i].KeyValue.Key)
                {
                    aliceBoard.Add(indexedLeaderBoard[0].KeyValue.Value);
                }
            }
            if (leaderBoardPointer < 0)
            {
                aliceBoard.Add(1);
            }

        }

        return aliceBoard.ToArray();
    }

    static void Main(string[] args)
    {
        using (var console = new ConsoleInput())
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), false);

            int scoresCount = Convert.ToInt32(console.ReadLine());

            int[] scores = Array.ConvertAll(console.ReadLine().Split(' '), scoresTemp => Convert.ToInt32(scoresTemp));
            int aliceCount = Convert.ToInt32(console.ReadLine());

            int[] alice = Array.ConvertAll(console.ReadLine().Split(' '), aliceTemp => Convert.ToInt32(aliceTemp));
            int[] result = climbingLeaderboard(scores, alice);

            textWriter.WriteLine(string.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();
        }
            
    }
}
