using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Entities
{
    public class AddQuestionException : ApplicationException
    {
        public AddQuestionException(string message) : base(message)
        {

        }
    }
}
