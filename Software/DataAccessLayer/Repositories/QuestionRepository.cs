using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class QuestionRepository : Repository<QUESTION>
    {
        public QuestionRepository() : base(new DataBase())
        {

        }
        public override int Add(QUESTION entity, bool saveChanges = true)
        {
            bool questionExists = Entities.Any(q => q.question == entity.question);

            if (questionExists)
            {
                throw new AddQuestionException("The question already exists in the database!");
            }

            var category = Context.CATEGORIES.FirstOrDefault(c => c.name == entity.CATEGORy.name);
            var difficulty = Context.DIFFICULTIES.FirstOrDefault(d => d.name == entity.DIFFICULTy.name);

            var question = new QUESTION
            {
                question = entity.question,
                correctAnswer = entity.correctAnswer,
                CATEGORy = category,
                DIFFICULTy = difficulty,
                incorrectAnswer1 = entity.incorrectAnswer1,
                incorrectAnswer2 = entity.incorrectAnswer2,
                incorrectAnswer3 = entity.incorrectAnswer3
            };

            Entities.Add(question);
            return saveChanges ? SaveChanges() : 0;
        }
    }
}
