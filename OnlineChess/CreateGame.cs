using System;

namespace OnlineChess
{
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

        public void MatchPlayers(GameObject[] player, string[] output, int N)
        {
            output[0] = "wait";

            for (int i = 1; i < N; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (MatchExist(i, j, player))
                    {
                        if (!IsElementInOutput(output, j))
                        {
                            output[i] = (j + 1).ToString();
                            break;
                        }
                    }
                    output[i] = "wait";
                }
            }
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
}



