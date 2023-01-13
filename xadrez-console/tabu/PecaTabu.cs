
namespace xadrez_console.tabu
{
    abstract class PecaTabu
    {
        public Posicao posicao { get; set; }
        public CorTabu cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public TabuleiroTabu tab { get; protected set; }


        public PecaTabu(TabuleiroTabu tab, CorTabu cor)
        {
            posicao = null;
            this.tab = tab;
            this.cor = cor;
            qteMovimentos = 0;
        }

        public void incrementarQteMovimentos()
        {
            qteMovimentos++;
        }

        public void decrementarQteMovimentos()
        {
            qteMovimentos--;
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for(int i = 0; i<tab.linhas; i++)
            {
                for(int j= 0; j<tab.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool movimentoPossivel(Posicao pos) 
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        public abstract bool[,] movimentosPossiveis();
       

        
    }
}
