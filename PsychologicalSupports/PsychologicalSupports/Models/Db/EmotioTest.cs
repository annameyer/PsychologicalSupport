namespace PsychologicalSupports.Models.Db
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class EmotioTest
    {
        [Key]
        [Column(Order = 0)]
        public long EmotioTestID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        [StringLength(50)]
        public string PhysicalAggression { get; set; }

        [StringLength(50)]
        public string IndirectAggression { get; set; }

        [StringLength(50)]
        public string Irritability { get; set; }

        [StringLength(50)]
        public string Negativism { get; set; }

        [StringLength(50)]
        public string Touchiness { get; set; }

        [StringLength(50)]
        public string Suspicion { get; set; }

        [StringLength(50)]
        public string VerbalAggression { get; set; }

        [StringLength(50)]
        public string Guilt { get; set; }

        public virtual Student Student { get; set; }
    }
}
