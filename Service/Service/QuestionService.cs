using Dapper;
using Helper.Dapper;
using Models.Model;
using Newtonsoft.Json;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Service.Service
{
    public class QuestionService:IQuestion
    {

        public async Task<dynamic> Question(Question q) 
        {
            var res = new ResValues(); 
            {
                string jsonstring = JsonConvert.SerializeObject(q);
                XmlDocument xmlNode = JsonConvert.DeserializeXmlNode(jsonstring, "root");
                var sql = "sp_question"; 
                var parameters = new DynamicParameters(); 
                parameters.Add("@flag", q.Flag);           
                parameters.Add("@userid", q.UserID);
                parameters.Add("@courseid", q.CourseID);
                parameters.Add("@point", q.Point);
                parameters.Add("@value", xmlNode.OuterXml);

                parameters.Add("@question", q.Questions);

                parameters.Add("@qtype", q.QType);
                parameters.Add("@qchoice", q.QChoice);
                parameters.Add("@qans", q.QAns);
                
                parameters.Add("@questionid", q.QuestionID);

                var data = await DbHelper.RunProc<dynamic>(sql, parameters); 
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    res.Values = data.ToList();
                    res.StatusCode = 200;
                    res.Message = "Success";
                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    res.Values = null;
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;

                }
                else
                {
                    res.Values = null;
                    res.StatusCode = 400;
                    res.Message = "no data";

                }
            }
            return res;
        }

    }
}
