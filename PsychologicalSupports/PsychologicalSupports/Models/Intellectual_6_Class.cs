namespace PsychologicalSupports.Models.Db
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class Intellectual_6_Class
    {
        [Key]
        [Column(Order = 0)]
        public long Intellectual_6_ClassID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        public int? TestResult { get; set; }

        [StringLength(50)]
        public string TestLevel { get; set; }

        public double? AveragePoint { get; set; }
    }
}
