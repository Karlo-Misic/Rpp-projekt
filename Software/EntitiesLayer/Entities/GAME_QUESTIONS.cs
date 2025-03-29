using DataAccessLayer;

namespace EntitiesLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    public partial class GAME_QUESTIONS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int isCorrect { get; set; }

        public int sessionID { get; set; }

        public int questionID { get; set; }

        public virtual QUESTION QUESTION { get; set; }

        public virtual GAME_SESSIONS GAME_SESSIONS { get; set; }
    }
}
