using mesWeb.Database.Entity;
using mesWeb.Entity;
using mesWeb.Repository;

namespace mesWeb.Service
{
    public class UnTestableMesService
    {
        private ManufactureRepository _manufactureRepository;
        private WorkOrderRepository _workOrderRepository;

        public UnTestableMesService()
        {
            AppDbContext dbContext = new AppDbContext();
            this._workOrderRepository = new WorkOrderRepository(dbContext);
            this._manufactureRepository = new ManufactureRepository(dbContext);
        }

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
    }
}
