using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5TT_ClaudeMael_Matrice
{
    public struct Methodes
    {

        public int[,] GenererMatrice(uint row, uint column)
        {
            Random random = new Random();
            int[,] grid = new int[row, column];
            for(int i = 0; i <= row-1; i++)
            {
                for (int j = 0; j <= column-1; j++)
                {
                    grid[i, j] = (int)random.Next(0, 20+1);
                }
            }
            return grid;
        }

        public bool AdditionMatrices(int[,] firstMatrice, int[,] secondMatrice, ref int[,] finalMatrice)
        {
            bool addition = true;
            if(firstMatrice.GetLength(0) == secondMatrice.GetLength(0) && firstMatrice.GetLength(1) == secondMatrice.GetLength(1))
            {
                for(int row = 0; row <= firstMatrice.GetLength(0)-1; row++)
                {
                    for(int column = 0; column <= firstMatrice.GetLength(1)-1; column++)
                    {
                        finalMatrice[row, column] = firstMatrice[row, column] + secondMatrice[row, column];
                    }
                }
            }
            else
            {
                addition = false;
            }
            return addition;
        }

        public void MultiplierMatrices(int[,] firstMatrice, int[,] secondMatrice, ref int[,] finalMatrice, out bool multiplied)
        {
            if(firstMatrice.GetLength(1) == secondMatrice.GetLength(0))
            {
                multiplied = true;
                for(int row = 0; row <= firstMatrice.GetLength(0)-1; row++)
                {
                    for(int column = 0; column <= secondMatrice.GetLength(1)-1; column++)
                    {
                        
                        for(int i = 0; i <= firstMatrice.GetLength(1)-1; i++)
                        {
                            finalMatrice[row, column] = firstMatrice[row, column] * secondMatrice[row, column];
                        }
                    }
                }
                

            }
            else
            {
                multiplied = false;
            }
        }


        public string ConcateneMatrice(int[,] grid)
        {
            string concatene = "";
            for (int row = 0; row <= grid.GetLength(0)-1; row++)
            {
                string ligne = "[";
                for (int column = 0; column <= grid.GetLength(1)-1; column++)
                {
                    ligne = ligne+ grid[row, column];
                    if (column != grid.GetLength(1) - 1)
                    {
                        ligne = ligne + ",";
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

 
        public void LireEntier(string question, out uint result)
        {
            Console.WriteLine(question);
            string nUser = Console.ReadLine();
            while(!uint.TryParse(nUser, out result))
            {
                Console.WriteLine(question);
                nUser = Console.ReadLine();
            }
        }
    }
}
