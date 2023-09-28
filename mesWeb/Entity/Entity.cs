namespace mesWeb.Entity;

public class WorkOrder
{
    public int Id { get; set; }
    public string Description { get; set; }

    // Navigation property
    public List<Manufacture> Manufactures { get; set; }
}

public class Manufacture
{
    public int Id { get; set; }
    public string ProductName { get; set; }

    // Foreign key
    public int WorkOrderId { get; set; }
    public WorkOrder WorkOrder { get; set; }
}

