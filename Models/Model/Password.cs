using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public  class Password
    {
        public string UserID { get; set; }

        public string OldPwd { get; set; }

        public string NewPwd { get; set; }


    }

    public class ResValues : CommonResponse 
    {
        public List<dynamic> Values { get; set; }  
       }

}
