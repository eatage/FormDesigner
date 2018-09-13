using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FormDesinger.Core
{
    class GetFileEncoding
    {
        /// <summary>
        /// 返回文件编码格式
        /// </summary>
        public static System.Text.Encoding GetFileEncodeType(string filename)
        {
            using (FileStream fs = new FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                byte[] Unicode = new byte[] { 0xFF, 0xFE, 0x41 };
                byte[] UnicodeBIG = new byte[] { 0xFE, 0xFF, 0x00 };
                byte[] UTF8 = new byte[] { 0xEF, 0xBB, 0xBF };//带BOM
                Encoding reVal = Encoding.Default;
                BinaryReader br = new BinaryReader(fs);
                int length;
                int.TryParse(fs.Length.ToString(), out length);
                byte[] ss = br.ReadBytes(length);
                if (IsUTF8Bytes(ss) ||
                    (ss[0] == UTF8[0] && ss[1] == UTF8[1] && ss[2] == UTF8[2]))
                    reVal = Encoding.UTF8;
                else if (ss[0] == UnicodeBIG[0] && ss[1] == UnicodeBIG[1] && ss[2] == UnicodeBIG[2])
                    reVal = Encoding.BigEndianUnicode;
                else if (ss[0] == Unicode[0] && ss[1] == Unicode[1] && ss[2] == Unicode[2])
                    reVal = Encoding.Unicode;
                br.Close();
                return reVal;
            }
        }

        /// <summary>
        /// 判断是否是不带BOM的UTF8格式
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static bool IsUTF8Bytes(byte[] data)
        {
            int charByteCounter = 1;//计算当前正分析的字符应还有的字节数
            byte curByte;//当前分析的字节
            for (int i = 0; i < data.Length; i++)
            {
                curByte = data[i];
                if (charByteCounter == 1)
                {
                    if (curByte >= 0x80)
                    {
                        //判断当前
                        while (((curByte <<= 1) & 0x80) != 0)
                        {
                            charByteCounter++;
                        }
                        //标记位首位若为非0 则至少以2个1开始，如：110XXXXX.....1111110X
                        if (charByteCounter == 1 || charByteCounter > 6)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    //若是UTF-8 此时第一位必须为1
                    if ((curByte & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    charByteCounter--;
                }
            }
            if (charByteCounter > 1)
            {
                throw new Exception("非预期的byte格式");
            }
            return true;
        }
    }
}
