using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Xml.Linq;
using System.Collections;
using System.Threading;

namespace LegalApp
{
    public class ExportParser
    {
        public ReportsData ReadFile(string path)
        {

            XmlDocument doc = new XmlDocument();
            Thread.Sleep(7000);
            doc.Load(path);

            // Prikazivanje svih čvorova u XML fajlu
            string exportRgx = "^export:";
            string statementRgx = "^export:is";

            List<Statement> statements = new List<Statement>();
            List<Penalty> penalties = new List<Penalty>();

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                if (Regex.IsMatch(node.Name, statementRgx))
                {
                    statements.Add(StatementParser(node));
                }
                else if(Regex.IsMatch(node.Name, exportRgx))
                {
                    penalties.Add(PenaltyParser(node));
                }
            }


            return new ReportsData(statements, penalties);
        }

        private Statement StatementParser(XmlNode node)
        {
            XmlNode defendantNode = SelectSingleNode(node, "export:defendant");
            string text = node.LocalName.Replace('_', ' ');           
            XmlNode positivityNode = SelectSingleNode(node, "defeasible:truthStatus");
            Statement statement = new Statement(defendantNode.InnerText, text, positivityNode.InnerText.Contains("positive"));
            return statement;
        }

        private Penalty PenaltyParser(XmlNode node)
        {
            string scope = node.LocalName.Replace('_', ' ');
            string value  =SelectSingleNode(node, "export:value").InnerText;
            bool positivityNode = SelectSingleNode(node, "defeasible:truthStatus").InnerText.Contains("positive");
            return new Penalty(scope, value, positivityNode);
        }

        private XmlNode SelectSingleNode(XmlNode node, string regex)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if(Regex.IsMatch(childNode.Name, regex)) { return childNode; }
            }
            return null;
        }
    }
}
