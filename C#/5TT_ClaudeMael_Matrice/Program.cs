namespace _5TT_ClaudeMael_Matrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Methodes methodes = new Methodes();

            int[,] firstMatrice = methodes.GenererMatrice(5, 3);
            int[,] secondMatrice = methodes.GenererMatrice(5, 3);
            Console.WriteLine(methodes.ConcateneMatrice(firstMatrice) + "\n\n");
            Console.WriteLine(methodes.ConcateneMatrice(secondMatrice) + "\n\n");
            int[,] finalMatrice = new int[firstMatrice.GetLength(0), firstMatrice.GetLength(1)];
            bool addition = methodes.AdditionMatrices(firstMatrice, secondMatrice, ref finalMatrice);
            if(addition)
            {
                Console.WriteLine(methodes.ConcateneMatrice(finalMatrice));
            }
            else
            {
                Console.WriteLine("non");
            }
        }
    }
}