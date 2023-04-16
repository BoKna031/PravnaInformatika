using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalApp
{
    public class ReportsData
    {
        public string Defendant { get; private set; }

        public List<Statement> Statements { get; private set; }
        public List<Penalty> Penalties { get; private set; }

        public ReportsData(List<Statement> statements, List<Penalty> penalties) {
            if (statements == null) return;
            Statements = statements;
            Penalties = penalties;
            Defendant = statements[0].Defendant;
        }
    }
}
