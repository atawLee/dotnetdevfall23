using mesWeb.Database.Entity;
using mesWeb.Entity;
using Microsoft.EntityFrameworkCore;

namespace mesWeb.Repository;

public class ManufactureRepository : IRepository<Manufacture>
{
    private readonly AppDbContext _context;

    public ManufactureRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Manufacture> GetAll()
    {
        return _context.Set<Manufacture>().ToList();
    }

    public Manufacture GetById(int id)
    {
        return _context.Set<Manufacture>().Find(id);
    }

    public void Add(Manufacture entity)
    {
        _context.Set<Manufacture>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(Manufacture entity)
    {
        _context.Set<Manufacture>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var entity = _context.Set<Manufacture>().Find(id);
        if (entity != null)
        {
            _context.Set<Manufacture>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
