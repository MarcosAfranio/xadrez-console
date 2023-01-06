using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xadrez_console.tabu;

namespace xadrez_console.xadrez
{
    class ReiXadrez : PecaTabu
    {
        public ReiXadrez(TabuleiroTabu tab, CorTabu cor) : base(tab, cor) { }
        public override string ToString()
        {
            return "R";
        }
    }
}
