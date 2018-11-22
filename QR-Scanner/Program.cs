using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QR_Scanner
{
    class Program
    {
        public string[] credit_to_following_APIs =
        {
            "https://github.com/codebude/QRCoder",
            "http://www.barcodelib.com/net_barcode_reader/barcodes/qrcode.html"

        };


        static void Main(string[] args)
        {
            int i = -1;
            Console.WriteLine("##########-Menu-##########");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[{0}]", ++i);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(": {0}", "Scan QR-Code Image (Decode Text)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[{0}]", ++i);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(": {0}", "Generate QR-Code Image (Encode Text)");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[{0}]", ++i);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(": {0}", "Generate QR-Wifi-Payload Image (Encode Wifi Credentials)");
            ConsoleKeyInfo inf = Console.ReadKey();
            char response = inf.KeyChar;
            Console.Clear();
            responseaction(response);
            Console.ReadLine();
        }
        public static void responseaction(char input)
        {
            if (input == '0')
            {
                Console.WriteLine("Chosen Action: {0}", input);
                Console.Write("Enter Image File Path to read from: ");
                string readingfile = Console.ReadLine();
                try
                {
                    apiclass.printArr(apiclass.scanQR(readingfile));
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            if (input == '1')
            {
                Console.WriteLine("Chosen Action: {0}", input);
                Console.Write("Enter Text to encode to QR-Code Image: ");
                string texttoencode = Console.ReadLine();
                Console.Write("Enter Output File Path: ");
                string outfile = Console.ReadLine();
                try
                {
                    apiclass.generateQRcode(texttoencode).Save(outfile);
                } catch (Exception ex) { ex.ToString(); }
            }
            if (input == '2')
            {
                Console.WriteLine("Chosen Action: {0}", input);
                Console.WriteLine("Enter Wifi SSID: ");
                string ssid = Console.ReadLine();
                Console.WriteLine("Enter Wifi Password (WPA): ");
                string pass = Console.ReadLine();
                Console.WriteLine("Enter Output File Path: ");
                string path = Console.ReadLine();
                try
                {
                    apiclass.QRpayload_Wifi(ssid, pass).Save(path);
                } catch (Exception ex) { ex.ToString(); }
            }
        }
    }
}
