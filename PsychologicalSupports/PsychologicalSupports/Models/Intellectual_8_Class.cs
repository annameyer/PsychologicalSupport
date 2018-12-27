namespace PsychologicalSupports.Models.Db
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Intellectual_8_Class
    {
        [Key]
        [Column(Order = 0)]
        public long Intellectual_8_ClassID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        [StringLength(50)]
        public string InterestMap { get; set; }

        [StringLength(50)]
        public string RecommendedProfile { get; set; }

        public virtual Student Student { get; set; }
    }
}
