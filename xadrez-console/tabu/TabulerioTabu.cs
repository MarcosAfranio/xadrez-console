
namespace xadrez_console.tabu
{
    class TabuleiroTabu
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private PecaTabu[,] pecas;

        public TabuleiroTabu(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new PecaTabu[linhas, colunas];
        }

        public PecaTabu peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public PecaTabu peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }

        public void colocarPeca(PecaTabu p, Posicao pos)
        {
            if (existePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça na posição!");
            }
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public bool posicaoValida(Posicao pos)
        {
            if(pos.linha <0 || pos.linha >= linhas || pos.coluna <0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao pos)
        {
            if (!posicaoValida(pos))
            {
                throw new TabuleiroException("Posição Invalida");
            }
        }

    }
}
