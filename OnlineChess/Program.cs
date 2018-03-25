using System;

namespace OnlineChess
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter T");
            int T = Convert.ToInt32(Console.ReadLine());

            while (T > 0)
            {
                Console.WriteLine("Enter N");
                int N = Convert.ToInt32(Console.ReadLine());
                if (N < 1 && N > 100)
                    throw new Exception();

                var player = new GameObject[N];
                var game = new CreateGame();

                game.CreatePlayer(player, N);

                var output = new string[N];

                game.MatchPlayers(player, output, N);

                foreach (var item in output)
                    Console.WriteLine(item);
                T--;
            }
        }
    }
}

//https://www.codechef.com/problems/ONCHESS
//Example
//Input:
//1
//7
//5 1 10 15 rated random
//11 1 20 15 rated random
//10 3 30 15 rated random
//2 5 15 15 rated random
//30 20 60 60 unrated white
//50 20 40 60 unrated random
//50 20 40 60 unrated black
//25 20 40 15 rated random
//50 20 40 60 unrated black

//Output:
//wait
//wait
//1
//2
//wait
//wait
//5
