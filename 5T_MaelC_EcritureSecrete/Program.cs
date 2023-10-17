using System.Text;

namespace _5T_MaelC_EcritureSecrete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char repeatProg;
            do
            {
                string phrase;
                string message;
                string aUser;

                Console.WriteLine("Veuillez entrer la phrase à crypter.");
                phrase = Console.ReadLine();

                ParseInCesar(phrase, out message);
                Console.WriteLine(message);
                do
                {
                    Console.WriteLine("Voulez-vous recommencer le programme ? O = Recommencer.");
                    aUser = Console.ReadLine();
                } while (!char.TryParse(aUser, out repeatProg));

            } while (char.ToUpper(repeatProg) == 'O');

        }


        static void ParseInCesar(string phrase, out string message)
        {
            char[] input = phrase.ToCharArray();
            char[] result = new char[input.Length];

            for (uint index = 0; index <= input.Length-1; index++){
                uint temp;

                input[index] = char.ToLower(input[index]);
                if (char.IsNumber(input[index]))
                {
                    Console.WriteLine(input[index]);
                    temp = Convert.ToChar(Convert.ToUInt16(input[index]));
                    temp = 10 - temp;
                    result[index] = temp;
                }

            }

            message = new string(result); 
            //message = new string(input);
        }
    }
}