using Dapper;
using Helper.Dapper;
using Models.Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Service.Service
{
    public class ImageService:IImages
    {

        public async Task<dynamic> Img(Images I)
        {
            var res = new ResValues();
            {
                var sql = "sp_course";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", I.Flag);


                //image start
                foreach (ImageInfo e in I.Values) {
                    var img = Convert.FromBase64String(e.Image);
                    var imagename = DateTime.Now.Ticks + "_pramila.png";
                    var image = Image.FromStream(new MemoryStream(img));
                    image.Save("D:\\" + imagename, ImageFormat.Png);
                }
                //image end

                //parameters.Add("@image", imagename);
                res.Values = null;
                res.StatusCode = 200;
                res.Message = "Success";
                return res;

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
