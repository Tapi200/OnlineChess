using System;

namespace OnlineChess
{
    public class GameObject
    {
        public int R { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public string Color { get; set; }
        public string IsRated { get; set; }
        public int Time { get; set; }
        public int MyProperty { get; set; }
    }

    public class CreateGame
    {
        public void CreatePlayer(GameObject[] player, int N)
        {
            for (int i = 0; i < N; i++)
            {
                player[i] = new GameObject();
            }

            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine();
                var inputArray = input.Split(' ');
                player[i].R = Convert.ToInt32(inputArray[0]);
                player[i].Min = Convert.ToInt32(inputArray[1]);
                player[i].Max = Convert.ToInt32(inputArray[2]);
                player[i].Time = Convert.ToInt32(inputArray[3]);
                player[i].IsRated = inputArray[4];
                player[i].Color = inputArray[5];
            }
        }

        private bool MatchColor(int i, int j, GameObject[] player)
        {
            if (player[i].Color == "random" && player[j].Color == "random" || 
                player[i].Color == "white" && player[j].Color == "black" || 
                player[i].Color == "black" && player[j].Color == "white")
                return true;
            return false;
        }

        public bool MatchExist(int i, int j, GameObject[] player)
        {
            if (player[i].R >= player[j].Min
                && player[i].R <= player[j].Max
                && player[i].IsRated == player[j].IsRated
                && player[i].Time == player[j].Time 
                && MatchColor(i, j, player))
                return true;
             return false;
        }

        public bool IsElementInOutput(string[] output, int j)
        {
            foreach (var e in output)
            {
                if (Convert.ToString(j + 1) == e)
                    return true;
            }
            return false;
        }
    }

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
                //int N = 7;
                var player = new GameObject[N];
                var game = new CreateGame();

                game.CreatePlayer(player, N);

                var output = new string[N];

                output[0] = "wait";

                for (int i = 1; i < N; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (game.MatchExist(i, j, player))
                        {
                            if (!game.IsElementInOutput(output, j))
                            {
                                output[i] = (j + 1).ToString();
                                break;
                            }
                        }
                        output[i] = "wait";
                    }
                }

                foreach (var item in output)
                    Console.WriteLine(item);
                T--;
            }
        }
    }
}


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
