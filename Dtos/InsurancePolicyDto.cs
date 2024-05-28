namespace sqlink.Dtos;

public class InsurancePolicyDto
{
  public int Id { get; set; }
  public required string PolicyNumber { get; set; }
  public double InsuranceAmount { get; set; }
  public DateTime StartDate { get; set; }
  public DateTime EndDate { get; set; }
  public int UserId { get; set; }
}