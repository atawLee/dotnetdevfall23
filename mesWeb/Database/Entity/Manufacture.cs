namespace mesWeb.Database.Entity;

public class Manufacture
{
    public int Id { get; set; }
    public string Summary { get; set; }
    
    public string Worker { get; set; }

    public DateTime WorkStartTime { get; set; } = DateTime.Now;

    public DateTime? WorkEndTime { get; set; }

    public decimal WorkQty { get; set; }
    public decimal FaultQty { get; set; }

    // Foreign key
    public int WorkOrderId { get; set; }
    public WorkOrder WorkOrder { get; set; }
}
