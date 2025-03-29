using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntitiesLayer.Entities
{
    [Table("USER_STATISTICS")]
    public partial class USER_STATISTICS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER_STATISTICS()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("USER")]
        public int userID { get; set; }

        [Required]
        [StringLength(50)]
        public string category { get; set; }

        [Required]
        public int correctAnswers { get; set; }

        [Required]
        [DefaultValue(10)]
        public int totalQuestions { get; set; }

        [Required]
        [StringLength(100)]
        public string mostAnsweredQuestion { get; set; }

        [Required]
        public double correctPercentage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual USER USER { get; set; }
    }
}
