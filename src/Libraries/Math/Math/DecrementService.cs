using System.Numerics;

namespace Math
{
    /// <summary>
    /// Сервис, реализующий декремент числа.
    /// </summary>
    public class DecrementService
    {
        IncrementService increment;
        NegateService negate;

        /// <summary>
        /// Создаёт новый экземпляр сервиса декремента числа.
        /// </summary>
        /// <param name="increment">Сервис инкремента</param>
        /// <param name="negate">Сервис инверсии</param>
        public DecrementService(IncrementService increment, NegateService negate)
        {
            this.increment = increment;
            this.negate = negate;
        }

        /// <summary>
        /// Уменьшает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо уменьшить</param>
        public void Decrement(ref byte val)
        {
            short vl = val;
            negate.Negate(ref vl);
            increment.Increment(ref vl);
            negate.Negate(ref vl);
            val = (byte)vl;
        }

        /// <summary>
        /// Уменьшает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо уменьшить</param>
        public void Decrement(ref sbyte val)
        {
            negate.Negate(ref val);
            increment.Increment(ref val);
            negate.Negate(ref val);
        }

        /// <summary>
        /// Уменьшает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо уменьшить</param>
        public void Decrement(ref short val)
        {
            negate.Negate(ref val);
            increment.Increment(ref val);
            negate.Negate(ref val);
        }

        /// <summary>
        /// Уменьшает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо уменьшить</param>
        public void Decrement(ref ushort val)
        {
            int vl = val;
            negate.Negate(ref vl);
            increment.Increment(ref vl);
            negate.Negate(ref vl);
            val = (ushort)vl;
        }

        /// <summary>
        /// Уменьшает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо уменьшить</param>
        public void Decrement(ref int val)
        {
            negate.Negate(ref val);
            increment.Increment(ref val);
            negate.Negate(ref val);
        }

        /// <summary>
        /// Уменьшает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо уменьшить</param>
        public void Decrement(ref uint val)
        {
            long vl = val;
            negate.Negate(ref vl);
            increment.Increment(ref vl);
            negate.Negate(ref vl);
            val = (uint)vl;
        }

        /// <summary>
        /// Уменьшает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо уменьшить</param>
        public void Decrement(ref long val)
        {
            negate.Negate(ref val);
            increment.Increment(ref val);
            negate.Negate(ref val);
        }

        /// <summary>
        /// Уменьшает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо уменьшить</param>
        public void Decrement(ref ulong val)
        {
            BigInteger vl = val;
            negate.Negate(ref vl);
            increment.Increment(ref vl);
            negate.Negate(ref vl);
            val = (ulong)vl;
        }

        /// <summary>
        /// Уменьшает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо уменьшить</param>
        public void Decrement(ref float val)
        {
            negate.Negate(ref val);
            increment.Increment(ref val);
            negate.Negate(ref val);
        }

        /// <summary>
        /// Уменьшает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо уменьшить</param>
        public void Decrement(ref double val)
        {
            negate.Negate(ref val);
            increment.Increment(ref val);
            negate.Negate(ref val);
        }

        /// <summary>
        /// Уменьшает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо уменьшить</param>
        public void Decrement(ref decimal val)
        {
            negate.Negate(ref val);
            increment.Increment(ref val);
            negate.Negate(ref val);
        }

        /// <summary>
        /// Уменьшает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо уменьшить</param>
        public void Decrement(ref BigInteger val)
        {
            negate.Negate(ref val);
            increment.Increment(ref val);
            negate.Negate(ref val);
        }
    }
}
