using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace TBKAPI.Controllers
{
    public class QrcodeController : Controller
    {
       // private static string _curentDirectory= @"D:\Net Projects\DreamSource\TBKAPI\TBKAPI";
        private static string _curentDirectory = @"C:\TBKQRCode";

        // GET api/values/5
        public ActionResult Get(string idAndIndex)
        {
            int id = Convert.ToInt32(idAndIndex.Split('_').FirstOrDefault());
            int index = Convert.ToInt32(idAndIndex.Split('_')[1]);

            var templete =Path.Combine(_curentDirectory, $"qrcode/template/t{index}.jpg");
            var fileLocation= GenerateQrcode(id, index, templete);
            var contentType = "image/jpeg";          
            var fileBytes = System.IO.File.ReadAllBytes(fileLocation);
            return File(fileBytes, contentType);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        private string GenerateQrcode(int userId,int index,string bgImgPath)
        {
            Image background;
            var cardLocation = Path.Combine(_curentDirectory, $"qrcode\\output\\{userId}_{index}.jpg");
            if (System.IO.File.Exists(cardLocation)) return cardLocation;
            var logoLocation = Path.Combine(_curentDirectory, $"qrcode\\logo\\logo.png");
            background = Image.FromFile(bgImgPath);
            using (var bitmap = new Bitmap(1125, 2001))
            {
                using (var canvas = Graphics.FromImage(bitmap))
                {
                    canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    //draw background
                    canvas.DrawImage(background, new Rectangle(0, 0, 1125, 2001), new Rectangle(0, 0, background.Width, background.Height), GraphicsUnit.Pixel);
                    //draw infos
                    // QR CODE GENERATE
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    var qdcodeUrl = $"https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxda337f3186c93879&redirect_uri=http://admin.huijiwanjia.com/WechatAuth/AuthCallback&response_type=code&scope=snsapi_userinfo&state={userId}&connect_redirect=1#wechat_redirect";
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(qdcodeUrl, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(5, Color.Black, Color.White, (Bitmap)Bitmap.FromFile(logoLocation));

                    //draw qrcode
                    canvas.DrawImage(qrCodeImage, 370, 1375);
                    //draw infos
                    canvas.DrawString(userId.ToString(), new Font("黑体", 48, FontStyle.Bold), new SolidBrush(Color.DimGray), 495, 1860);
                    canvas.Save();
                }
                var cardDirectory = Path.GetDirectoryName(cardLocation);
                if (!Directory.Exists(cardDirectory)) Directory.CreateDirectory(cardDirectory);
                bitmap.Save(cardLocation, System.Drawing.Imaging.ImageFormat.Jpeg);
                background.Dispose();
            }
            return cardLocation;
        }
    }
}
