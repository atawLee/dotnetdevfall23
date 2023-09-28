using mesWeb.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace mesWeb.Repository;

public class WorkOrderRepository : IRepository<WorkOrder>
{
    private readonly DbContext _context;

    public WorkOrderRepository(DbContext context)
    {
        _context = context;
    }

    public IEnumerable<WorkOrder> GetAll()
    {
        return _context.Set<WorkOrder>().Include(w => w.Manufactures).ToList();
    }

    public WorkOrder GetById(int id)
    {
        return _context.Set<WorkOrder>().FirstOrDefault(w => w.Id == id);
    }

    public void Add(WorkOrder entity)
    {
        _context.Set<WorkOrder>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(WorkOrder entity)
    {
        _context.Set<WorkOrder>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = _context.Set<WorkOrder>().Find(id);
        if (entity != null)
        {
            _context.Set<WorkOrder>().Remove(entity);
            _context.SaveChanges();
        }
    }
}