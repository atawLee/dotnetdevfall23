namespace mesWeb.Database.Entity;

public class WorkOrder
{
    public int Id { get; set; }
    public string Description { get; set; }

    public string Product { get; set; }
    public decimal TargetQty { get; set; }
    public string OrderUser { get; set; }
    public DateTime DueDate { get; set; }

    public DateTime ExpireDate { get; set; }

    public DateTime CreateDateTime { get; set; }

    // Navigation property
    public List<Manufacture> Manufactures { get; set; }
}
