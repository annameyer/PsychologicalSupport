namespace PsychologicalSupports.Models.Db
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ClassroomRelationship
    {
        [Key]
        [Column(Order = 0)]
        public long ClassroomRelationshipsID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        [StringLength(50)]
        public string IGS_Sishora { get; set; }

        [StringLength(50)]
        public string Sociometry { get; set; }

        public virtual Student Student { get; set; }
    }
}
