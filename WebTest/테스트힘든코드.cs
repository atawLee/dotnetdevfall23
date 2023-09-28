using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mesWeb.Database.Entity;
using mesWeb.Repository;
using mesWeb.Service;
using Moq;

namespace WebTest
{
    public class 테스트힘든코드
    {
        [Fact]
        public void 생산시작()
        {
            //준비코드 
            //suit
            var testSuit = new UnTestableMesService();

            //case
            testSuit.AddManufacture(0, "manufactureSummary", "Lee");
        }
    }
}
