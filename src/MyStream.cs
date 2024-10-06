using System.IO;

namespace TWXMan
{
    static class MyStream
    {
        /// <summary>
        /// byte数组转换为字符串
        /// </summary>
        /// <returns></returns>
        public static string ToStr(this byte[] arr)
        {
            return System.Text.Encoding.Default.GetString(arr);
        }
        /// <summary>
        /// 字符串转换成byte数组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string str)
        {
            return System.Text.Encoding.Default.GetBytes(str);
        }

        /// <summary>
        ///  在当前流中搜索指定的 byte[]
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="beginPosition">搜索开始位置，从0开始</param>
        /// <param name="key">搜索关键字</param>
        /// <param name="indexId">被查找的指定次数的关键字</param>
        /// <returns>如果存在则返回byte[]在流中指定索引次数出现的位置，否则返回 -1</returns>
        public static long Search(this Stream stream, long beginPosition, byte[] key, int indexId)
        {
            if (stream == null || stream.Length <= beginPosition)
                return -1;

            if (key == null || stream.Length < key.Length)
                return -1;

            long i = -1;
            long j = -1;
            int times = 1;
            int currentByte = int.MinValue;
            for (i = beginPosition; i < stream.Length; i++)
            {
                if (stream.Length < key.Length + i)
                    break;

                stream.Seek(i, SeekOrigin.Begin);
                for (j = 0; j < key.Length; j++)
                {
                    currentByte = stream.ReadByte();
                    if (currentByte != key[j])
                        break;
                }

                if (j == key.Length && times < indexId)
                {
                    ++times;
                }
                else if (j == key.Length && times == indexId)
                {
                    return i;
                }

                if (currentByte == -1 || times > indexId)
                    break;
            }
            return -1;

        }
    }
}
