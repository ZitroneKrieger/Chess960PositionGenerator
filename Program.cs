using System.Linq;
using System.Runtime.CompilerServices;

internal class Program
{
    private static bool posValid = false;

    private static void Main(string[] args)
    {
        Console.WriteLine("Chess960 Position Generator started");


        var piecesList = new List<string>() { "R", "N", "B", "Q", "K", "B", "N", "R" };

        string[] whitePosition = new string[8];

        while (!posValid)
        {
            whitePosition = new string[8];
            var usedIndexes = new List<int>();

            for (int i = 0; i < piecesList.Count; i++)
            {
                Random rnd = new Random();
                int position = rnd.Next(0, 8);
                if (!usedIndexes.Contains(position))
                {
                    whitePosition[position] = piecesList[i];
                    usedIndexes.Add(position);
                }
                else
                {
                    i--;
                    continue;
                }
            }
            int firstRookPos = -1;
            int secondRookPos = -1;
            int kingPos = -1;
            int firstBishopPos = -1;
            int secondBishopPos = -1;

            for (int i = 0; i < whitePosition.Length; i++)
            {
                if (whitePosition[i] == null)
                {
                    break;
                }
                if (whitePosition[i] == "K")
                {
                    kingPos = i;
                }
                if (whitePosition[i] == "R" && firstRookPos == -1)
                {
                    firstRookPos = i;
                }
                else if (whitePosition[i] == "R" && firstRookPos != -1)
                {
                    secondRookPos = i;
                }
                if (whitePosition[i] == "B" && firstBishopPos == -1)
                {
                    firstBishopPos = i;
                }
                else if (whitePosition[i] == "B" && firstBishopPos != -1)
                {
                    secondBishopPos = i;
                }


            }

            var unterschiedlicheBishops = firstBishopPos % 2 == 0 && secondBishopPos % 2 == 1
                                       || firstBishopPos % 2 == 1 && secondBishopPos % 2 == 0;

            if (firstRookPos < kingPos && kingPos < secondRookPos && unterschiedlicheBishops)
            {
                posValid = true;
            }
        }

        if (posValid)
        {
            Console.Write("8 ");
            for (int j = 0; j < 8; j++)
            {
                Console.Write("| " + whitePosition[j].ToLowerInvariant() + " ");
            }
            Console.Write("|");
            Console.WriteLine();
            for (int k = 0; k < 6; k++)
            {
                Console.Write($"{8 - (k + 1)} ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("| _ ");
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.Write("1 ");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("| " + whitePosition[i] + " ");
            }
            Console.Write("|");

            Console.WriteLine();
            Console.Write("The final position is: ");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(whitePosition[i]);
            }
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("No position found, some error in logic");
            Console.ReadKey();
        }

    }
}