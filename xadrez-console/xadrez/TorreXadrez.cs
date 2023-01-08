using System;
using xadrez_console.tabu;

namespace xadrez_console.xadrez
{
    class TorreXadrez : PecaTabu
    {
        public TorreXadrez(TabuleiroTabu tab, CorTabu cor) : base(tab, cor) { }
        public override string ToString()
        {
            return "T";
        }
    }
}
