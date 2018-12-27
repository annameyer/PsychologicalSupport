namespace PsychologicalSupports.Models.Db
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Interests_Card_145
    {
        [Key]
        [Column(Order = 0)]
        public long Interests_Card_145ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        [StringLength(50)]
        public string Biology { get; set; }

        [StringLength(50)]
        public string Geography { get; set; }

        [StringLength(50)]
        public string Geology { get; set; }

        [StringLength(50)]
        public string TheMedicine { get; set; }

        [StringLength(50)]
        public string LightAndFoodIndustry { get; set; }

        [StringLength(50)]
        public string Physics { get; set; }

        [StringLength(50)]
        public string Chemistry { get; set; }

        [StringLength(50)]
        public string EngineeringMechanics { get; set; }

        [StringLength(50)]
        public string ElectricalEngineeringRadioEngineering { get; set; }

        [StringLength(50)]
        public string MaterialHandling { get; set; }

        [StringLength(50)]
        public string InformationTechnology { get; set; }

        [StringLength(50)]
        public string Psychology { get; set; }

        [StringLength(50)]
        public string Building { get; set; }

        [StringLength(50)]
        public string Tranport { get; set; }

        [StringLength(50)]
        public string MilitarySpecialties { get; set; }

        [StringLength(50)]
        public string Story { get; set; }

        [StringLength(50)]
        public string Literature { get; set; }

        [StringLength(50)]
        public string Journalism { get; set; }

        [StringLength(50)]
        public string Sociology { get; set; }

        [StringLength(50)]
        public string Pedagogy { get; set; }

        [StringLength(50)]
        public string Right { get; set; }

        [StringLength(50)]
        public string ServiceSector { get; set; }

        [StringLength(50)]
        public string Maths { get; set; }

        [StringLength(50)]
        public string Economy { get; set; }

        [StringLength(50)]
        public string ForeignLanguages { get; set; }

        [StringLength(50)]
        public string Art { get; set; }

        [StringLength(50)]
        public string Music { get; set; }

        [StringLength(50)]
        public string Sport { get; set; }

        public virtual Student Student { get; set; }
    }
}
