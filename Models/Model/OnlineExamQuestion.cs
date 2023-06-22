using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class OnlineExamQuestion
    {
        public string Flag { get; set; }
        public string UserID { get; set; }
        public string CourseID { get; set; }
        public string TermID{ get; set; }

        public List<Questions> Values { get; set; }



    }
    public class Questions
    {
        public string ExamSubmitID{ get; set; }
        public string QnID { get; set; }
        public string QnAns { get; set; }

    }
}
