
using Microsoft.Extensions.Configuration;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UnitOfWork: IUnitOfWork
    {
        public UnitOfWork(IConfiguration config)
        {
            Configuration = config;
        }

        private IConfiguration Configuration { get; }
        public PasswordService passservice => new PasswordService();
        public UserService userservice => new UserService();
        public CourseService courseservice => new CourseService();


        public ExamQuestionService examquestionservice => new ExamQuestionService();

        public LoginService loginservice => new LoginService();
        public TerminalService terminalservice => new TerminalService();
        public QuestionService questionservice => new QuestionService();
        public OnlineExamQuestionService onlineexamquestionservice => new OnlineExamQuestionService();
        public ImageService imageservice => new ImageService();
        public NotifyService notifyservice => new NotifyService();


    }
}
