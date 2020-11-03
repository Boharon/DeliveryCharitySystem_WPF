using DC_SYSTEM._BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DC_SYSTEM.BLL
{
	public class MapImage
	{

        List<String> myColorsList;
        //Create a list of colores
        public MapImage()
        {
            myColorsList = new List<string>()
        { "FF0000","FFFF00","808000","00FF00","008000","00FFFF","800000","008080","0000FF","000080","FF00FF","800080","0066CC", "C8C8C8", "FFFFFF", "646464", "000000", "FFFFFF", "F0F8FF", "FAEBD7", "00FFFF", "7FFFD4", "F0FFFF", "F5F5DC", "FFE4C4", "000000", "FFEBCD", "0000FF", "8A2BE2", "A52A2A", "DEB887", "5F9EA0", "7FFF00", "D2691E", "FF7F50", "6495ED", "FFF8DC", "DC143C", "00FFFF", "00008B", "008B8B", "B8860B", "A9A9A9", "006400", "BDB76B", "8B008B", "556B2F", "FF8C00", "9932CC", "8B0000", "E9967A", "8FBC8B", "483D8B", "2F4F4F", "00CED1", "9400D3", "FF1493", "00BFFF", "696969", "1E90FF", "B22222", "FFFAF0", "228B22", "FF00FF", "DCDCDC", "F8F8FF", "FFD700", "DAA520", "808080", "008000", "ADFF2F", "F0FFF0", "FF69B4", "CD5C5C", "4B0082", "FFFFF0", "F0E68C", "E6E6FA", "FFF0F5", "7CFC00", "FFFACD", "ADD8E6", "F08080", "E0FFFF", "FAFAD2", "D3D3D3", "90EE90", "FFB6C1", "FFA07A", "20B2AA", "87CEFA", "778899", "B0C4DE", "FFFFE0", "00FF00", "32CD32", "FAF0E6", "FF00FF", "800000", "66CDAA", "0000CD", "BA55D3", "9370DB", "3CB371", "7B68EE", "00FA9A", "48D1CC", "C71585", "191970", "F5FFFA", "FFE4E1", "FFE4B5", "FFDEAD", "000080", "FDF5E6", "808000", "6B8E23", "FFA500", "FF4500", "DA70D6", "EEE8AA", "98FB98", "AFEEEE", "DB7093", "FFEFD5", "FFDAB9", "CD853F", "FFC0CB", "DDA0DD", "B0E0E6", "800080", "FF0000", "BC8F8F", "4169E1", "8B4513", "FA8072", "F4A460", "2E8B57", "FFF5EE", "A0522D", "C0C0C0", "87CEEB", "6A5ACD", "708090", "FFFAFA", "00FF7F", "4682B4", "D2B48C", "008080", "D8BFD8", "FF6347", "40E0D0", "EE82EE", "F5DEB3", "FFFFFF", "F5F5F5", "FFFF00", "9ACD32", "F0F0F0", "FFFFFF", "A0A0A0", "B9D1EA", "D7E4F2", "F0F0F0", "3399FF" };
    }
        //The function receive all of deliveries and return url of map with their address color according thier cluster for homePage
		public string DownloadHomePageMap(List<Delivery> deliveryList)
		{
            string key = "s6JPBRnNQ8Gg1sG791Mt775kHAnqARmT";
            string pins = "";

            foreach (var delivery in deliveryList)
            {

                pins += delivery.MyAdult.Address + "|marker-" + myColorsList[delivery.AreaGroup] + "||";

            }
            string url = @"https://www.mapquestapi.com/staticmap/v5/map" +
             @"?key=" + key +
             @"&locations=" + pins +
             @"&size=450,400@2x";


            return url;
        }
        //Color to hex converter
		private string ColorToHexString(Color color)
        {
            char[] hexDigits = {
                 '0', '1', '2', '3', '4', '5', '6', '7',
                  '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
            byte[] bytes = new byte[3];
            bytes[0] = color.R;
            bytes[1] = color.G;
            bytes[2] = color.B;
            char[] chars = new char[bytes.Length * 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                int b = bytes[i];
                chars[i * 2] = hexDigits[b >> 4];
                chars[i * 2 + 1] = hexDigits[b & 0xF];
            }
            return new string(chars);
        }
        //The function receive list of deliveries and return url of map with their address color according thier cluster
        public string DownloadMap(List<Delivery> deliveryList)
        {
            string key = "s6JPBRnNQ8Gg1sG791Mt775kHAnqARmT";
            string pins = "";

            foreach (var delivery in deliveryList)
            { 
               
                pins += delivery.MyAdult.Address + "|marker-" + myColorsList[delivery.AreaGroup] + "||";
             
            }
            string url = @"https://www.mapquestapi.com/staticmap/v5/map" +
             @"?key=" + key +
             @"&locations=" + pins +
             @"&size=818,200@2x";

          
            return url;
        }
    }
}
