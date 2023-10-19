using System.Text;

namespace _5T_MaelC_EcritureSecrete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char repeatProg; // Répéter le programme
            do
            {
                string phrase; // Phrase à crypter entrée par l'utilisateur
                string message; // Message crypté a renvoyer
                string aUser; // Entrée utilisateur pour répéter le programme

                // Lire entrée utilisateur
                Console.WriteLine("Veuillez entrer la phrase à crypter.");
                phrase = Console.ReadLine();

                ParseInCesar(phrase, out message);

                Console.WriteLine(message);

                // Répéter le programme
                do
                {
                    Console.WriteLine("Voulez-vous recommencer le programme ? O = Recommencer.");
                    aUser = Console.ReadLine();
                } while (!char.TryParse(aUser, out repeatProg));

            } while (char.ToUpper(repeatProg) == 'O');

        }

        /// <summary>
        /// Encoder une suite de caractère entrée par l'utilisateur en décallant chaque caractère de 2 dans l'alphabet.
        /// Si c'est un nombre, prendre son complément de 10
        /// Si c'est un espace, remplacer par le signe +
        /// </summary>
        /// <param name="phrase">défini // Phrase à crypter entrée par l'utilisateur</param>
        /// <param name="message">Message crypté à renvoyer</param>
        static void ParseInCesar(string phrase, out string message)
        {
            char[] input = phrase.ToCharArray();
            string result = "";

            for (uint index = 0; index <= input.Length-1; index++){
                int temp;

                input[index] = char.ToLower(input[index]);

                // Vérifier si le caractère est un nombre.
                if (char.IsNumber(input[index])) 
                {
                    temp = 10 - int.Parse(input[index].ToString()); // Calculer le complément de 10
                    result += temp;
                }
                else
                {
                    if (input[index] == ' ')
                    {
                        result += "+";
                    }
                    else
                    {
                        // Vérifier si le caractère est bien une lettre
                        if ((int)input[index] >= (int)'a' && ((int)input[index] <= (int)'z'))
                        {
                            // Vérifier si le caractère + 2 dépasse la lettre z
                            if ((int)input[index]+2 > (int)'z')
                            {
                                result += Convert.ToChar((int)(input[index] - 24));
                            }
                            else
                            {
                                result += Convert.ToChar((int)input[index] + 2);
                            }
                        }
                        else
                        {
                            result += input[index];
                        }
                    }
                }

            }
            message = result;

        }
    }
}