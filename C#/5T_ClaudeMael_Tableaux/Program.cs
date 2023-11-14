namespace _5TTI_ClaudeMael_Tableaux
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nUser;
            uint number;
            int intervalMin, intervalMax;
            int[] table;
            int[] tablePair, tableImpair;
            char repeatProg;

            do
            {

                LireUInt("Veuillez entrer la table du tableau.",out number);
                do
                {
                    LireInt("Veuillez entrer le nombre minimal de l'interval", out intervalMin);
                    LireInt("Veuillez entrer le nombre maximal de l'interval", out intervalMax);
                    if(!(intervalMin < intervalMax))
                    {
                        Console.WriteLine("Entrées incorrectes, votre interval minimum est supérieur à votre interval maximum.");
                    }
                } while (!(intervalMin < intervalMax));

                RandomTable(number, intervalMin, intervalMax, out table);

                Console.WriteLine("Voici votre tableau généré aléatoirement : \n" + string.Join(", ", table));


                TablePairImpair(table, out tablePair, out tableImpair);

                Console.WriteLine("Voici votre tableau pair:\n" + string.Join(", ", tablePair) + "\nVoici votre tableau impair:\n" + string.Join(", ", tableImpair));

                Console.WriteLine("Voulez-vous recommencer le programme ? O = Oui");
                nUser = Console.ReadLine();
                while(!(char.TryParse(nUser, out repeatProg)))
                {
                    Console.WriteLine("Entrée incorrecte | O = Oui");
                    nUser = Console.ReadLine();
                }
            } while (char.ToUpper(repeatProg) == 'O');
        }

        static void RandomTable(uint number, int intervalMin, int intervalMax, out int[] table) 
        {
            table = new int[number];
            Random random = new Random();
            for(int index = 0; index < number; index++)
            {
                table[index] = random.Next(intervalMin, intervalMax+1);
            }
        }

        static void TablePairImpair(int[] table, out int[] tablePair, out int[] tableImpair)
        {
            tablePair = new int[table.Length];
            tableImpair = new int[table.Length];
            int pairIndex = 0;
            int impairIndex = 0;
            for(int index = 0; index < table.Length; index++)
            {
                tablePair[index] = 0;
                tableImpair[index] = 0;
                if (table[index] % 2  == 0)
                {
                    tablePair[pairIndex] = table[index];
                    pairIndex++;
                }
                else
                {
                    tableImpair[impairIndex] = table[index];
                    impairIndex++;
                }
            }
        }

        static void LireInt(string question, out int n)
        {
            Console.WriteLine(question);
            string nUser = Console.ReadLine();

            while(!(int.TryParse(nUser, out n)))
            {
                Console.WriteLine(question);
                nUser = Console.ReadLine();
            }
        }

        static void LireUInt(string question, out uint n)
        {
            Console.WriteLine(question);
            string nUser = Console.ReadLine();

            while (!(uint.TryParse(nUser, out n)))
            {
                Console.WriteLine(question);
                nUser = Console.ReadLine();
            }
        }
    }
}