using Microsoft.EntityFrameworkCore.Migrations;

namespace cw11.Migrations
{
    public partial class AddedMedicamentAndPrescriptionMedicamentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescription_Medicament_MedicamentIdMedicament",
                table: "Prescription");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescrpition_Medicament_Medicament_MedicamentIdMedicament",
                table: "Prescrpition_Medicament");

            migrationBuilder.DropForeignKey(
                name: "FK_Prescrpition_Medicament_Prescription_PrescriptionIdPrescription",
                table: "Prescrpition_Medicament");

            migrationBuilder.DropIndex(
                name: "IX_Prescrpition_Medicament_MedicamentIdMedicament",
                table: "Prescrpition_Medicament");

            migrationBuilder.DropIndex(
                name: "IX_Prescrpition_Medicament_PrescriptionIdPrescription",
                table: "Prescrpition_Medicament");

            migrationBuilder.DropIndex(
                name: "IX_Prescription_MedicamentIdMedicament",
                table: "Prescription");

            migrationBuilder.DropColumn(
                name: "MedicamentIdMedicament",
                table: "Prescrpition_Medicament");

            migrationBuilder.DropColumn(
                name: "PrescriptionIdPrescription",
                table: "Prescrpition_Medicament");

            migrationBuilder.DropColumn(
                name: "MedicamentIdMedicament",
                table: "Prescription");

            migrationBuilder.AlterColumn<int>(
                name: "IdPrescription",
                table: "Prescrpition_Medicament",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Prescrpition_Medicament_IdMedicament",
                table: "Prescrpition_Medicament",
                column: "IdMedicament");

            migrationBuilder.AddForeignKey(
                name: "Prescription_Medicament_Medicament",
                table: "Prescrpition_Medicament",
                column: "IdMedicament",
                principalTable: "Medicament",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Prescription_Medicament_Prescription",
                table: "Prescrpition_Medicament",
                column: "IdPrescription",
                principalTable: "Prescription",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Prescription_Medicament_Medicament",
                table: "Prescrpition_Medicament");

            migrationBuilder.DropForeignKey(
                name: "Prescription_Medicament_Prescription",
                table: "Prescrpition_Medicament");

            migrationBuilder.DropIndex(
                name: "IX_Prescrpition_Medicament_IdMedicament",
                table: "Prescrpition_Medicament");

            migrationBuilder.AlterColumn<int>(
                name: "IdPrescription",
                table: "Prescrpition_Medicament",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MedicamentIdMedicament",
                table: "Prescrpition_Medicament",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionIdPrescription",
                table: "Prescrpition_Medicament",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicamentIdMedicament",
                table: "Prescription",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescrpition_Medicament_MedicamentIdMedicament",
                table: "Prescrpition_Medicament",
                column: "MedicamentIdMedicament");

            migrationBuilder.CreateIndex(
                name: "IX_Prescrpition_Medicament_PrescriptionIdPrescription",
                table: "Prescrpition_Medicament",
                column: "PrescriptionIdPrescription");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_MedicamentIdMedicament",
                table: "Prescription",
                column: "MedicamentIdMedicament");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescription_Medicament_MedicamentIdMedicament",
                table: "Prescription",
                column: "MedicamentIdMedicament",
                principalTable: "Medicament",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescrpition_Medicament_Medicament_MedicamentIdMedicament",
                table: "Prescrpition_Medicament",
                column: "MedicamentIdMedicament",
                principalTable: "Medicament",
                principalColumn: "IdMedicament",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Prescrpition_Medicament_Prescription_PrescriptionIdPrescription",
                table: "Prescrpition_Medicament",
                column: "PrescriptionIdPrescription",
                principalTable: "Prescription",
                principalColumn: "IdPrescription",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
