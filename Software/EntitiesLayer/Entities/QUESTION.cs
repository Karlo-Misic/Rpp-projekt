namespace DataAccessLayer
{
    using EntitiesLayer.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("QUESTIONS")]
    public partial class QUESTION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUESTION()
        {
            GAME_QUESTIONS = new HashSet<GAME_QUESTIONS>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int questionID { get; set; }

        [Column("question")]
        [Required]
        [StringLength(50)]
        public string question { get; set; }

        public int categoryID { get; set; }

        public int difficultyID { get; set; }

        [Required]
        [StringLength(50)]
        public string correctAnswer { get; set; }

        [Required]
        [StringLength(50)]
        public string incorrectAnswer1 { get; set; }

        [Required]
        [StringLength(50)]
        public string incorrectAnswer2 { get; set; }

        [Required]
        [StringLength(50)]
        public string incorrectAnswer3 { get; set; }

        public virtual CATEGORy CATEGORy { get; set; }

        public virtual DIFFICULTy DIFFICULTy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GAME_QUESTIONS> GAME_QUESTIONS { get; set; }
    }
}
