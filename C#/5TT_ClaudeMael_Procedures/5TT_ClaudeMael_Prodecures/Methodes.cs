using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5TT_ClaudeMael_Prodecures
{
    public struct Methodes
    {

        public int GenererNombre(int min, int max)
        {
            Random random = new Random();
            int nombre = random.Next(min, max+1);
            return nombre;
        }

        public void GenererTableau(int n, out int[] table)
        {
            table = new int[n];
            for (int i = 0; i < n; i++)
            {
                table[i] = GenererNombre(1, 6);
            }
        }

        public string Concatener(int[] table)
        {
            string message = "";
            for(int i = 0; i < table.Length; i++)
            {
                if (i < table.Length-1)
                {
                    message += table[i] + "-";
                }
                else
                {
                    message += table[i];
                }
            }
            return message;
        }

        public void LireEntier(string question, out int nombre)
        {
            string nUser;
            Console.WriteLine(question);
            nUser = Console.ReadLine();
            while(!int.TryParse(nUser, out nombre))
            {
                Console.WriteLine("Entrée invalide.\n" + question);
                nUser = Console.ReadLine();
            }
        }



    }
}
