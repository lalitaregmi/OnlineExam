using Dapper;
using Helper.Dapper;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class TerminalService
    {

        public async Task<dynamic> Terminal(Terminal t) 
        {
            var res = new ResValues(); 

            {
                var sql = "sp_terminal"; 
                var parameters = new DynamicParameters(); 
                parameters.Add("@flag", t.Flag);          
                parameters.Add("@userid", t.UserID);
                parameters.Add("@name", t.Name);


                parameters.Add("@interval", t.Interval);

                parameters.Add("@description", t.Description);
                    parameters.Add("@isactive", t.IsActive);
                parameters.Add("@termid", t.TermID);

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
