using System.Numerics;

namespace Math
{
    /// <summary>
    /// Сервис, реализующий инверсию числа.
    /// </summary>
    public class NegateService
    {
        IncrementService increment;

        /// <summary>
        /// Создаёт новый экземпляр сервиса инверсии числа.
        /// </summary>
        /// <param name="increment">Сервис инкремента</param>
        public NegateService(IncrementService increment) => this.increment = increment;

        /// <summary>
        /// Меняет знак числа.
        /// </summary>
        /// <param name="val">Изменяемое число</param>
        public void Negate(ref sbyte val)
        {
            val = (sbyte)~val;
            increment.Increment(ref val);
        }

        /// <summary>
        /// Меняет знак числа.
        /// </summary>
        /// <param name="val">Изменяемое число</param>
        public void Negate(ref short val)
        {
            val = (short)~val;
            increment.Increment(ref val);
        }

        /// <summary>
        /// Меняет знак числа.
        /// </summary>
        /// <param name="val">Изменяемое число</param>
        public void Negate(ref int val)
        {
            val = ~val;
            increment.Increment(ref val);
        }

        /// <summary>
        /// Меняет знак числа.
        /// </summary>
        /// <param name="val">Изменяемое число</param>
        public void Negate(ref long val)
        {
            val = ~val;
            increment.Increment(ref val);
        }

        /// <summary>
        /// Меняет знак числа.
        /// </summary>
        /// <param name="val">Изменяемое число</param>
        public void Negate(ref float val) => val = -val;

        /// <summary>
        /// Меняет знак числа.
        /// </summary>
        /// <param name="val">Изменяемое число</param>
        public void Negate(ref double val) => val = -val;

        /// <summary>
        /// Меняет знак числа.
        /// </summary>
        /// <param name="val">Изменяемое число</param>
        public void Negate(ref decimal val) => val = -val;

        /// <summary>
        /// Меняет знак числа.
        /// </summary>
        /// <param name="val">Изменяемое число</param>
        public void Negate(ref BigInteger val)
        {
            val = ~val;
            increment.Increment(ref val);
        }
    }
}
