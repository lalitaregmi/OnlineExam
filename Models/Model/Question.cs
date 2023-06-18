using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Question
    {
        public string Flag { get; set; }
        public string UserID { get; set; }
        public string CourseID { get; set; }
        public string Questions{ get; set; }
        public string QType { get; set; }
        public string QChoice { get; set; }
        public string QAns { get; set; }
        public string Point { get; set; }
        public string QuestionID{ get; set; }
        public List<QuestionInfo> Values { get; set; }

    }

    public class QuestionInfo
    {
        public string Question { get; set; }
        public string QType { get; set; }
        public string QChoice { get; set; }
        public string QAns { get; set; }
        public string Point { get; set; }
    }
    
}
