using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalApp
{
    public class Statement
    {
        public string Defendant { get; private set; }
        public string Text { get; private set; }
        public bool Possitive { get; private set; }
        public Statement(string def, string txt, bool pos) { Defendant = def; Text = txt; Possitive = pos; }
    }
}
