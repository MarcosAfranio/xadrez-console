using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabu;

namespace xadrez_console.xadrez
{
    class PartidaDeXadrez
    {
        public TabuleiroTabu tab { get; private set; }
        private int turno;
        private CorTabu jogadorAtual;
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new TabuleiroTabu(8, 8);
            turno = 1;
            jogadorAtual = CorTabu.Branca;
            terminada = false;
            colocarPecas();
        }
        public void executaMovimento(Posicao origem, Posicao destino)
        {
            PecaTabu p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            PecaTabu pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        private void colocarPecas()
        {
            tab.colocarPeca(new TorreXadrez(tab, CorTabu.Branca), new PosicaoXadrez('c', 1).toPosicao());
            tab.colocarPeca(new TorreXadrez(tab, CorTabu.Branca), new PosicaoXadrez('c', 2).toPosicao());
            tab.colocarPeca(new TorreXadrez(tab, CorTabu.Branca), new PosicaoXadrez('d', 2).toPosicao());
            tab.colocarPeca(new TorreXadrez(tab, CorTabu.Branca), new PosicaoXadrez('e', 2).toPosicao());
            tab.colocarPeca(new TorreXadrez(tab, CorTabu.Branca), new PosicaoXadrez('e', 1).toPosicao());
            tab.colocarPeca(new ReiXadrez(tab, CorTabu.Branca), new PosicaoXadrez('d', 1).toPosicao());

            tab.colocarPeca(new TorreXadrez(tab, CorTabu.Preta), new PosicaoXadrez('c', 7).toPosicao());
            tab.colocarPeca(new TorreXadrez(tab, CorTabu.Preta), new PosicaoXadrez('c', 8).toPosicao());
            tab.colocarPeca(new TorreXadrez(tab, CorTabu.Preta), new PosicaoXadrez('d', 7).toPosicao());
            tab.colocarPeca(new TorreXadrez(tab, CorTabu.Preta), new PosicaoXadrez('e', 7).toPosicao());
            tab.colocarPeca(new TorreXadrez(tab, CorTabu.Preta), new PosicaoXadrez('e', 8).toPosicao());
            tab.colocarPeca(new ReiXadrez(tab, CorTabu.Preta), new PosicaoXadrez('d', 8).toPosicao());
        }
    }
}
