namespace PsychologicalSupports.Models.Db
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class InterestsInSchoolSubject
    {
        [Key]
        [Column(Order = 0)]
        public long InterestsInSchoolSubjectsID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        [StringLength(50)]
        public string Russian { get; set; }

        [StringLength(50)]
        public string Belorussian { get; set; }

        [StringLength(50)]
        public string Physics { get; set; }

        [StringLength(50)]
        public string Story { get; set; }

        [StringLength(50)]
        public string SocialScientist { get; set; }

        [StringLength(50)]
        public string Biology { get; set; }

        [StringLength(50)]
        public string Chemistry { get; set; }

        [StringLength(50)]
        public string ComputerScience { get; set; }

        [StringLength(50)]
        public string English { get; set; }

        public virtual Student Student { get; set; }
    }
}
