using System.Numerics;

namespace Math
{
    /// <summary>
    /// Сервис, реализующий инкремент числа.
    /// </summary>
    public class IncrementService
    {
        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref byte val) => val++;

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref ushort val) => val++;

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref uint val) => val++;

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref ulong val) => val++;

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref sbyte val) => val-=-1;

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref short val) => val-=-1;

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref int val) => val-=-1;

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref long val) => val-=-1;

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref float val) => val-=-1;

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref double val) => val-=-1;

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref decimal val) => val-=-1;

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref BigInteger val) => val-=-1;
    }
}