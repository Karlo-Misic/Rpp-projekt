namespace EntitiesLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    public partial class GAME_SESSIONS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GAME_SESSIONS()
        {
            GAME_QUESTIONS = new HashSet<GAME_QUESTIONS>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int sessionID { get; set; }

        public int userID { get; set; }

        [Column(TypeName = "date")]
        public DateTime startTime { get; set; }

        [Column(TypeName = "date")]
        public DateTime endTime { get; set; }

        [Required]
        [StringLength(50)]
        public string gameMode { get; set; }

        public int score { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GAME_QUESTIONS> GAME_QUESTIONS { get; set; }

        public virtual USER USER { get; set; }
    }
}
