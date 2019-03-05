using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace BIG.VMS.PRESENT
{
    public static class CardHelper
    {
        public static string StartupPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

        public static string GetCurrentExecutingDirectory(System.Reflection.Assembly assembly)
        {
            string filePath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            return Path.GetDirectoryName(filePath);
        }

        public static IntPtr SelectReader(String reader)
        {
            IntPtr mCard = (IntPtr)0;
            byte[] _reader = String2Byte(reader);
            IntPtr res = (IntPtr)RDNID.selectReaderRD(_reader);
            if ((Int64)res > 0)
            {
                mCard = (IntPtr)res;
            }

            return mCard;
        }

        public static byte[] String2Byte(string s)
        {
            // Create two different encodings.
            Encoding ascii = Encoding.GetEncoding(874);
            Encoding unicode = Encoding.Unicode;

            // Convert the string into a byte array.
            byte[] unicodeBytes = unicode.GetBytes(s);

            // Perform the conversion from one encoding to the other.
            byte[] asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes);

            return asciiBytes;
        }

        public static string ByteToString(byte[] b)
        {
            Encoding ut = Encoding.GetEncoding(874); // 874 for Thai langauge
            int i;
            for (i = 0; b[i] != 0; i++) ;
            string s = ut.GetString(b);
            s = s.Substring(0, i);
            return s;
        }

        public static string DateFormat(string date)
        {
            string result = "";
            string _yyyy = date.Substring(0, 4);
            string _mm = date.Substring(4, 2);
            string _dd = date.Substring(6, 2);


            string[] mm = { "", "ม.ค.", "ก.พ.", "มี.ค.", "เม.ย.", "พ.ค.", "มิ.ย.", "ก.ค.", "ส.ค.", "ก.ย.", "ต.ค.", "พ.ย.", "ธ.ค." };
            string _tm = "-";
            if (_mm == "00")
            {
                _tm = "-";
            }
            else
            {
                _tm = mm[int.Parse(_mm)];
            }

            if (_yyyy == "0000")
            {
                _yyyy = "-";
            }

            if (_dd == "00")
            {
                _dd = "-";
            }

            result = _dd + " " + _tm + " " + _yyyy;
            return result;
        }
    }
}
