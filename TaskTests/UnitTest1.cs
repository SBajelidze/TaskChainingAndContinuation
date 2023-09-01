#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using TaskChainExample;

namespace TaskChainExample.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public async Task Test_Task1()
        {
            int[] result = await Program.Task1();

            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Length);
        }

        [TestMethod]
        [DataRow(new int[] { 11, 2, 39, 24, 52, 16, 74, 28, 9, 12 })]
        [DataRow(new int[] { 10, 14, 8, 17, 6, 5, 23, 3, 22, 11 })]
        [DataRow(new int[] { 53, 14, 61, 3, 7, 22, 38, 21, 9, 40 })]
        public async Task Test_Task2(int[] inputArray)
        {
            int[] result = await Program.Task2(inputArray);

            Assert.IsNotNull(result);
            Assert.AreEqual(inputArray.Length, result.Length);

            int multiplier = Program.GetRandomMultiplier();
            CollectionAssert.AreEqual(inputArray.Select(x => x * multiplier).ToArray(), result);
        }

        [TestMethod]
        [DataRow(new int[] { 11, 2, 39, 24, 52, 16, 74, 28, 9, 12 })]
        [DataRow(new int[] { 10, 14, 8, 17, 6, 5, 23, 3, 22, 11 })]
        [DataRow(new int[] { 53, 14, 61, 3, 7, 22, 38, 21, 9, 40 })]
        public async Task Test_Task3(int[] inputArray)
        {
            int[] result = await Program.Task3(inputArray);

            Assert.IsNotNull(result);
            Assert.AreEqual(inputArray.Length, result.Length);
            CollectionAssert.AreEqual(inputArray.OrderBy(x => x).ToArray(), result);
        }

        [TestMethod]
        [DataRow(new int[] { 11, 2, 39, 24, 52, 16, 74, 28, 9, 12 })]
        [DataRow(new int[] { 10, 14, 8, 17, 6, 5, 23, 3, 22, 11 })]
        [DataRow(new int[] { 53, 14, 61, 3, 7, 22, 38, 21, 9, 40 })]
        public async Task Test_Task4(int[] inputArray)
        {
            double expectedResult = inputArray.Average();

            double actualResult = await Program.Task4(inputArray);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public async Task Test_Task2_NullArray_ThrowsException()
        {
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => Program.Task2(null));
        }

        [TestMethod]
        public async Task Test_Task3_NullArray_ThrowsException()
        {
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => Program.Task3(null));
        }

        [TestMethod]
        public async Task Test_Task4_NullArray_ThrowsException()
        {
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => Program.Task4(null));
        }
    }
}
