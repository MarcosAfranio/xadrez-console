﻿using System;
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
        public int turno { get; private set; }
        public CorTabu jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<PecaTabu> pecas;
        private HashSet<PecaTabu> capturadas;
        public bool xeque { get; private set; }
        public PecaTabu vulneravelEnPassant { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new TabuleiroTabu(8, 8);
            turno = 1;
            jogadorAtual = CorTabu.Branca;
            terminada = false;
            xeque= false;
            vulneravelEnPassant = null;
            pecas = new HashSet<PecaTabu>();
            capturadas = new HashSet<PecaTabu>();
            colocarPecas();
        }

        public PecaTabu executaMovimento(Posicao origem, Posicao destino)
        {
            PecaTabu p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            PecaTabu pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);

            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, PecaTabu pecaCapiturada)
        {
            PecaTabu p = tab.retirarPeca(destino);
            p.decrementarQteMovimentos();

            if(pecaCapiturada != null)
            {
                tab.colocarPeca(pecaCapiturada, destino);
                capturadas.Remove(pecaCapiturada);
            }
            tab.colocarPeca(p, origem);
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            PecaTabu pecaCapurada = executaMovimento(origem, destino);

            if (estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapurada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }
            if (estaEmXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            turno++;
            mudaJogador();
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Nao existe peça na posição de origem escolhida!");
            }

            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }

            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possiveis!");
            }

        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).movimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void mudaJogador()
        {
            if (jogadorAtual == CorTabu.Branca)
            {
                jogadorAtual = CorTabu.Preta;
            }
            else
            {
                jogadorAtual = CorTabu.Branca;
            }
        }

        public HashSet<PecaTabu> pecasCapturadas(CorTabu cor)
        {
            HashSet<PecaTabu> aux= new HashSet<PecaTabu>();
            foreach(PecaTabu x in capturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<PecaTabu> pecasEmJogo(CorTabu cor)
        {
            HashSet<PecaTabu> aux = new HashSet<PecaTabu>();
            foreach (PecaTabu x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        private CorTabu adversaria (CorTabu cor)
        {
            if(cor == CorTabu.Branca)
            {
                return CorTabu.Preta;
            }
            else
            {
                return CorTabu.Branca;
            }
        }

        private PecaTabu rei(CorTabu cor)
        {
            foreach(PecaTabu x in pecasEmJogo(cor))
            {
                if(x is ReiXadrez)
                {
                    return x;
                }
            }
            return null;
        }

        public bool estaEmXeque(CorTabu cor)
        {
            PecaTabu R = rei(cor);
            if(R == null)
            {
                throw new TabuleiroException("Não tem Rei da cor " + cor + "no Tabuleiro!");
            }
            foreach(PecaTabu x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.posicao.linha, R.posicao.coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public void colocarNovaPeca(char coluna, int linha, PecaTabu peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        private void colocarPecas()
        {
            colocarNovaPeca('c', 1, new TorreXadrez(tab, CorTabu.Branca));
            colocarNovaPeca('c', 2, new TorreXadrez(tab, CorTabu.Branca));
            colocarNovaPeca('d', 2, new TorreXadrez(tab, CorTabu.Branca));
            colocarNovaPeca('e', 2, new TorreXadrez(tab, CorTabu.Branca));
            colocarNovaPeca('e', 1, new TorreXadrez(tab, CorTabu.Branca));
            colocarNovaPeca('d', 1, new ReiXadrez(tab, CorTabu.Branca));

            colocarNovaPeca('c', 7, new TorreXadrez(tab, CorTabu.Preta));
            colocarNovaPeca('c', 8, new TorreXadrez(tab, CorTabu.Preta));
            colocarNovaPeca('d', 7, new TorreXadrez(tab, CorTabu.Preta));
            colocarNovaPeca('e', 7, new TorreXadrez(tab, CorTabu.Preta));
            colocarNovaPeca('e', 8, new TorreXadrez(tab, CorTabu.Preta));
            colocarNovaPeca('d', 8, new ReiXadrez(tab, CorTabu.Preta));
        }
    }
}
