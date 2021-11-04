using System.Numerics;

namespace Math
{
    public class AddService
    {
        IncrementService increment;
        DecrementService decrement;
        CompareService compare;
        NegateService negate;

        /// <summary>
        /// Создаёт новый новый экземпляр сервиса сложения чисел.
        /// </summary>
        /// <param name="increment">Сервис инкремента</param>
        /// <param name="decrement">Сервис декремента</param>
        /// <param name="compare">Сервис сравнения</param>
        /// <param name="negate">Сервис инверсии</param>
        public AddService(IncrementService increment, DecrementService decrement, CompareService compare, NegateService negate)
        {
            this.increment = increment;
            this.decrement = decrement;
            this.compare = compare;
            this.negate = negate;
        }

        /// <summary>
        /// Складывает два числа
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Сумма чисел</returns>
        public byte Add(byte a, byte b)
        {
            while(compare.Compare(b, (byte)0) == CompareService.BIGGER)
            {
                increment.Increment(ref a);
                decrement.Decrement(ref b);
            }
            return a;
        }

        /// <summary>
        /// Складывает два числа
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Сумма чисел</returns>
        public ushort Add(ushort a, ushort b)
        {
            while (compare.Compare(b, (ushort)0) == CompareService.BIGGER)
            {
                increment.Increment(ref a);
                decrement.Decrement(ref b);
            }
            return a;
        }

        /// <summary>
        /// Складывает два числа
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Сумма чисел</returns>
        public uint Add(uint a, uint b)
        {
            while (compare.Compare(b, 0) == CompareService.BIGGER)
            {
                increment.Increment(ref a);
                decrement.Decrement(ref b);
            }
            return a;
        }

        /// <summary>
        /// Складывает два числа
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Сумма чисел</returns>
        public ulong Add(ulong a, ulong b)
        {
            while (compare.Compare(b, 0) == CompareService.BIGGER)
            {
                increment.Increment(ref a);
                decrement.Decrement(ref b);
            }
            return a;
        }

        /// <summary>
        /// Складывает два числа
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Сумма чисел</returns>
        public sbyte Add(sbyte a, sbyte b)
        {
            if(compare.Compare(b, (sbyte)0) == CompareService.BIGGER)
                while (compare.Compare(b, (sbyte)0) == CompareService.BIGGER)
                {
                    increment.Increment(ref a);
                    decrement.Decrement(ref b);
                }
            else if (compare.Compare(b, (sbyte)0) == CompareService.SMALLER)
                while (compare.Compare(b, (sbyte)0) == CompareService.SMALLER)
                {
                    increment.Increment(ref a);
                    increment.Increment(ref b);
                }
            return a;
        }

        /// <summary>
        /// Складывает два числа
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Сумма чисел</returns>
        public short Add(short a, short b)
        {
            if (compare.Compare(b, (short)0) == CompareService.BIGGER)
                while (compare.Compare(b, (short)0) == CompareService.BIGGER)
                {
                    increment.Increment(ref a);
                    decrement.Decrement(ref b);
                }
            else if (compare.Compare(b, (short)0) == CompareService.SMALLER)
                while (compare.Compare(b, (short)0) == CompareService.SMALLER)
                {
                    increment.Increment(ref a);
                    increment.Increment(ref b);
                }
            return a;
        }

        /// <summary>
        /// Складывает два числа
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Сумма чисел</returns>
        public int Add(int a, int b)
        {
            if (compare.Compare(b, 0) == CompareService.BIGGER)
                while (compare.Compare(b, 0) == CompareService.BIGGER)
                {
                    increment.Increment(ref a);
                    decrement.Decrement(ref b);
                }
            else if (compare.Compare(b, 0) == CompareService.SMALLER)
                while (compare.Compare(b, 0) == CompareService.SMALLER)
                {
                    increment.Increment(ref a);
                    increment.Increment(ref b);
                }
            return a;
        }

        /// <summary>
        /// Складывает два числа
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Сумма чисел</returns>
        public long Add(long a, long b)
        {
            if (compare.Compare(b, 0) == CompareService.BIGGER)
                while (compare.Compare(b, 0) == CompareService.BIGGER)
                {
                    increment.Increment(ref a);
                    decrement.Decrement(ref b);
                }
            else if (compare.Compare(b, 0) == CompareService.SMALLER)
                while (compare.Compare(b, 0) == CompareService.SMALLER)
                {
                    increment.Increment(ref a);
                    increment.Increment(ref b);
                }
            return a;
        }

        /// <summary>
        /// Складывает два числа
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Сумма чисел</returns>
        public BigInteger Add(BigInteger a, BigInteger b)
        {
            if (compare.Compare(b, 0) == CompareService.BIGGER)
                while (compare.Compare(b, 0) == CompareService.BIGGER)
                {
                    increment.Increment(ref a);
                    decrement.Decrement(ref b);
                }
            else if (compare.Compare(b, 0) == CompareService.SMALLER)
                while (compare.Compare(b, 0) == CompareService.SMALLER)
                {
                    increment.Increment(ref a);
                    increment.Increment(ref b);
                }
            return a;
        }
    }
}
