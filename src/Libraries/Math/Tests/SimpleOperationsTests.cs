using Math;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Numerics;

namespace Tests
{
    [TestClass]
    public class SimpleOperationsTests
    {
        ServiceProvider services;
        public SimpleOperationsTests()
        {
            ServiceCollection collection = new();
            collection.AddSingleton<IncrementService>();
            collection.AddSingleton<NegateService>();
            collection.AddSingleton<DecrementService>();
            services = collection.BuildServiceProvider();
        }

        [TestMethod]
        public void TestIncrementUnsigned()
        {
            var increment = services.GetRequiredService<IncrementService>();
            //byte
            {
                byte val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(1, val);
                val = byte.MaxValue;
                Assert.ThrowsException<OverflowException>(() => increment.Increment(ref val));
            }
            //ushort
            {
                ushort val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(1, val);
                val = ushort.MaxValue;
                Assert.ThrowsException<OverflowException>(() => increment.Increment(ref val));
            }
            //uint
            {
                uint val = 0;
                increment.Increment(ref val);
                Assert.AreEqual((uint)1, val);
                val = uint.MaxValue;
                Assert.ThrowsException<OverflowException>(() => increment.Increment(ref val));
            }
            //ulong
            {
                ulong val = 0;
                increment.Increment(ref val);
                Assert.AreEqual((ulong)1, val);
                val = ulong.MaxValue;
                Assert.ThrowsException<OverflowException>(() => increment.Increment(ref val));
            }
        }

        [TestMethod]
        public void TestIncrementSigned()
        {
            var increment = services.GetRequiredService<IncrementService>();
            //sbyte
            {
                sbyte val = sbyte.MinValue;
                increment.Increment(ref val);
                Assert.AreEqual(sbyte.MinValue + 1, val);
                val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(1, val);
                val = sbyte.MaxValue;
                Assert.ThrowsException<OverflowException>(() => increment.Increment(ref val));
            }
            //short
            {
                short val = short.MinValue;
                increment.Increment(ref val);
                Assert.AreEqual(short.MinValue + 1, val);
                val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(1, val);
                val = short.MaxValue;
                Assert.ThrowsException<OverflowException>(() => increment.Increment(ref val));
            }
            //int
            {
                int val = int.MinValue;
                increment.Increment(ref val);
                Assert.AreEqual(int.MinValue + 1, val);
                val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(1, val);
                val = int.MaxValue;
                Assert.ThrowsException<OverflowException>(() => increment.Increment(ref val));
            }
            //long
            {
                long val = long.MinValue;
                increment.Increment(ref val);
                Assert.AreEqual(long.MinValue + 1, val);
                val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(1, val);
                val = long.MaxValue;
                Assert.ThrowsException<OverflowException>(() => increment.Increment(ref val));
            }
            //BigInteger
            {
                BigInteger val = -1;
                increment.Increment(ref val);
                Assert.AreEqual(0, val);
                increment.Increment(ref val);
                Assert.AreEqual(1, val);
            }
        }

        [TestMethod]
        public void TestIncrementFloat()
        {
            var increment = services.GetRequiredService<IncrementService>();
            //float
            {
                float val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(1, val, 1e-8);
                val = -3;
                increment.Increment(ref val);
                Assert.AreEqual(-2, val, 1e-8);
                val = -3.75f;
                increment.Increment(ref val);
                Assert.AreEqual(-2.75f, val, 1e-8);
            }
            //double
            {
                double val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(1, val, 1e-15);
                val = -3;
                increment.Increment(ref val);
                Assert.AreEqual(-2, val, 1e-15);
                val = -3.75f;
                increment.Increment(ref val);
                Assert.AreEqual(-2.75f, val, 1e-8);
            }
            //decimal
            {
                decimal val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(1, val);
                val = -3;
                increment.Increment(ref val);
                Assert.AreEqual(-2, val);
                val = -3.75m;
                increment.Increment(ref val);
                Assert.AreEqual(-2.75m, val);
                val = decimal.MaxValue;
                Assert.ThrowsException<OverflowException>(() => increment.Increment(ref val));
            }
        }

        [TestMethod]
        public void TestInverseInteger()
        {
            var negate = services.GetRequiredService<NegateService>();
            //sbyte
            {
                sbyte val = 0;
                negate.Negate(ref val);
                Assert.AreEqual(0, val);
                val = 12;
                negate.Negate(ref val);
                Assert.AreEqual(-12, val);
                negate.Negate(ref val);
                Assert.AreEqual(12, val);
            }
            //short
            {
                short val = 0;
                negate.Negate(ref val);
                Assert.AreEqual(0, val);
                val = 1234;
                negate.Negate(ref val);
                Assert.AreEqual(-1234, val);
                negate.Negate(ref val);
                Assert.AreEqual(1234, val);
            }
            //int
            {
                int val = 0;
                negate.Negate(ref val);
                Assert.AreEqual(0, val);
                val = 123456;
                negate.Negate(ref val);
                Assert.AreEqual(-123456, val);
                negate.Negate(ref val);
                Assert.AreEqual(123456, val);
            }
            //long
            {
                long val = 0;
                negate.Negate(ref val);
                Assert.AreEqual(0, val);
                val = 9876543210;
                negate.Negate(ref val);
                Assert.AreEqual(-9876543210, val);
                negate.Negate(ref val);
                Assert.AreEqual(9876543210, val);
            }
            //BigInteger
            {
                BigInteger val = 0, somebig = new(new byte[] { 255, 0, 0, 0, 0, 0, 0, 0, 0 });
                negate.Negate(ref val);
                Assert.AreEqual(0, val);
                val = somebig;
                negate.Negate(ref val);
                Assert.AreEqual(-somebig, val);
                negate.Negate(ref val);
                Assert.AreEqual(somebig, val);
            }
        }

        [TestMethod]
        public void TestInverseFloat()
        {
            var negate = services.GetRequiredService<NegateService>();
            //float 
            {
                float val = 0;
                negate.Negate(ref val);
                Assert.AreEqual(0, val);
                val = 1234.5678f;
                negate.Negate(ref val);
                Assert.AreEqual(-1234.5678f, val);
                negate.Negate(ref val);
                Assert.AreEqual(1234.5678f, val);
            }
            //double
            {
                double val = 0;
                negate.Negate(ref val);
                Assert.AreEqual(0, val);
                val = 1234.5678f;
                negate.Negate(ref val);
                Assert.AreEqual(-1234.5678f, val);
                negate.Negate(ref val);
                Assert.AreEqual(1234.5678f, val);
            }
        }

        [TestMethod]
        public void TestDecrementUnsigned()
        {
            var decrement = services.GetRequiredService<DecrementService>();
            //byte
            {
                byte val = 1;
                decrement.Decrement(ref val);
                Assert.AreEqual(0, val);
            }
            //ushort
            {
                ushort val = 1;
                decrement.Decrement(ref val);
                Assert.AreEqual(0, val);
            }
            //uint
            {
                uint val = 1;
                decrement.Decrement(ref val);
                Assert.AreEqual<uint>(0, val);
            }
            //ulong
            {
                ulong val = 1;
                decrement.Decrement(ref val);
                Assert.AreEqual<ulong>(0, val);
            }
        }

        [TestMethod]
        public void TestDecrementSigned()
        {
            var decrement = services.GetRequiredService<DecrementService>();
            //sbyte
            {
                sbyte val = 1;
                decrement.Decrement(ref val);
                Assert.AreEqual(0, val);
                decrement.Decrement(ref val);
                Assert.AreEqual(-1, val);
                val = sbyte.MinValue;
                Assert.ThrowsException<OverflowException>(() => decrement.Decrement(ref val));
            }
            //short
            {
                short val = 1;
                decrement.Decrement(ref val);
                Assert.AreEqual(0, val);
                decrement.Decrement(ref val);
                Assert.AreEqual(-1, val);
                val = short.MinValue;
                Assert.ThrowsException<OverflowException>(() => decrement.Decrement(ref val));
            }
            //int
            {
                int val = 1;
                decrement.Decrement(ref val);
                Assert.AreEqual(0, val);
                decrement.Decrement(ref val);
                Assert.AreEqual(-1, val);
                val = int.MinValue;
                Assert.ThrowsException<OverflowException>(() => decrement.Decrement(ref val));
            }
            //long
            {
                long val = 1;
                decrement.Decrement(ref val);
                Assert.AreEqual(0, val);
                decrement.Decrement(ref val);
                Assert.AreEqual(-1, val);
                val = long.MinValue;
                Assert.ThrowsException<OverflowException>(() => decrement.Decrement(ref val));
            }
            //BigInteger
            {
                BigInteger val = 1;
                decrement.Decrement(ref val);
                Assert.AreEqual(0, val);
                decrement.Decrement(ref val);
                Assert.AreEqual(-1, val);
            }
        }

        [TestMethod]
        public void TestDecrementFloat()
        {
            var decrement = services.GetRequiredService<DecrementService>();
            //float
            {
                float val = 0;
                decrement.Decrement(ref val);
                Assert.AreEqual(-1, val, 1e-8);
                val = -3;
                decrement.Decrement(ref val);
                Assert.AreEqual(-4, val, 1e-8);
                val = -3.75f;
                decrement.Decrement(ref val);
                Assert.AreEqual(-4.75f, val, 1e-8);
            }
            //double
            {
                double val = 0;
                decrement.Decrement(ref val);
                Assert.AreEqual(-1, val, 1e-15);
                val = -3;
                decrement.Decrement(ref val);
                Assert.AreEqual(-4, val, 1e-15);
                val = -3.75f;
                decrement.Decrement(ref val);
                Assert.AreEqual(-4.75f, val, 1e-15);
            }
            //decimal
            {
                decimal val = 0;
                decrement.Decrement(ref val);
                Assert.AreEqual(-1, val);
                val = -3;
                decrement.Decrement(ref val);
                Assert.AreEqual(-4, val);
                val = -3.75m;
                decrement.Decrement(ref val);
                Assert.AreEqual(-4.75m, val);
                val = decimal.MinValue;
                Assert.ThrowsException<OverflowException>(() => decrement.Decrement(ref val));
            }
        }
    }
}
