namespace FinanceTracker.Service.Configuration;

public class Pagination
{
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
    public int PageNumber { get; set; } = 1;
}
