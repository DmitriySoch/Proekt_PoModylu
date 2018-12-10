using NUnit.Framework;
using System;
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

        public static int[] StartPoint(int[] first, int[] second)
        {
            first_Mnoj = new int[4];
            second_Mnoj = new int[4];
            result = new int[8];
            for (var i = 3; i >= 0; i--)
            {
                MainAlgoritm(first[i], second[i], -(i - 3));
            }
            return result.Reverse().ToArray();
        }

        private static void MainAlgoritm(int first, int second, int i)
        {
            first_Mnoj[i] = first;
            second_Mnoj[i] = second;
            for (var j = 0; j < i; j++)
            {
                if (second * first_Mnoj[j] == 1)
                    MetodPribavlenia(i + j);
                if (first * second_Mnoj[j] == 1)
                    MetodPribavlenia(i + j);
            }
            if (first * second == 1)
                MetodPribavlenia(2 * i);
        }

        public static void MetodPribavlenia(int pos)
        {
            for (; pos <= 8; pos++)
            {
                if (result[pos] == 1)
                {
                    result[pos] = 0;
                    continue;
                }
                else
                {
                    result[pos]++;
                    break;
                }
            }
        }
    }

    [TestFixture]
    public static class Tests
    {
        [Test]
        public static void First_Test()
        {
            var first = new int[] { 0, 0, 0, 1 };
            var second = new int[] { 0, 0, 0, 1 };
            var result = new int[] { 0, 0, 0, 0, 0, 0, 0, 1 };
            Assert.AreEqual(result, Program.StartPoint(first, second));
        }

        [Test]
        public static void Second_Test()
        {
            for (var i = 0; i < 16; i++)
                for (var j = 0; j < 16; j++)
                {
                    var a = Convert.ToString(Convert.ToInt32(i.ToString(), 10), 2);
                    var b = Convert.ToString(Convert.ToInt32(j.ToString(), 10), 2);
                    var a1 = a.Insert(0, new String('0', 4 - a.Length));
                    var b1 = b.Insert(0, new String('0', 4 - b.Length));
                    var res = Convert.ToString(Convert.ToInt32((i * j).ToString(), 10), 2);
                    var res1 = res.Insert(0, new String('0', 8 - res.Length));
                    Assert.AreEqual(res1, string.Join("",
                        Program.StartPoint(
                            a1.Select(x => int.Parse(x.ToString())).ToArray(),
                            b1.Select(x => int.Parse(x.ToString())).ToArray()))
                            );
                }

        }
    }
}
