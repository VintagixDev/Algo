using System.Text;

namespace _5T2024_ClaudeMael_2048
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Constantes
            const uint maxGridSize = 6;
            // Initialisation des variables
            Methods methods = new Methods(); // Instantiation de la class Methods
            byte gridSize; // Taille de la grille de jeu
            uint[,] grid;
            bool gameState;

            // Message de bienvenue
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("██████╗  ██████╗ ██╗  ██╗ █████╗ \r\n" +
                              "╚════██╗██╔═████╗██║  ██║██╔══██╗\r\n" +
                              " █████╔╝██║██╔██║███████║╚█████╔╝\r\n" +
                              "██╔═══╝ ████╔╝██║╚════██║██╔══██╗\r\n" +
                              "███████╗╚██████╔╝     ██║╚█████╔╝\r\n" +
                              "╚══════╝ ╚═════╝      ╚═╝ ╚════╝ \r\n- par Claude Maël");

            do
            {

                methods.LireByte("Veuillez entrer la taille de votre grille de jeu (min 4, max " + maxGridSize + ")", out gridSize);
            } while (!(gridSize >= 4 && gridSize <= maxGridSize));

            methods.CreateGrid(gridSize, out grid);
            Console.WriteLine(methods.ConcateneGrid(grid));

            do
            {
                gameState = true;
                methods.CreateBlock(ref grid);
            } while (gameState == true);

        }
    }
}