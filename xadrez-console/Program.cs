
using xadrez_console.tabu;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            TabuleiroTabu tab = new TabuleiroTabu(8,8);
            
            Tela.imprimirTabuleiro(tab);


            Console.ReadLine();


        }
    }
}