namespace PsychologicalSupports.Models.Db
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Intellectual_7_Class
    {
        [Key]
        [Column(Order = 0)]
        public long Intellectual_7_ClassID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        public int? IQ { get; set; }

        [StringLength(50)]
        public string Level { get; set; }

        public double? AveragePointСommon { get; set; }

        public double? AveragePointMath { get; set; }

        public virtual Student Student { get; set; }
    }
}
