namespace PsychologicalSupports.Models.Db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Self_esteem
    {
        [Key]
        [Column(Order = 0)]
        public long Self_esteemID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long StudentID { get; set; }

        [StringLength(50)]
        public string Indicator { get; set; }

        public virtual Student Student { get; set; }
    }
}
