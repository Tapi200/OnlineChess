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

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter T");
            //T = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter N");
            //N = Convert.ToInt32(Console.ReadLine());
            //int T = 1;
            int N = 2;

            GameObject[] player = new GameObject[N];
            
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

            Console.WriteLine(player[1].R);


        }
    }
}



