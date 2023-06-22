using Nancy.Json;
using System.Net;

namespace Helper.DBHelper
{

    public class PushNotification
    {

        public static string SendNotificationByTopic(string notificationtopic, string Title, string Body)
        {
            String sResponseFromServer = "Error";
            try
            {
                string server_api_key = ""; //"AAAAxhXLUFA:APA91bG0Nvx0DaWwhvQW7zz82t04YOxCySzIO0ifw924uowvKZfISFGYVXEF9E2lNyaGsrpox1k7uW8KmvqxkS4O9NPhdkauZwaVhvTY2E1xRdnEVBEL83lR2bZhYYRok3n4wzmRSCNa";
                string sender_id = "";   //"850769170512";

                dynamic data = new
                {
                    // if you want to test for single device
                    to = "/topics/" + notificationtopic,

                    // registration_ids = singlebatch, // this is for multiple user 

                    notification = new
                    {
                        // Notification title
                        title = Title,

                        // Notification body data
                        body = Body,


                    }
                };

                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(json);

                WebRequest tRequest;
                tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", server_api_key));

                tRequest.Headers.Add(string.Format("Sender: id={0}", sender_id));

                tRequest.ContentLength = byteArray.Length;
                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse tResponse = tRequest.GetResponse();

                dataStream = tResponse.GetResponseStream();

                StreamReader tReader = new StreamReader(dataStream);

                sResponseFromServer = tReader.ReadToEnd();

                tReader.Close();
                dataStream.Close();
                tResponse.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return (sResponseFromServer);

        }

        public static string SendNotificationByDeviceID(string notificationtoken, string Title, string Body)
        {
            String sResponseFromServer = "Error";
            try
            {
                //string server_api_key = "AAAALjRbmmc:APA91bG5ciF0b2diNsz_SzI1ANeZYt--4mCSHRLZitbYlZjqQX3TRtsVwqrNaYUbr7zFW6GP-i4nxeLNIMkPpPukGcFwCL0cvll6XhYQ9ksTXHnvRqsiqe3aHNoaexUTgf8N8Kk_MkPd";
                //string sender_id = "198446914151"; 

                string server_api_key = "AAAASsy3-CQ:APA91bGkRvNWrMXJe4cs5B8u1g7EWXBTv4EtOKsEv5k8yDDhMnO7q99suoSqqYK3WB2vJY0uom5sokdB7RLAH-CC2M9B1JsRQCMJGq_cMWr13pAeW-SKqq9gN2phHwXJZxlSWErQDnKz\r\n\r\n\r\n";
                string sender_id = "321262188580";

                dynamic data = new
                {
                    // if you want to test for single device
                    to = notificationtoken,

                    // registration_ids = singlebatch, // this is for multiple user 

                    notification = new
                    {
                        // Notification title
                        title = Title,

                        // Notification body data
                        body = Body,

                        // When click on notification user redirect to this link
                        //link = "https://www.dynagroseed.com/app/uploads/2018/02/testing-clipart-quiet-testing-sign-v0ryt0-297x300.jpg",

                        //icon for notification
                        //icon: "https://www.dynagroseed.com/app/uploads/2018/02/testing-clipart-quiet-testing-sign-v0ryt0-297x300.jpg"
                    }
                };

                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(json);

                WebRequest tRequest;
                tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", server_api_key));

                tRequest.Headers.Add(string.Format("Sender: id={0}", sender_id));

                tRequest.ContentLength = byteArray.Length;
                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse tResponse = tRequest.GetResponse();

                dataStream = tResponse.GetResponseStream();

                StreamReader tReader = new StreamReader(dataStream);

                sResponseFromServer = tReader.ReadToEnd();

                tReader.Close();
                dataStream.Close();
                tResponse.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return sResponseFromServer;
        }
    }
}
