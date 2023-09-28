using mesWeb.Database.Entity;
using mesWeb.Repository;
using mesWeb.Service;
using Moq;
using Xunit;

namespace WebTest;

public class 서비스유닛테스트
{
    // ... 기존의 테스트 코드 ...

    [Fact]
    public void 생산시작()
    {
        //준비코드 
        Mock<IRepository<Manufacture>> moqMnf = new ();
        var mockWorkOrderRepo = new Mock<IRepository<WorkOrder>>();
        WorkOrder workorder = new()
        {
            Id = 0,
            Description = "Test",
            Product = "TestProduct",
            TargetQty = 100,
            OrderUser = "Foo",
            DueDate = DateTime.Now,
            ExpireDate = DateTime.Now.AddYears(1),
            CreateDateTime = DateTime.Now
        };
        mockWorkOrderRepo.Setup(x => x.GetById(0)).Returns(workorder);
        
        //suit
        var testSuit = new ManufactureWorkOrderService(moqMnf.Object, mockWorkOrderRepo.Object);
        
        //case
        testSuit.AddManufacture(0,"manufactureSummary","Lee");

        moqMnf.Verify(m => m.Add(It.IsAny<Manufacture>()), Times.Once);
    }

    [Fact]
    public void 시작_작지유효성_확인()
    {
        //Arrange 
        

       
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void 작지유효성확인(int workOrderId)
    {
        Mock<IRepository<Manufacture>> moqMnf = new();
        Mock<IRepository<WorkOrder>> moqWorkOrder = new();
        List<WorkOrder> workOrders = new();

        WorkOrder workOrderItem = new()
        {
            Id = 0,
            Description = "Test",
            Product = "TestProduct",
            TargetQty = 100,
            OrderUser = "Foo",
            DueDate = DateTime.Now,
            ExpireDate = DateTime.Now.AddYears(-1),
            CreateDateTime = DateTime.Now
        };
        workOrderItem.ExpireDate = DateTime.Now.AddYears(-1);
        workOrderItem.Id = 0;
        workOrders.Add(workOrderItem);

        int callback = 0;
        moqWorkOrder
            .Setup(x => x.GetById(It.IsAny<int>()))
            .Callback<int>((id) => { callback = id;})
            .Returns((int id) => workOrders.FirstOrDefault(x => x.Id == id)); 
        
        //suit
        var testSuit = new ManufactureWorkOrderService(moqMnf.Object, moqWorkOrder.Object);
        moqWorkOrder.Verify(x=>x.GetById(It.IsAny<int>()),Times.Once);
        try
        {
            //Act 
            testSuit.AddManufacture(workOrderId, "manufactureSummary", "Lee");
            //Assert
            Assert.Fail("유효성 검사에 문제가 있음.");
        }
        catch (Exception)
        {
            // ignored
        }
    }

    [Fact]
    public void 생산업데이트()
    {
        var mockManufactureRepo = new Mock<IRepository<Manufacture>>();
        var mockWorkOrderRepo = new Mock<IRepository<WorkOrder>>();

        var service = new ManufactureWorkOrderService(mockManufactureRepo.Object, mockWorkOrderRepo.Object);

        var manufacture = new Manufacture { Summary = "Updated Manufacture" };
        service.UpdateManufacture(manufacture);

        mockManufactureRepo.Verify(repo => repo.Update(manufacture), Times.Once());
    }

    [Fact]
    public void 생산삭제()
    {
        var mockManufactureRepo = new Mock<IRepository<Manufacture>>();
        var mockWorkOrderRepo = new Mock<IRepository<WorkOrder>>();

        var service = new ManufactureWorkOrderService(mockManufactureRepo.Object, mockWorkOrderRepo.Object);

        int manufactureId = 1;
        service.DeleteManufacture(manufactureId);

        mockManufactureRepo.Verify(repo => repo.Delete(manufactureId), Times.Once());
    }

    [Fact]
    public void 작업지시추가()
    {
        var mockManufactureRepo = new Mock<IRepository<Manufacture>>();
        var mockWorkOrderRepo = new Mock<IRepository<WorkOrder>>();

        var service = new ManufactureWorkOrderService(mockManufactureRepo.Object, mockWorkOrderRepo.Object);

        var workOrder = new WorkOrder { Description = "New WorkOrder" };
        service.AddWorkOrder(workOrder);

        mockWorkOrderRepo.Verify(repo => repo.Add(workOrder), Times.Once());
    }

    [Fact]
    public void 작업지시변경()
    {
        var mockManufactureRepo = new Mock<IRepository<Manufacture>>();
        var mockWorkOrderRepo = new Mock<IRepository<WorkOrder>>();

        var service = new ManufactureWorkOrderService(mockManufactureRepo.Object, mockWorkOrderRepo.Object);

        var workOrder = new WorkOrder { Description = "Updated WorkOrder" };
        service.UpdateWorkOrder(workOrder);

        mockWorkOrderRepo.Verify(repo => repo.Update(workOrder), Times.Once());
    }

    [Fact]
    public void 작업지시삭제()
    {
        var mockManufactureRepo = new Mock<IRepository<Manufacture>>();
        var mockWorkOrderRepo = new Mock<IRepository<WorkOrder>>();

        var service = new ManufactureWorkOrderService(mockManufactureRepo.Object, mockWorkOrderRepo.Object);

        int workOrderId = 1;
        service.DeleteWorkOrder(workOrderId);

        mockWorkOrderRepo.Verify(repo => repo.Delete(workOrderId), Times.Once());
    }
}

