using IronBarCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRGenerator
{
    public class Qr
    {
        static string path = Environment.CurrentDirectory;
        public static bool Create(string text)
        {
            try
            {
                string logoPath = Path.Combine(path, "/img/aes.png");
                var qrLogo = QRCodeWriter.CreateQrCodeWithLogo(text, path+ "\\img\\aes.png", 500);
                //qrLogo.ChangeBarCodeColor(System.Drawing.Color.DarkGreen);

                if (!qrLogo.Verify())
                {
                    Stamp.WriteLine("\t Qr is not dark enough to be read accurately.  Lets try Another color");
                    //qrLogo.ChangeBarCodeColor(Color.DarkBlue);
                    return false;
                }

                long mill = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();

                //Save as PDF
                qrLogo.SaveAsPdf(GetDirectory() + "\\QR_" + mill + ".pdf");
                //Also Save as HTML
                qrLogo.SaveAsPng(GetDirectory() + "\\QR_" + mill + ".png");
                return true;
            }catch (Exception ex)
            {
                Stamp.Write(ex.StackTrace);
                return false;
            }
        }

        public static string GetDirectory()
        {
            string dir = path + "\\result";
            // If directory does not exist, create it
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            return dir;
        }
    }
}
