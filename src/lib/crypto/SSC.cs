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
        /// Автор - yosa12978
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
            List<byte> res = new List<byte>();
            for(int i = 0; i < text_b.Length; i++) {
                res.Add(Convert.ToByte(key_b[i%32]^text_b[i]));
            }
            byte[] arr = res.ToArray();
            return Convert.ToBase64String(arr);
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
            List<byte> result = new List<byte>();
            for(int i = 0; i < chiper_b.Length; i++) 
                result.Add(Convert.ToByte(chiper_b[i]^key_b[i%32]));
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
            res.Append(Convert.ToString(rand.Next(9000)+1000));
            return res.ToString();
        }
    }
}
