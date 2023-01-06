
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
        public void colocarPeca(PecaTabu p, Posicao pos)
        {
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }
    }
}
