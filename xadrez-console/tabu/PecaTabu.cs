


namespace xadrez_console.tabu
{
    class PecaTabu
    {
        public Posicao posicao { get; set; }
        public CorTabu cor { get; protected set; }
        public int qteMovimentos { get; protected set; }
        public TabuleiroTabu tab { get; protected set; }


        public PecaTabu(CorTabu cor, TabuleiroTabu tab)
        {
            posicao = null;
            this.cor = cor;
            this.tab = tab;
            qteMovimentos = 0;
        }
    }
}
