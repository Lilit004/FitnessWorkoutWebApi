using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessWorkout.Infrastructure.MsSql.Migrations
{
    /// <inheritdoc />
    public partial class SeedExercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "ComplexityLevel", "Name", "WorkoutId" },
                values: new object[,]
                {
                    { 1, "Hard", "Deadlifts", 1 },
                    { 2, "Hard", "Barbell Squats", 1 },
                    { 3, "Medium", "Bench Press", 1 },
                    { 4, "Hard", "Pull-Ups", 1 },
                    { 5, "Medium", "Jump Squats", 2 },
                    { 6, "Hard", "Burpees", 2 },
                    { 7, "Hard", "Plank Rows", 2 },
                    { 8, "Easy", "Bicep Curls", 3 },
                    { 9, "Medium", "Tricep Dips", 3 },
                    { 10, "Medium", "Bulgarian Split Squats", 3 },
                    { 11, "Medium", "Bent-Over Rows", 3 },
                    { 12, "Hard", "Barbell Deadlifts", 3 },
                    { 13, "Medium", "Plank Variations", 4 },
                    { 14, "Easy", "Bicycle Crunches", 4 },
                    { 15, "Medium", "Leg Raises", 4 },
                    { 16, "Hard", "Cable Woodchoppers", 4 },
                    { 17, "Hard", "Squat to Press", 5 },
                    { 18, "Easy", "Chest Flys", 5 },
                    { 19, "Medium", "Dumbbell Rows", 5 },
                    { 20, "Medium", "Leg Press", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
