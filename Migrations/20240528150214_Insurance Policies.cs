using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sqlink.Migrations
{
  /// <inheritdoc />
  public partial class InsurancePolicies : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.Sql("INSERT INTO InsurancePolicies (PolicyNumber, InsuranceAmount, StartDate, EndDate, UserId) VALUES('123456', 1000, '2024-05-01', '2025-05-01', 1)");
      migrationBuilder.Sql("INSERT INTO InsurancePolicies (PolicyNumber, InsuranceAmount, StartDate, EndDate, UserId) VALUES ('654321', 2000, '2024-05-01', '2025-05-01', 2)");
      migrationBuilder.Sql("INSERT INTO InsurancePolicies (PolicyNumber, InsuranceAmount, StartDate, EndDate, UserId) VALUES ('111222', 3000, '2024-05-01', '2025-05-01', 3)");
      migrationBuilder.Sql("INSERT INTO InsurancePolicies (PolicyNumber, InsuranceAmount, StartDate, EndDate, UserId) VALUES ('222111', 4000, '2024-05-01', '2025-05-01', 4)");
      migrationBuilder.Sql("INSERT INTO InsurancePolicies (PolicyNumber, InsuranceAmount, StartDate, EndDate, UserId) VALUES ('333444', 5000, '2024-05-01', '2025-05-01', 5)");
      migrationBuilder.Sql("INSERT INTO InsurancePolicies (PolicyNumber, InsuranceAmount, StartDate, EndDate, UserId) VALUES ('444333', 6000, '2024-05-01', '2025-05-01', 6)");
      migrationBuilder.Sql("INSERT INTO InsurancePolicies (PolicyNumber, InsuranceAmount, StartDate, EndDate, UserId) VALUES ('555666', 7000, '2024-05-01', '2025-05-01', 7)");
      migrationBuilder.Sql("INSERT INTO InsurancePolicies (PolicyNumber, InsuranceAmount, StartDate, EndDate, UserId) VALUES ('666555', 8000, '2024-05-01', '2025-05-01', 8)");
      migrationBuilder.Sql("INSERT INTO InsurancePolicies (PolicyNumber, InsuranceAmount, StartDate, EndDate, UserId) VALUES ('777888', 9000, '2024-05-01', '2025-05-01', 9)");
      migrationBuilder.Sql("INSERT INTO InsurancePolicies (PolicyNumber, InsuranceAmount, StartDate, EndDate, UserId) VALUES ('888777', 10000, '2024-05-01', '2025-05-01', 10)");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {

    }
  }
}
