namespace _5TT_ClaudeMael_Matrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Methodes methodes = new Methodes();
            uint choice;
            uint rowsFirstMatrice;
            uint colsFirstMatrice;
            uint rowsSecondMatrice;
            uint colsSecondMatrice;
            char repeatProg;

            do
            {

                Console.WriteLine("Bienvenue dans le programme de traitement de matrice.");
                do
                {

                    methodes.LireEntier("\nChoisissez votre opération:" +
                        "\n" +
                        "\n0 - Générer aléatoirement une matrice" +
                        "\n1 - Additionner 2 matrices aléatoire" +
                        "\n2 - Multiplier 2 matrices aléatoire" +
                        "\n", out choice);
                Console.Clear();
                } while (!(choice <= 2));
                methodes.LireEntier("Combien de lignes voulez-vous dans votre matrice ?", out rowsFirstMatrice);
                methodes.LireEntier("Combien de colonnes voulez-vous dans votre matrice ?", out colsFirstMatrice);
                switch (choice)
                {
                    default:
                        int[,] randomMatrice = methodes.GenererMatrice(rowsFirstMatrice, colsFirstMatrice);
                        Console.Clear();
                        Console.WriteLine("\nVoici votre matrice générée aléatoirement (" + rowsFirstMatrice + "x"+colsFirstMatrice + "):\n" + methodes.ConcateneMatrice(randomMatrice));
                        break;
                    case 1:
                    
                        methodes.LireEntier("Combien de lignes voulez-vous dans votre deuxième matrice ?", out rowsSecondMatrice);
                        methodes.LireEntier("Combien de colonnes voulez-vous dans votre deuxième matrice ?", out colsSecondMatrice);

                        int[,] firstMatrice = methodes.GenererMatrice(rowsFirstMatrice, colsFirstMatrice);
                        int[,] secondMatrice = methodes.GenererMatrice(rowsSecondMatrice, colsSecondMatrice);
                        int[,] finalMatrice = new int[firstMatrice.GetLength(0), firstMatrice.GetLength(1)];
                        bool addition = methodes.AdditionMatrices(firstMatrice, secondMatrice, ref finalMatrice);
                        Console.Clear();
                        if (addition)
                        {

                            Console.WriteLine("Matrice n°1:\n" +
                            
                                methodes.ConcateneMatrice(firstMatrice) +
                                "\n" +
                                "\nMatrice n°2:\n" +
                           
                                methodes.ConcateneMatrice(secondMatrice) +
                                "\n" +
                                "\nRésultat de matrice n°1 + matrice n°2" +
                                "\n" +
                                methodes.ConcateneMatrice(finalMatrice));
                        }
                        else
                        {
                            Console.WriteLine("Il est impossible d'additionner 2 matrices de dimensions différentes.");
                        }
                    
                        break;
                    case 2:
                        methodes.LireEntier("Combien de lignes voulez-vous dans votre deuxième matrice ?", out rowsSecondMatrice);
                        methodes.LireEntier("Combien de colonnes voulez-vous dans votre deuxième matrice ?", out colsSecondMatrice);
                        firstMatrice = methodes.GenererMatrice(rowsFirstMatrice, colsFirstMatrice);
                        secondMatrice = methodes.GenererMatrice(rowsSecondMatrice, colsSecondMatrice);
                        finalMatrice = new int[firstMatrice.GetLength(0), firstMatrice.GetLength(1)];
                        methodes.MultiplierMatrices(firstMatrice, secondMatrice, ref finalMatrice, out bool multiplied);
                        Console.Clear();
                        if (multiplied)
                        {
                            Console.WriteLine("Matrice n°1:\n" +
                            
                                methodes.ConcateneMatrice(firstMatrice) +
                                "\n" +
                                "\nMatrice n°2:\n" +
                            
                                methodes.ConcateneMatrice(secondMatrice) +
                                "\n" +
                                "\nRésultat de matrice n°1 * matrice n°2" +
                                "\n" +
                                methodes.ConcateneMatrice(finalMatrice));
                        }
                        else
                        {
                            Console.WriteLine("Il est impossible de multiplier ces 2 matrices.");
                        }
                        break;
                    } 
                Console.WriteLine("\n\nVoulez-vous recommencer le programme ? O = Oui");
                string nUser = Console.ReadLine();
                while(!char.TryParse(nUser, out repeatProg))
                {
                    Console.WriteLine("Voulez-vous recommencer le programme ?");
                    nUser = Console.ReadLine();
                }
                Console.Clear();


            }while (char.ToUpper(repeatProg) == 'O');


        }
    }
}