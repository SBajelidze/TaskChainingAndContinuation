using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using TaskChainExample;

namespace TaskChainExample.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test_Task1()
        {
            int[] result = Program.Task1();

            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Length);
        }

        [TestMethod]
        [DataRow(new int[] { 11, 2, 39, 24, 52, 16, 74, 28, 9, 12 })]
        [DataRow(new int[] { 10, 14, 8, 17, 6, 5, 23, 3, 22, 11 })]
        [DataRow(new int[] { 53, 14, 61, 3, 7, 22, 38, 21, 9, 40 })]
        public void Test_Task2(int[] inputArray)
        {
            int[] result = Program.Task2(inputArray);

            Assert.IsNotNull(result);
            Assert.AreEqual(inputArray.Length, result.Length);

            int multiplier = Program.GetRandomMultiplier();
            CollectionAssert.AreEqual(inputArray.Select(x => x * multiplier).ToArray(), result);
        }

        [TestMethod]
        [DataRow(new int[] { 11, 2, 39, 24, 52, 16, 74, 28, 9, 12 })]
        [DataRow(new int[] { 10, 14, 8, 17, 6, 5, 23, 3, 22, 11 })]
        [DataRow(new int[] { 53, 14, 61, 3, 7, 22, 38, 21, 9, 40 })]
        public void Test_Task3(int[] inputArray)
        {
            int[] result = Program.Task3(inputArray);

            Assert.IsNotNull(result);
            Assert.AreEqual(inputArray.Length, result.Length);
            CollectionAssert.AreEqual(inputArray.OrderBy(x => x).ToArray(), result);
        }

        [TestMethod]
        [DataRow(new int[] { 11, 2, 39, 24, 52, 16, 74, 28, 9, 12 })]
        [DataRow(new int[] { 10, 14, 8, 17, 6, 5, 23, 3, 22, 11 })]
        [DataRow(new int[] { 53, 14, 61, 3, 7, 22, 38, 21, 9, 40 })]
        public void Test_Task4(int[] inputArray)
        {
            double expectedResult = inputArray.Average();

            double actualResult = Program.Task4(inputArray);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}