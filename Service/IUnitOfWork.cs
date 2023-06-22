using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUnitOfWork
    {
        public PasswordService passservice { get; }
        public UserService userservice { get; }
        public CourseService courseservice { get; }
        public ExamQuestionService examquestionservice { get; }

        public LoginService loginservice { get; }
        public TerminalService terminalservice { get; }
        public QuestionService questionservice { get; }
        public OnlineExamQuestionService onlineexamquestionservice { get; }
        public ImageService imageservice { get; }
        public NotifyService notifyservice { get; }
    }
}
