using System.Reflection;

namespace _5TT_ClaudeMael_AdressesIP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const int maxLength = 20;

            byte[,] adressesIp = new byte[maxLength, 3];
            int pointer = 0;
           

            Methodes methodes = new Methodes();

            methodes.LireAdresseIp(out byte[] ip);
            Console.WriteLine(methodes.ConcateneAdresse(ip));

        }
    }
}