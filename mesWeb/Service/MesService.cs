
using mesWeb.Database.Entity;
using mesWeb.Repository;

namespace mesWeb.Service;

public class ManufactureWorkOrderService 
{
    private readonly IRepository<Manufacture> _manufactureRepository;
    private readonly IRepository<WorkOrder> _workOrderRepository;

    public ManufactureWorkOrderService(
        IRepository<Manufacture> manufactureRepository,
        IRepository<WorkOrder> workOrderRepository)
    {
        _manufactureRepository = manufactureRepository;
        _workOrderRepository = workOrderRepository;
    }

    // Manufacture Methods
    public IEnumerable<Manufacture> GetAllManufactures() => _manufactureRepository.GetAll();
    public Manufacture GetManufactureById(int id) => _manufactureRepository.GetById(id);

    public void AddManufacture(int workOrderId, string summary, string worker)
    {
        var item = _workOrderRepository.GetById(workOrderId);
        if (item is null) throw new Exception("Not Found");
        if (item.ExpireDate < DateTime.Now) throw new Exception("Expired Order");

        Manufacture manufacture = new()
        {
            Summary = summary,
            Worker = worker,
            WorkStartTime = default,
        };
        _manufactureRepository.Add(manufacture);
    }
    public void UpdateManufacture(Manufacture manufacture) => _manufactureRepository.Update(manufacture);
    public void DeleteManufacture(int id) => _manufactureRepository.Delete(id);

    // WorkOrder Methods
    public IEnumerable<WorkOrder> GetAllWorkOrders() => _workOrderRepository.GetAll();
    public WorkOrder GetWorkOrderById(int id) => _workOrderRepository.GetById(id);
    public void AddWorkOrder(WorkOrder workOrder) => _workOrderRepository.Add(workOrder);
    public void UpdateWorkOrder(WorkOrder workOrder) => _workOrderRepository.Update(workOrder);
    public void DeleteWorkOrder(int id) => _workOrderRepository.Delete(id);
}

