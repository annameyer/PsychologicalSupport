namespace PsychologicalSupports.Models.Db
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AveragePoint
    {
        [Key]
        [Column(Order = 0)]
        public long AveragePointID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        public double? AveragePoint_6 { get; set; }

        public double? AveragePoint_7 { get; set; }

        public double? AveragePoint_8 { get; set; }

        public double? AveragePoint_9 { get; set; }

        public virtual Student Student { get; set; }
    }
}
