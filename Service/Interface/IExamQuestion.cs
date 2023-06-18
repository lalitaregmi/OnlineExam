using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IExamQuestion
    {
        Task<dynamic> Question(ExamQuestion e);
    }
}
