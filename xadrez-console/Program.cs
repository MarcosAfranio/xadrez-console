﻿
using xadrez_console.tabu;
using xadrez_console.xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Tratamento excecoes
            //try
            //{
            //    TabuleiroTabu tab = new TabuleiroTabu(8, 8);

            //    tab.colocarPeca(new TorreXadrez(tab, CorTabu.Preta), new Posicao(0, 0));
            //    tab.colocarPeca(new TorreXadrez(tab, CorTabu.Preta), new Posicao(1, 9));
            //    tab.colocarPeca(new ReiXadrez(tab, CorTabu.Preta), new Posicao(0, 2));


            //    Tela.imprimirTabuleiro(tab);
            //}
            //catch(TabuleiroException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //Console.ReadLine();
            #endregion

            PosicaoXadrez pos = new PosicaoXadrez('c', 7);

            //Console.WriteLine(pos);

            Console.WriteLine(pos.toPosicao());

            Console.ReadKey();


                
        }
    }
}