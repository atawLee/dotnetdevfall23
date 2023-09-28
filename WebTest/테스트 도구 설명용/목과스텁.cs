using mesWeb.Database.Entity;
using mesWeb.Repository;
using mesWeb.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTest.테스트_도구_설명용;

public class 목과스텁
{
    [Fact]
    public void 스텁테스트코드()
    {
        //준비코드 
        StubManufactureRepository mnfRepository = new ();
        StubWorkOrderRepository workOrderRepository = new();


        //suit
        var testSuit = new ManufactureWorkOrderService(mnfRepository, workOrderRepository);

        //case
        testSuit.AddManufacture(1, "manufactureSummary", "Lee");

        var addedManufacture = mnfRepository
            .StubData
            .FirstOrDefault(x => x.WorkOrderId == 1);

        Assert.NotNull(addedManufacture);
    }
}

public class StubManufactureRepository : IRepository<Manufacture>
{
    public List<Manufacture> StubData { get; set; }

    

    public StubManufactureRepository()
    {
        StubData = new();
    }

    public IEnumerable<Manufacture> GetAll()
    {
        return StubData;
    }

    public Manufacture GetById(int id)
    {
        return StubData.FirstOrDefault(m => m.Id == id);
    }

    public void Add(Manufacture entity)
    {
        StubData.Add(entity);
    }

    public void Update(Manufacture entity)
    {
        var index = StubData.FindIndex(m => m.Id == entity.Id);
        if (index != -1)
        {
            StubData[index] = entity;
        }
    }

    public void Delete(int id)
    {
        var entity = StubData.FirstOrDefault(m => m.Id == id);
        if (entity != null)
        {
            StubData.Remove(entity);
        }
    }
}


public class StubWorkOrderRepository : IRepository<WorkOrder>
{
    private readonly List<WorkOrder> _stubData;

    public StubWorkOrderRepository()
    {
        _stubData = new List<WorkOrder>
        {
            new WorkOrder { Id = 1,ExpireDate = DateTime.Now.AddYears(1)},
            new WorkOrder { Id = 2,ExpireDate = DateTime.Now.AddYears(1)},
        };
    }

    public IEnumerable<WorkOrder> GetAll()
    {
        return _stubData;
    }

    public WorkOrder GetById(int id)
    {
        return _stubData.FirstOrDefault(w => w.Id == id);
    }

    public void Add(WorkOrder entity)
    {
        _stubData.Add(entity);
    }

    public void Update(WorkOrder entity)
    {
        var index = _stubData.FindIndex(w => w.Id == entity.Id);
        if (index != -1)
        {
            _stubData[index] = entity;
        }
    }

    public void Delete(int id)
    {
        var entity = _stubData.FirstOrDefault(w => w.Id == id);
        if (entity != null)
        {
            _stubData.Remove(entity);
        }
    }
}
