
using xadrez_console.tabu;
using xadrez_console.xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            TabuleiroTabu tab = new TabuleiroTabu(8,8);

            tab.colocarPeca(new TorreXadrez(tab, CorTabu.Preta), new Posicao(0,0));
            tab.colocarPeca(new TorreXadrez(tab, CorTabu.Preta), new Posicao(1,3));
            tab.colocarPeca(new ReiXadrez(tab, CorTabu.Preta), new Posicao(2,4));


            Tela.imprimirTabuleiro(tab);


            Console.ReadLine();


        }
    }
}