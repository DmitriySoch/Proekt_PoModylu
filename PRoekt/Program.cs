using NUnit.Framework;
using System.Linq;

namespace PRoekt
{
    class Program
    {
        private static int[] first_Mnoj;
        private static int[] second_Mnoj;
        private static int[] result;

        static void Main(string[] args)
        {
        }

        public static int[] StartPoint(byte[] first, byte[] second)
        {
            first_Mnoj = new int[4];
            second_Mnoj = new int[4];
            result = new int[8];
            for (var i = 3; i >= 0; i--)
            {
                MainAlgoritm(first[i], second[i],-(i-3));
            }
            return result.Reverse().ToArray();
        }

        private static void MainAlgoritm(int first, int second, int i)
        {
            //Добавить перенос в двоичной системе 1+1 = 10 а не 2
            first_Mnoj[i] = first;
            second_Mnoj[i] = second;
            for (var j = 0; j < i; j++)
            {
                result[i + j] += second * first_Mnoj[j];
                result[i + j] += first * second_Mnoj[j];
            }
            result[2 * i] = first * second;
        }
    }
                                                 
    [TestFixture]
    public static class Tests
    {
         [Test]
         public static void First_Test()
        { 
            var first = new byte[] { 0, 0, 0, 1 };
            var second = new byte[] { 0, 0, 0, 1 };
            var result = new byte[] { 0, 0, 0, 0, 0, 0, 0, 1 };
            Assert.AreEqual(result, Program.StartPoint(first, second));
        }
    }
}
