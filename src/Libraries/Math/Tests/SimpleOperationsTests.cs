using Math;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
                Assert.AreEqual(val, 1);
                val = byte.MaxValue;
                Assert.ThrowsException<OverflowException>(() => increment.Increment(ref val));
            }
            //ushort
            {
                ushort val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(val, 1);
                val = ushort.MaxValue;
                Assert.ThrowsException<OverflowException>(() => increment.Increment(ref val));
            }
            //uint
            {
                uint val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(val, (uint)1);
                val = uint.MaxValue;
                Assert.ThrowsException<OverflowException>(() => increment.Increment(ref val));
            }
            //ulong
            {
                ulong val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(val, (ulong)1);
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
                Assert.AreEqual(val, sbyte.MinValue+1);
                val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(val, 1);
                val = sbyte.MaxValue;
                Assert.ThrowsException<OverflowException>(() => increment.Increment(ref val));
            }
            //short
            {
                short val = short.MinValue;
                increment.Increment(ref val);
                Assert.AreEqual(val, short.MinValue + 1);
                val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(val, 1);
                val = short.MaxValue;
                Assert.ThrowsException<OverflowException>(() => increment.Increment(ref val));
            }
            //int
            {
                int val = int.MinValue;
                increment.Increment(ref val);
                Assert.AreEqual(val, int.MinValue + 1);
                val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(val, 1);
                val = int.MaxValue;
                Assert.ThrowsException<OverflowException>(() => increment.Increment(ref val));
            }
            //long
            {
                long val = long.MinValue;
                increment.Increment(ref val);
                Assert.AreEqual(val, long.MinValue + 1);
                val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(val, 1);
                val = long.MaxValue;
                Assert.ThrowsException<OverflowException>(() => increment.Increment(ref val));
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
                Assert.AreEqual(val, 1);
                val = -3;
                increment.Increment(ref val);
                Assert.AreEqual(val, -2);
                val = -3.75f;
                increment.Increment(ref val);
                Assert.IsTrue(System.Math.Abs(val+2.75f) < 1e-8f);
            }
            //double
            {
                double val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(val, 1);
                val = -3;
                increment.Increment(ref val);
                Assert.AreEqual(val, -2);
                val = -3.75f;
                increment.Increment(ref val);
                Assert.IsTrue(System.Math.Abs(val + 2.75f) < 1e-8f);
            }
            //decimal
            {
                decimal val = 0;
                increment.Increment(ref val);
                Assert.AreEqual(val, 1);
                val = -3;
                increment.Increment(ref val);
                Assert.AreEqual(val, -2);
                val = -3.75m;
                increment.Increment(ref val);
                Assert.AreEqual(val, -2.75m);
                val = decimal.MaxValue;
                Assert.ThrowsException<OverflowException>(() => increment.Increment(ref val));
            }
        }
    }
}
