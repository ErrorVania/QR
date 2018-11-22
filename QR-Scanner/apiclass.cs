using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarcodeLib.BarcodeReader;
using QRCoder;

namespace QR_Scanner
{
    class apiclass
    {
        public static QRCodeGenerator qrGenerator = new QRCodeGenerator();

        public static string[] scanQR(string filepath, int mode = 9)
        {
            return BarcodeReader.read(filepath, BarcodeReader.QRCODE);
        }
        public static Bitmap generateQRcode(string texttoencode, int pixelspermodule = 20)
        {
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(texttoencode, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(pixelspermodule);
            return qrCodeImage;
        }

        public static void printArr(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        public static Bitmap QRpayload_Wifi(string ssid, string pass, int pixelspermodule = 20)
        {
            PayloadGenerator.WiFi wifiPayload = new PayloadGenerator.WiFi(ssid, pass, PayloadGenerator.WiFi.Authentication.WPA);
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(wifiPayload.ToString(), QRCodeGenerator.ECCLevel.Q);

            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(pixelspermodule);
            return qrCodeImage;
        }
    }
}
