using Dapper;
using Helper.Dapper;
using Helper.DBHelper;
using Models.Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class NotifyService:INotify
    {
        public async Task<dynamic> Notify(Notify N)
        {
            var res = new ResValues();

            {
                if (N.Flag == "I")
                {
                    PushNotification.SendNotificationByDeviceID(N.NotValues, N.Title, N.Description);
                } else
                {
                    PushNotification.SendNotificationByTopic(N.NotValues, N.Title, N.Description);
                }
            }

            return res;
        }




    }
}
