using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mesWeb.Database.Entity;
using mesWeb.Repository;

namespace WebTest
{
    
    public class 테스트도구설명용_기본
    {
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(4, 5, 9)]
        [Trait("OS", "window")]
        public void TheroyTestSample(int a, int b, int result)
        {
            Assert.Equal(result, a + b);
        }
        

        [Fact]
        public void FactSample()
        {
            var a = 1;
            var b = 2;

            Assert.Equal(a + b, 3);

        }

        [Fact]
        public void Assert설명용()
        {
            int a = 1;
            User nullUser = null;
            User user1 = new();
            User user2 = new();
            List<User> users = new();

            //값비교
            Assert.Equal(1, a);
            Assert.NotEqual(0, a);

            //참조비교
            Assert.Same(user1,user1);
            Assert.NotSame(user1,user2);

            //널 체크 
            Assert.Null(nullUser);
            Assert.NotNull(user1);

            //의도한 에러가나는지 확인 
            Assert.Throws<NullReferenceException>(() =>
            {
                nullUser.Name = "Null Exception";
            });

          
        }


    }


    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

}
