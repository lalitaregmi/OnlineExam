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
    public class OnlineExamQuestionService:IOnlineExamQuestion
    {

        public async Task<dynamic> OnlineExam(OnlineExamQuestion O)
        {
            var res = new ResValues();
            {
                string jsonstring = JsonConvert.SerializeObject(O);
                XmlDocument xmlNode = JsonConvert.DeserializeXmlNode(jsonstring, "root");
                var sql = "sp_online_exam";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", O.Flag);
                parameters.Add("@userid", O.UserID);
                parameters.Add("@courseid", O.CourseID);
                parameters.Add("@termid", O.TermID);
                parameters.Add("@value", xmlNode.OuterXml);

                
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
