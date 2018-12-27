namespace PsychologicalSupports.Models.Db
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Mindset
    {
        [Key]
        [Column(Order = 0)]
        public long MindsetID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        [StringLength(50)]
        public string Subject_Effective { get; set; }

        [StringLength(50)]
        public string AbstractSymbolic { get; set; }

        [StringLength(50)]
        public string Verbal_Logical { get; set; }

        [StringLength(50)]
        public string Visually_Shaped { get; set; }

        [StringLength(50)]
        public string Creativity { get; set; }

        public virtual Student Student { get; set; }
    }
}
