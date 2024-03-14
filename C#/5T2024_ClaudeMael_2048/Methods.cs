using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5T2024_ClaudeMael_2048
{
    public struct Methods
    {


        public void CreateGrid(byte gridSize, out uint[,] grid)
        {
            Random random = new Random();
            grid = new uint[gridSize, gridSize];
            for(int row = 0; row < gridSize; row++)
            {
                for(int column = 0; column < gridSize; column++)
                {
                    grid[row, column] = 0;
                }
            }
            grid[random.Next(0, gridSize), random.Next(0, gridSize)] = 2;
        }

        public void CreateBlock(ref uint[,] grid)
        {

            Random random = new Random();
            Dictionary<int, int> availablePlaces = new Dictionary<int, int>();
            for(int row = 0; row <= grid.GetLength(0); row++)
            {
                for(int col = 0; col <= grid.GetLength(1); col++)
                {
                    if (grid[row, col] == 0)
                    {
                        // TO DO
                    }
                }
            }
            if(availablePlaces.Count > 0)
            {
                Console.WriteLine(availablePlaces.FirstOrDefault());
                
            }
            
        }

        public string ConcateneGrid(uint[,] grid)
        {
            string concatene = "";
            for (int row = 0; row <= grid.GetLength(0) - 1; row++)
            {

                string ligne = "[";
                for (int column = 0; column <= grid.GetLength(1) - 1; column++)
                {
                    ligne = ligne + grid[row, column];
                    if (column != grid.GetLength(1) - 1)
                    {
                        ligne = ligne + "|";
                    }
                    else
                    {
                        ligne = ligne + "]";
                    }
                }
                concatene = concatene + "\n" + ligne;
            }
            return concatene;
        }


        public void LireByte(string question, out byte output)
        {
            Console.WriteLine(question);
            string nUser = Console.ReadLine();
            while(!byte.TryParse(nUser, out output)){
                Console.WriteLine(question);
                nUser = Console.ReadLine();
            }
        }

        public void LireChar(string question, out char output)
        {
            Console.WriteLine(question);
            string nUser = Console.ReadLine();
            while (!char.TryParse(nUser, out output))
            {
                Console.WriteLine(question);
                nUser = Console.ReadLine();
            }
        }

    }
}
