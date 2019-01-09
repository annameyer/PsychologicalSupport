using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PsychologicalSupports.Models.ModelUI
{
    public class Interests_Card_50UI
    {
        public long StudentID { get; set; }
        public string PhysicsMathematics { get; set; }
        public string ChemistryBiology { get; set; }
        public string RadioEngineeringElectronics { get; set; }
        public string MechanicsDesign { get; set; }
        public string GeographyGeology { get; set; }
        public string LiteratureArt { get; set; }
        public string HistoryPolitics { get; set; }
        public string PedagogyMedicine { get; set; }
        public string EntrepreneurshiHomeEconomics { get; set; }
        public string SportsMilitary { get; set; }

        public virtual Student Student { get; set; }
    }
}