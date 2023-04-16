using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalApp
{
    public class SolutionExport
    {
        private int smuggling_lvl = 0;
        private string defendant;
        private bool positivity;
        private List<string> positive_penalties = new List<string>();
        private List<string> negative_penalties = new List<string>();
    }
    /*
     <export:is_smuggling_lvl_1 rdf:about='&export;is_smuggling_lvl_11'>
     <export:defendant>Test</export:defendant>
     <defeasible:truthStatus>defeasibly-proven-positive</defeasible:truthStatus>
     <defeasible:proof rdf:datatype='&xsd;anyURI'>&proof-export;proof1</defeasible:proof>
</export:is_smuggling_lvl_1>

<export:to_jail_min rdf:about='&export;to_jail_min1'>
     <export:value>6</export:value>
     <defeasible:truthStatus>defeasibly-proven-positive</defeasible:truthStatus>
     <defeasible:proof rdf:datatype='&xsd;anyURI'>&proof-export;proof2</defeasible:proof>
</export:to_jail_min>

<export:to_jail_max rdf:about='&export;to_jail_max1'>
     <export:value>5</export:value>
     <defeasible:truthStatus>defeasibly-proven-positive</defeasible:truthStatus>
     <defeasible:proof rdf:datatype='&xsd;anyURI'>&proof-export;proof3</defeasible:proof>
</export:to_jail_max>
     */
}
