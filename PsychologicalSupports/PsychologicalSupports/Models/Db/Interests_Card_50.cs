namespace PsychologicalSupports.Models.Db
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Interests_Card_50
    {
        [Key]
        [Column(Order = 0)]
        public long Interests_Card_50ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        [StringLength(50)]
        public string PhysicsMathematics { get; set; }

        [StringLength(50)]
        public string ChemistryBiology { get; set; }

        [StringLength(50)]
        public string RadioEngineeringElectronics { get; set; }

        [StringLength(50)]
        public string MechanicsDesign { get; set; }

        [StringLength(50)]
        public string GeographyGeology { get; set; }

        [StringLength(50)]
        public string LiteratureArt { get; set; }

        [StringLength(50)]
        public string HistoryPolitics { get; set; }

        [StringLength(50)]
        public string PedagogyMedicine { get; set; }

        [StringLength(50)]
        public string EntrepreneurshiHomeEconomics { get; set; }

        [StringLength(50)]
        public string SportsMilitary { get; set; }

        public virtual Student Student { get; set; }
    }
}
