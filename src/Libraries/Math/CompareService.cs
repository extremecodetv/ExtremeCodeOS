namespace Math
{
    /// <summary>
    /// Сервис, реализующий сравнение чисел.
    /// </summary>
    public class CompareService
    {
        /// <summary>
        /// Константа, обозначающая, что левое число равно правому.
        /// </summary>
        public const int EQUALS = 0xFACE;
        /// <summary>
        /// Константа, обозначающая, что левое число больше правого.
        /// </summary>
        public const int BIGGER = 0xDEAD;
        /// <summary>
        /// Константа, обозначающая, что левое число меньше правого.
        /// </summary>
        public const int SMALLER = 0xBEEF;
        /// <summary>
        /// Сравнивает два числа
        /// </summary>
        /// <param name="left">Левое число</param>
        /// <param name="right">Правое число</param>
        /// <returns>Одна из констант <see cref="SMALLER"/>, <see cref="BIGGER"/> или <see cref="EQUALS"/></returns>
        public int Compare(byte left, byte right)
        {
            try
            {
                byte val = checked((byte)(left-right));
            }
            catch
            {
                return SMALLER;
            }
            try
            {
                byte val = checked((byte)(right-left));
            }
            catch
            {
                return BIGGER;
            }
            return EQUALS;
        }

        /// <summary>
        /// Сравнивает два числа
        /// </summary>
        /// <param name="left">Левое число</param>
        /// <param name="right">Правое число</param>
        /// <returns>Одна из констант <see cref="SMALLER"/>, <see cref="BIGGER"/> или <see cref="EQUALS"/></returns>
        public int Compare(ushort left, ushort right)
        {
            try
            {
                ushort val = checked((ushort)(left-right));
            }
            catch
            {
                return SMALLER;
            }
            try
            {
                ushort val = checked((ushort)(right-left));
            }
            catch
            {
                return BIGGER;
            }
            return EQUALS;
        }

        /// <summary>
        /// Сравнивает два числа
        /// </summary>
        /// <param name="left">Левое число</param>
        /// <param name="right">Правое число</param>
        /// <returns>Одна из констант <see cref="SMALLER"/>, <see cref="BIGGER"/> или <see cref="EQUALS"/></returns>
        public int Compare(uint left, uint right)
        {
            try
            {
                uint val = checked(left-right);
            }
            catch
            {
                return SMALLER;
            }
            try
            {
                uint val = checked(right-left);
            }
            catch
            {
                return BIGGER;
            }
            return EQUALS;
        }

        /// <summary>
        /// Сравнивает два числа
        /// </summary>
        /// <param name="left">Левое число</param>
        /// <param name="right">Правое число</param>
        /// <returns>Одна из констант <see cref="SMALLER"/>, <see cref="BIGGER"/> или <see cref="EQUALS"/></returns>
        public int Compare(ulong left, ulong right)
        {
            try
            {
                ulong val = checked(left-right);
            }
            catch
            {
                return SMALLER;
            }
            try
            {
                ulong val = checked(right-left);
            }
            catch
            {
                return BIGGER;
            }
            return EQUALS;
        }
    }
}
