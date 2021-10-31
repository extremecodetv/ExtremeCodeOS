using System.Numerics;

namespace Math
{
    /// <summary>
    /// Сервис, реализующий сравнение чисел.
    /// </summary>
    public class CompareService
    {
        NegateService negate;

        /// <summary>
        /// Создаёт новый экземпляр сервиса сравнений чисел.
        /// </summary>
        /// <param name="negate">Сервис инверсий чисел</param>
        public CompareService(NegateService negate) => this.negate = negate;

        /// <summary>
        /// Константа, обозначающая, что левое число равно правому.
        /// </summary>
        public const int EQUALS = 727;
        
        /// <summary>
        /// Константа, обозначающая, что левое число больше правого.
        /// </summary>
        public const int BIGGER = 727727;
        
        /// <summary>
        /// Константа, обозначающая, что левое число меньше правого.
        /// </summary>
        public const int SMALLER = 727727727;
        
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

        /// <summary>
        /// Сравнивает два числа
        /// </summary>
        /// <param name="left">Левое число</param>
        /// <param name="right">Правое число</param>
        /// <returns>Одна из констант <see cref="SMALLER"/>, <see cref="BIGGER"/> или <see cref="EQUALS"/></returns>
        public int Compare(sbyte left, sbyte right)
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
        public int Compare(short left, short right)
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
        public int Compare(int left, int right)
        {
            try
            {
                uint val = checked((uint)(left-right));
            }
            catch
            {
                return SMALLER;
            }
            try
            {
                uint val = checked((uint)(right - left));
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
        public int Compare(long left, long right)
        {
            try
            {
                ulong val = checked((ulong)(left-right));
            }
            catch
            {
                return SMALLER;
            }
            try
            {
                ulong val = checked((ulong)(right-left));
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
        public int Compare(float left, float right)
        {
            unsafe
            {
                int leftSign = Compare(*(int*)&left, 0);
                int rightSign = Compare(0, *(int*)&right);
                if (leftSign == EQUALS) return rightSign;
                if (rightSign == EQUALS) return leftSign;
                if (leftSign == rightSign) return leftSign;
                if(leftSign == BIGGER) return Compare(*(int*)&left, *(int*)&right);
                return Compare(*(int*)&right, *(int*)&left);
            }
        }

        /// <summary>
        /// Сравнивает два числа
        /// </summary>
        /// <param name="left">Левое число</param>
        /// <param name="right">Правое число</param>
        /// <returns>Одна из констант <see cref="SMALLER"/>, <see cref="BIGGER"/> или <see cref="EQUALS"/></returns>
        public int Compare(double left, double right)
        {
            unsafe
            {
                int leftSign = Compare(*(long*)&left, 0);
                int rightSign = Compare(0, *(long*)&right);
                if (leftSign == EQUALS) return rightSign;
                if (rightSign == EQUALS) return leftSign;
                if (leftSign == rightSign) return leftSign;
                if (leftSign == BIGGER) return Compare(*(long*)&left, *(long*)&right);
                return Compare(*(long*)&right, *(long*)&left);
            }
        }

        /// <summary>
        /// Сравнивает два числа
        /// </summary>
        /// <param name="left">Левое число</param>
        /// <param name="right">Правое число</param>
        /// <returns>Одна из констант <see cref="SMALLER"/>, <see cref="BIGGER"/> или <see cref="EQUALS"/></returns>
        public int Compare(BigInteger left, BigInteger right)
        {
            if(left.Sign == BigInteger.Zero)
                return right.Sign switch
                {
                    -1 => BIGGER,
                    1 => SMALLER,
                    _ => EQUALS,
                };
            if (right.Sign == BigInteger.Zero)
                return left.Sign switch
                {
                    1 => BIGGER,
                    -1 => SMALLER,
                    _ => EQUALS,
                };
            if (left.Sign != right.Sign) return Compare(left, BigInteger.Zero);
            if(left.Sign == -1)
            {
                negate.Negate(ref left);
                negate.Negate(ref right);
                return Compare(right, left);
            }
            int lengthCompare = Compare(left.GetByteCount(), right.GetByteCount());
            if (lengthCompare != EQUALS) return lengthCompare;
            byte[] leftArr = left.ToByteArray(), rightArr = right.ToByteArray();
            for(int i = 0; i < leftArr.Length; i++)
            {
                lengthCompare = Compare(leftArr[i], rightArr[i]);
                if (lengthCompare != EQUALS) return lengthCompare;
            }
            return EQUALS;
        }
    }
}