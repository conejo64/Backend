namespace Backend.Application.DTOs.Responses.DashboardResponses;

public class DashboardResponse
{
    public int TotalCases { get; set; }
    public int TotalCasesLast { get; set; }
    public int TotalCasesOpened { get; set; }
    public int TotalCasesOpenedLast { get; set; }
    public int TotalCasesClosed { get; set; }
    public int TotalCasesClosedLast { get; set; }
}