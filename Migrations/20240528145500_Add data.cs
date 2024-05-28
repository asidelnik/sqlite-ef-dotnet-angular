using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sqlink.Migrations
{
  /// <inheritdoc />
  public partial class Adddata : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.Sql("INSERT INTO Users (Name, Email) VALUES ('John Doe', 'john.doe@example.com')");
      migrationBuilder.Sql("INSERT INTO Users (Name, Email) VALUES ('Jane Doe', 'jane.doe@example.com')");
      migrationBuilder.Sql("INSERT INTO Users (Name, Email) VALUES ('Alice Smith', 'alice.smith@example.com')");
      migrationBuilder.Sql("INSERT INTO Users (Name, Email) VALUES ('Bob Smith', 'bob.smith@example.com')");
      migrationBuilder.Sql("INSERT INTO Users (Name, Email) VALUES ('Charlie Brown', 'charlie.brown@example.com')");
      migrationBuilder.Sql("INSERT INTO Users (Name, Email) VALUES ('Daisy Brown', 'daisy.brown@example.com')");
      migrationBuilder.Sql("INSERT INTO Users (Name, Email) VALUES ('Eva Johnson', 'eva.johnson@example.com')");
      migrationBuilder.Sql("INSERT INTO Users (Name, Email) VALUES ('Frank Johnson', 'frank.johnson@example.com')");
      migrationBuilder.Sql("INSERT INTO Users (Name, Email) VALUES ('Grace Davis', 'grace.davis@example.com')");
      migrationBuilder.Sql("INSERT INTO Users (Name, Email) VALUES ('Henry Davis', 'henry.davis@example.com')");
      migrationBuilder.Sql("INSERT INTO Users (Name, Email) VALUES ('Ivy Wilson', 'ivy.wilson@example.com')");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {

    }
  }
}
