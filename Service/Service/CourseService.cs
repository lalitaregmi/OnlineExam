using Dapper;
using Helper.Dapper;
using Models.Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class CourseService:ICourse
    {
        public async Task<dynamic> Course(Course c) { 
            var res = new ResValues(); 

            {
                var sql = "sp_course"; 
                var parameters = new DynamicParameters(); 
                parameters.Add("@flag", c.Flag);          
                parameters.Add("@userid", c.UserID);
                parameters.Add("@name", c.Name);


                parameters.Add("@isactive", c.IsActive);
                
                parameters.Add("@courseid", c.CourseID);

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
