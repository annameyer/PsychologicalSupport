namespace PsychologicalSupports.Models.Db
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class PersonalProtagonistAizenko
    {
        [Key]
        [Column(Order = 0)]
        public long PersonaAnxietyScaleID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        [StringLength(50)]
        public string Temperament { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public virtual Student Student { get; set; }
    }
}
