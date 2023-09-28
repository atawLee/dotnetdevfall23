using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mesWeb.Service;

namespace WebTest
{
    public class 유닛테스트힘든부분
    {
        [Fact]
        public void 힘든부분설명용()
        {
            UnTestableMesService service = new();

            //DB에 의존한 테스트만 가능 
            //재사용이 대체적으로 불가능한 테스트코드 
            service.AddManufacture(0, "test","test");

            //정확히 삽입한 내용은 get해서 가져와서 직접확인할 수밖에 없음.
        }
    }
}
