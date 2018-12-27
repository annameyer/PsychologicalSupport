namespace PsychologicalSupports.Models.Db
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PersonaAnxietyScale
    {
        [Key]
        [Column(Order = 0)]
        public long PersonaAnxietyScaleID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        [StringLength(50)]
        public string School { get; set; }

        [StringLength(50)]
        public string Interpersonal { get; set; }

        [StringLength(50)]
        public string Self_assessment { get; set; }

        [StringLength(50)]
        public string General { get; set; }

        public virtual Student Student { get; set; }
    }
}
