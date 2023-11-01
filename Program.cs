using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace _030401
{
    internal class Program
    {
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            return "";
        }
        public static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://obmin.chernivtsi.ua");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string supp = stream.ReadToEnd();
            stream.Close();

            string UsdUahBuy = getBetween(supp, "Курс USD/UAH", "</li>");
            UsdUahBuy = Regex.Replace(UsdUahBuy, @"\D+", "");
            UsdUahBuy = UsdUahBuy.Insert(2, ",");
            UsdUahBuy = UsdUahBuy.Insert(5, " ");
            UsdUahBuy = UsdUahBuy.Insert(8, ",");
            Console.WriteLine("Курс USD/UAH\n" + UsdUahBuy);
            Console.WriteLine();

            string EurUah = getBetween(supp, "Курс EUR/UAH", "</li>");
            EurUah = Regex.Replace(EurUah, @"\D+", "");
            EurUah = EurUah.Insert(2, ",");
            EurUah = EurUah.Insert(5, " ");
            EurUah = EurUah.Insert(8, ",");
            Console.WriteLine("Курс EUR/UAH\n" + EurUah);
            Console.WriteLine();

            string PlnUah = getBetween(supp, "Курс PLN/UAH", "</li>");
            PlnUah = Regex.Replace(PlnUah, @"\D+", "");
            PlnUah = PlnUah.Insert(1, ",");
            PlnUah = PlnUah.Insert(4, " ");
            PlnUah = PlnUah.Insert(6, ",");
            Console.WriteLine("Курс PLN/UAH\n" + PlnUah);
            Console.WriteLine();
        }
    }
}