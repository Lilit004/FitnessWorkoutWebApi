using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessWorkout.Infrastructure.MsSql.Migrations
{
    /// <inheritdoc />
    public partial class AddAnExercise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "ComplexityLevel", "Name", "WorkoutId" },
                values: new object[] { 21, "Easy", "Leg Press2", 5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 21);
        }
    }
}
