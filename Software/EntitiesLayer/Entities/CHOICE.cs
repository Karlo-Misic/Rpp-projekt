namespace EntitiesLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("CHOICES")]
    public partial class CHOICE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int choiceID { get; set; }

        [Required]
        [StringLength(50)]
        public string choiceText { get; set; }

        public int correctChoice { get; set; }
    }
}
