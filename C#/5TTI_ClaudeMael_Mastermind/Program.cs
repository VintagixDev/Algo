using System.Diagnostics;

namespace _5TTI_ClaudeMael_Mastermind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nUser;
            char repeatProg;

            do
            {
                byte tentatives = 0;
                Boolean isFound = false;
                byte[] combinaison;
                byte[] userCombinaison;


                GenererCombinaison(out combinaison);
                Console.WriteLine(string.Join(", ",combinaison));

                while(!(isFound == true || tentatives >= 10))
                {
                    ReadProposition(out userCombinaison);


                    if (string.Join("",combinaison) == string.Join("",userCombinaison))
                    {
                        isFound = true;
                    }
                    else
                    {
                        CheckPionsBienPlaces(userCombinaison, combinaison, out byte[] tempCombinaison, out byte pionsBienPlaces);
                        CheckPionsMalPlaces(userCombinaison, combinaison, tempCombinaison, out byte pionsMalPlaces);
                        Console.WriteLine("Nombre de pions bien placés : " + pionsBienPlaces + "\nNombre de pions mal placés :" + pionsMalPlaces + "\n\nNombre de tentatives restantes: "+ (9-tentatives));
                    }
                    tentatives++;
                }
                Console.WriteLine("Jeu Fini\n\n------------\n" +
                    "Voulez-vous recommencer le jeu ? O = Oui");
                nUser = Console.ReadLine();
                while(!char.TryParse(nUser, out repeatProg)){
                    Console.WriteLine("Entrée incorrecte  O = Oui");
                    nUser = Console.ReadLine();
                }
            } while (char.ToUpper(repeatProg) == 'O');
        }

        static void GenererCombinaison(out byte[] combinaison)
        {
            byte[] combinaisonAGenerer = new byte[4];
            Random random = new Random();
            for (int i = 0; i <= 3; i++)
            {
                combinaisonAGenerer[i] = (byte)random.Next(1, 7);
            }
            combinaison = combinaisonAGenerer;
        }

        static void ReadProposition(out byte[] userCombinaison)
        {
            byte[] _userCombinaison = new byte[4];
            Console.WriteLine("Couleurs: Rouge = 1 | Bleu = 2 | Vert = 3 | Jaune = 4 | Blanc = 5 | Noir = 6");
            for (int i = 0; i <= 3; i++)
            {
                byte color;
                LireByte("Devinez la couleur numéro " + (i+1) + " de la combinaison",
                    
                    out color);
                _userCombinaison[i] = color;

            }
            userCombinaison = _userCombinaison;
        }

        static void CheckPionsMalPlaces(byte[] userCombinaison, byte[] combinaison, byte[] tempCombinaison, out byte pionsMalPlaces)
        {
            pionsMalPlaces = 0;
            Console.WriteLine("\nCheckPionsMalPlaces:" + string.Join(", ", tempCombinaison) + "\n");
            for (int i = 0; i < 4; i++)
            {
                if (tempCombinaison[i] != 0)
                {
                    if (tempCombinaison.Contains(userCombinaison[i]))
                    {
                        Console.WriteLine("B "+i);
                        if (tempCombinaison[i] != userCombinaison[i])
                        {
                            pionsMalPlaces++;
                            for(int removeIndex = 0; removeIndex < 4; removeIndex++) // BUG
                            {
                                if (combinaison[removeIndex] == userCombinaison[i])
                                {
                                    tempCombinaison[removeIndex] = 0;
                                }
                            }
                        }
                    }
                }
                
            }
        }
        static void CheckPionsBienPlaces(byte[] userCombinaison, byte[] combinaison, out byte[] tempCombinaison, out byte pionsBienPlaces)
        {
            pionsBienPlaces = 0;
            byte[] _tempCombinaison = new byte[combinaison.Length];
            for(int i = 0; i < 4; i++)
            {
                _tempCombinaison[i] = combinaison[i];
            }
            Console.WriteLine("\nCheckPionsBienPlaces: "+string.Join(", ", _tempCombinaison)+"\n");
            for (int i = 0; i < 4; i++)
            {
                if (combinaison[i] == userCombinaison[i])
                {
                    pionsBienPlaces++;
                    _tempCombinaison[i] = 0;
                }
            }
            tempCombinaison = _tempCombinaison;
        }

        static void LireByte(string question, out byte color)
        {
            Console.WriteLine(question);
            string nUser = Console.ReadLine();
                while (!byte.TryParse(nUser, out color) && (color > 0 && color < 7))
                {
                    Console.WriteLine("Entrée incorrecte, \n" + question);
                    nUser = Console.ReadLine();

                }

        
        }
    }
}