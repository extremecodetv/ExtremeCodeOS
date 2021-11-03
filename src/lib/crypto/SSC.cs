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
        /// Библиотека с криптографией.
        /// SSC - Super Secret Chiper алгоритм шифрования с синхронным ключом.
        /// Автор - yosa12978, бог крипты.
        ///</summary>
        
        public SSC() {

        }

        /// <summary>
        /// Функция шифрования в SSC.
        /// </summary>
        /// <param name="key">Секретный ключ.</param>
        /// <param name="text">Текст который нужно зашифровать.</param>
        /// <returns>шифр</returns>
        public string ENCODE_SSC(string key, string text) {
            var key_b = Encoding.UTF8.GetBytes(key);
            var text_b = Encoding.UTF8.GetBytes(text);
            StringBuilder res = new StringBuilder();
            var delimiter = "";
            for(int i = 0; i < text_b.Length; i++) {
                res.Append(delimiter);
                res.Append(Convert.ToString(key_b[i%32]^text_b[i]));
                delimiter = " ";
            }
            return res.ToString();
        }

        /// <summary>
        /// Функция дешифровки.
        /// </summary>
        /// <param name="key">Секретный ключ.</param>
        /// <param name="chiper">Шифр.</param>
        /// <returns>Расшифрованный текст.</returns>
        public string DECODE_SSC(string key, string chiper) {
            var key_b = Encoding.UTF8.GetBytes(key);
            string[] chiper_s = chiper.Split(' ');
            byte[] chiper_b = Array.ConvertAll(chiper_s, m => byte.Parse(m));
            StringBuilder res = new StringBuilder();
            List<byte> result = new List<byte>();
            for(int i = 0; i < chiper_b.Length; i++) 
                result.Add(Convert.ToByte(chiper_b[i]^key_b[i%32]));
            return Encoding.UTF8.GetString(result.ToArray());
        }

        /// <summary>
        /// Функция Генерации ключа симметричного шифрования.
        /// </summary>
        /// <returns>Секретный ключ.</returns>
        public string GET_SSC_KEY() {
            var rand = new Random(0);
            StringBuilder res = new StringBuilder();
            for(int i = 0; i < 8; i++)
            res.Append(Convert.ToString(rand.Next(9000)+1000));
            return res.ToString();
        }
    }
}
