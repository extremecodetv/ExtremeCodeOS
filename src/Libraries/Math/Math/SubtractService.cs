using System.Numerics;

namespace Math
{
    public class SubtractService
    {
        AddService add;
        NegateService negate;
        /// <summary>
        /// Создаёт новый новый экземпляр сервиса вычитания чисел.
        /// </summary>
        /// <param name="add">Сервис сложения</param>
        /// <param name="negate">Сервис инверсии</param>
        public SubtractService(AddService add, NegateService negate)
        {
            this.add = add;
            this.negate = negate;
        }

        /// <summary>
        /// Вычиает из одного числа другое
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Разность чисел</returns>
        public sbyte Subtract(sbyte a, sbyte b)
        {
            negate.Negate(ref b);
            return add.Add(a, b);
        }

        /// <summary>
        /// Вычиает из одного числа другое
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Разность чисел</returns>
        public short Subtract(short a, short b)
        {
            negate.Negate(ref b);
            return add.Add(a, b);
        }

        /// <summary>
        /// Вычиает из одного числа другое
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Разность чисел</returns>
        public int Subtract(int a, int b)
        {
            negate.Negate(ref b);
            return add.Add(a, b);
        }

        /// <summary>
        /// Вычиает из одного числа другое
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Разность чисел</returns>
        public long Subtract(long a, long b)
        {
            negate.Negate(ref b);
            return add.Add(a, b);
        }

        /// <summary>
        /// Вычиает из одного числа другое
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Разность чисел</returns>
        public byte Subtract(byte a, byte b) => (byte)Subtract((short)a, b);

        /// <summary>
        /// Вычиает из одного числа другое
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Разность чисел</returns>
        public ushort Subtract(ushort a, ushort b) => (ushort)Subtract((int)a, b);

        /// <summary>
        /// Вычиает из одного числа другое
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Разность чисел</returns>
        public uint Subtract(uint a, uint b) => (uint)Subtract((long)a, b);

        /// <summary>
        /// Вычиает из одного числа другое
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Разность чисел</returns>
        public ulong Subtract(ulong a, ulong b) => (ulong)Subtract((BigInteger)a, b);

        /// <summary>
        /// Вычиает из одного числа другое
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns>Разность чисел</returns>
        public BigInteger Subtract(BigInteger a, BigInteger b)
        {
            negate.Negate(ref b);
            return add.Add(a, b);
        }
    }
}
