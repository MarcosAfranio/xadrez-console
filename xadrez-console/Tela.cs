using System.Security.Authentication;
using xadrez_console.tabu;
using xadrez_console.xadrez;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno:  " + partida.turno);
            Console.WriteLine("Agardando jogada:  " + partida.jogadorAtual);
            if (partida.xeque)
            {
                Console.WriteLine("XEQUE!");
            }
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças Capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(CorTabu.Branca));
            Console.Write("Pretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            imprimirConjunto(partida.pecasCapturadas(CorTabu.Preta));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<PecaTabu> conjunto)
        {
            Console.Write("[");
            foreach (PecaTabu x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("]");
        }

        public static void imprimirTabuleiro(TabuleiroTabu tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.colunas; j++)
                {
                    imprimirPeca(tab.peca(i, j));

                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirTabuleiro(TabuleiroTabu tab, bool[,] posicoePossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;

            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoePossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }

                    imprimirPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;

                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + " ");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(PecaTabu peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == CorTabu.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}


