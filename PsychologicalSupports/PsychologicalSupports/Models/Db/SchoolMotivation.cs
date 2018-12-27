namespace PsychologicalSupports.Models.Db
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class SchoolMotivation
    {
        [Key]
        [Column(Order = 0)]
        public long SchoolMotivationID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        [StringLength(50)]
        public string StudyInClass { get; set; }

        [StringLength(50)]
        public string TestFamilyStudiesLevel { get; set; }

        [StringLength(50)]
        public string CognitiveInterest { get; set; }

        [StringLength(50)]
        public string TesMotivationAchievementstLevel { get; set; }

        [StringLength(50)]
        public string Classmates { get; set; }

        [StringLength(50)]
        public string Pedagogues { get; set; }

        [StringLength(50)]
        public string ByParents { get; set; }

        [Required]
        [StringLength(50)]
        public string FromTheSideOfTheSchool { get; set; }

        [StringLength(50)]
        public string FromTheSideOfTheFamily { get; set; }

        [StringLength(50)]
        public string AwarenessOfSocialNecessity { get; set; }

        [StringLength(50)]
        public string CommunicationMotif { get; set; }

        [StringLength(50)]
        public string ExtracurricularSchoolMotivation { get; set; }

        [StringLength(50)]
        public string TheMotiveOfSelf_Realization { get; set; }

        public virtual Student Student { get; set; }
    }
}
