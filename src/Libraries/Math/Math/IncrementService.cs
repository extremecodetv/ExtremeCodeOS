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
        public void Increment(ref byte val) => val=checked((byte)(val+1));

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref ushort val) => val = checked((ushort)(val+1));

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref uint val) => val = checked(val+1);

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref ulong val) => val = checked(val+1);

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref sbyte val) => val = checked((sbyte)(val+1));

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref short val) => val = checked((short)(val+1));

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref int val) => val = checked(val+1);

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref long val) => val = checked(val+1);

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref float val) => val = checked(val + 1);

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref double val) => val = checked(val + 1);

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref decimal val) => val = checked(val + 1);

        /// <summary>
        /// Увеличивает значение числа на единицу.
        /// </summary>
        /// <param name="val">Значение, которое необходимо увеличить</param>
        public void Increment(ref BigInteger val) => val-=-1;
    }
}