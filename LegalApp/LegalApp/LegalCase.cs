using LegalApp.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegalApp
{
    public class LegalCase
    {
        public string Defendant { get; set; }
        public string HasCoverageInMoney { get; set; }
        public int Euro { get; set; }
        public string Resource { get; set; }
        public string PossessionOfClearedCustomsGoods { get; set; }
        public string Location { get; set; }
        public string TransferOfWeaponOrAmmunition { get; set; }
        public string AvoidedPayingTaxes { get; set; }

        public string IsIndividual { get; set; }

        public LegalCase()
        {
            RestartFields();
        }

        private void RestartFields()
        {
            Defendant = HasCoverageInMoney = Resource = PossessionOfClearedCustomsGoods = Location = TransferOfWeaponOrAmmunition = AvoidedPayingTaxes = IsIndividual = "undefined";
            Euro = 0;
        }

        public void SmugglingDescription(string defendant, bool possessionOfClearedCustomsGoods, bool transferOfWeaponOrAmmunition, string resource)
        {
            RestartFields();
            Defendant = defendant;
            PossessionOfClearedCustomsGoods = possessionOfClearedCustomsGoods ? "yes" : "no";
            Location = "border";
            TransferOfWeaponOrAmmunition = transferOfWeaponOrAmmunition ? "yes" : "no";
            Resource = resource;
        }

        public void FundsWithoutCoverageDescription(string defendant, string resource, int euros, bool hasCoverageInMoney)
        {
            RestartFields();
            Defendant = defendant;
            Resource = resource;
            Euro = euros;
            HasCoverageInMoney = hasCoverageInMoney ? "yes" : "no";
        }

        public void TaxEvasionDescription(string defendant, int euros, bool avoidedPayingTaxes, bool isIndividual)
        {
            RestartFields();
            Defendant = defendant;
            Resource = "money";
            Euro = euros;
            AvoidedPayingTaxes = avoidedPayingTaxes ? "yes" : "no";
            IsIndividual = isIndividual ? "yes" : "no";
        }

        public string PrintData()
        {
            return "Defendant: " + Defendant + "\nHasCoverageInMoney: " + HasCoverageInMoney + "\nEuro: " + Euro + "\nResource: " + Resource + "\nPossessionOfClearedCustomsGoods: " + PossessionOfClearedCustomsGoods +
                "\nLocation: " + Location + "\nTransferOfWeaponOrAmmunition: " + TransferOfWeaponOrAmmunition + "\nAvoidedPayingTaxes: " + AvoidedPayingTaxes;
        }

        public string GenerateRDF()
        {
            return "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>\r\n" +
                "<rdf:RDF xmlns:rdf=\"http://www.w3.org/1999/02/22-rdf-syntax-ns#\"\r\n        " +
                "xmlns:rdfs=\"http://www.w3.org/2000/01/rdf-schema#\"\r\n        " +
                "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema#\"\r\n        " +
                "xmlns:lc=\"http://informatika.ftn.uns.ac.rs/legal-case.rdf#\">\r\n    " +
                "<lc:case rdf:about=\"http://informatika.ftn.uns.ac.rs/legal-case.rdf#case01\">\r\n        " +
                $"<lc:name>case 01</lc:name>\r\n        " +
                $"<lc:defendant>{Defendant}</lc:defendant>\r\n\t" +
                $"<lc:has_coverage_in_money>{HasCoverageInMoney}</lc:has_coverage_in_money>\r\n    " +
                $"<lc:euro rdf:datatype=\"http://www.w3.org/2001/XMLSchema#integer\">{Euro}</lc:euro>\r\n    " +
                $"<lc:resource>{Resource}</lc:resource>\r\n    " +
                $"<lc:possession_of_cleared_customs_goods>{PossessionOfClearedCustomsGoods}</lc:possession_of_cleared_customs_goods>\r\n    " +
                $"<lc:location>{Location}</lc:location>\r\n    " +
                $"<lc:transfer_of_weapon_or_ammunition>{TransferOfWeaponOrAmmunition}</lc:transfer_of_weapon_or_ammunition>\r\n    " +
                $"<lc:avoided_paying_taxes>{AvoidedPayingTaxes}</lc:avoided_paying_taxes>\r\n    " +
                $"<lc:individual>{IsIndividual}</lc:individual>\r\n    " +
                "</lc:case>\r\n</rdf:RDF>";
        }

        
    }
}
