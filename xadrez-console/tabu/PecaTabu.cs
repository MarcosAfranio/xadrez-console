
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

        public abstract bool[,] movimentosPossiveis();
       

        
    }
}
