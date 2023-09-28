using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTest.테스트_도구_설명용
{
    public class CalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 1, 2, 3 }; // 1 + 2 = 3
            yield return new object[] { -1, -1, -2 }; // -1 + (-1) = -2
            yield return new object[] { 2, 2, 4 }; // 2 + 2 = 4
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class ClassDataTest
    {
        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void IEnumerable_GetEnumerator로지정한데이터테스트(int a, int b, int expected)
        {
            Assert.Equal(expected, a+b);
        }
    }

}
