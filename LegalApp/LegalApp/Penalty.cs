using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalApp
{
    public class Penalty
    {
        public string Scope { get; private set; }

        public string Value { get; private set; }
        public bool Possitive { get; private set; }
        public Penalty(string scope, string value, bool pos) { Scope = scope; Value = value; Possitive = pos; }
    }
}
