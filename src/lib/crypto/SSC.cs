using System.Text;
using System;
using System.Collections.Generic;

namespace crypto
{
    public interface ISSC {
        string ENCODE_SSC(string key, string text);
        string DECODE_SSC(string key, string chiper);
        string GET_SSC_KEY();
    }
    public class SSC : ISSC
    {
        ///<summary>
        /// SSC - Super Secure Chiper алгоритм шифрования с симметричным ключом 
        ///</summary>
        
        public SSC() {

        }

        /// <summary>
        /// Функция шифрования в SSC 
        /// </summary>
        /// <param name="key">Секретный ключ</param>
        /// <param name="text">Текст который нужно зашифровать</param>
        /// <returns>шифр</returns>
        public string ENCODE_SSC(string key, string text) {
            var key_b = Encoding.UTF8.GetBytes(key);
            var text_b = Encoding.UTF8.GetBytes(text);

            int shift = 2;
            int mask = 8-shift-1;
            shift &= mask;

            List<byte> res = new List<byte>();

            for(int i = 0; i < text_b.Length; i++) {
                byte a = Convert.ToByte((text_b[i]>>shift) | (text_b[i]<<(-shift & mask)));
                res.Add(Convert.ToByte(key_b[i%32]^a));
            }

            return Convert.ToBase64String(res.ToArray());
        }

        /// <summary>
        /// Функция дешифровки
        /// </summary>
        /// <param name="key">Секретный ключ</param>
        /// <param name="chiper">Шифр</param>
        /// <returns>Расшифрованный текст</returns>
        public string DECODE_SSC(string key, string chiper) {

            byte[] cpr = Convert.FromBase64String(chiper);
            string cpr1 = Encoding.UTF8.GetString(cpr);
            var key_b = Encoding.UTF8.GetBytes(key);
            byte[] chiper_b = Encoding.UTF8.GetBytes(cpr1);

            int shift = 6;
            int mask = 8-shift-1;
            shift &= mask;

            List<byte> result = new List<byte>();
            for(int i = 0; i < chiper_b.Length; i++) {
                byte a = Convert.ToByte(chiper_b[i]^key_b[i%key.Length]);
                result.Add(Convert.ToByte((a>>shift) | (a<<(-shift & mask))));
            }

            return Encoding.UTF8.GetString(result.ToArray());
        }

        /// <summary>
        /// Функция Генерации ключа (де)шифровки
        /// </summary>
        /// <returns>Секретный ключ</returns>
        public string GET_SSC_KEY() {
            var rand = new Random();
            StringBuilder res = new StringBuilder();
            for(int i = 0; i < 8; i++)
                res.Append(Convert.ToString(rand.Next(8999)+1000));
            return res.ToString();
        }
    }
}
