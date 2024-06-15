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

        /// <summary>
        /// Génère une grille de taille customisable (entre 4 et 6)
        /// </summary>
        /// <param name="gridSize"></param>
        /// <param name="grid"></param>
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

        public bool CreateBlock(ref uint[,] grid)
        {

            Random random = new Random();
            bool hasPlace = false;

            // Regarde si la grid contient une place libre
            for(int row = 0; row < grid.GetLength(0); row++)
            {
                for(int col = 0; col < grid.GetLength(1); col++)
                {
                    if (grid[row, col] == 0) hasPlace = true;
                }
            }

            // Génère un bloc dans une place libre aléatoire
            if(hasPlace)
            {
                int randomRow;
                int randomCol;
                do
                {
                    randomRow = random.Next(0, grid.GetLength(0));
                    randomCol = random.Next(0, grid.GetLength(0));
                } while (grid[randomRow, randomCol] != 0);
                if(random.Next(0, 10+1) == 1)
                {
                    grid[randomRow, randomCol] = 4;

                }
                else
                {
                    grid[randomRow, randomCol] = 2;
                }
            }
            return hasPlace;
        }

        public bool CanMove(uint[,] grid)
        {
            // check si il y a des places libre
            for (int row = 0; row <= grid.GetLength(0) - 1; row++)
            {

                for (int column = 0; column <= grid.GetLength(1) - 1; column++)
                {
                    if (grid[row, column] == 0) return true;
                }
            }

            // check si 2 blocs peuvent fusionner horizontalement
            for (int row = 0; row <= grid.GetLength(0) -1; row++)
            {

                for (int column = 0; column <= grid.GetLength(1) - 2; column++)
                {
                    if (grid[row, column] == grid[row, column+1]) return true;
                }

            }

            // check si 2 blocs peuvent fusionner verticalement
            for (int column = 0; column <= grid.GetLength(1) - 1; column++)
            {

                for (int row = 0; row <= grid.GetLength(0) - 2; row++)
                {
                    if (grid[row, column] == grid[row+1, column]) return true;
                }

            }
            return false;


        }


        public void MoveBlocks(ref uint[,] grid)
        {
            int place;
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.LeftArrow:
                    for(int row = 0; row < grid.GetLength(0); row++){
                        place = 0;
                    
                        for(int col = 0; col < grid.GetLength(1); col++)
                        {
                            if (grid[row, col] != 0)
                            {
                                grid[row, place] = grid[row, col];
                                grid[row, col] = 0;
                                place++;
                                Console.WriteLine(ConcateneGrid(grid));
                            }
                        }
                    }
                    break;
                case ConsoleKey.RightArrow:
                    for (int row = 0; row < grid.GetLength(0); row++)
                    { 
                        place = grid.GetLength(1) - 1;

                        for (int col = grid.GetLength(1)-1; col > 0; col--)
                        {
                            if (grid[row, col] != 0)
                            {
                                grid[row, place] = grid[row, col];
                                grid[row, col] = 0;
                                place--;
                                Console.WriteLine(ConcateneGrid(grid));

                            }
                        }
                    }
                    break;
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
