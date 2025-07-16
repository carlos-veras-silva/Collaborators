using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Collaborators.Infra.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeCompleto = table.Column<string>(type: "character varying(200)", nullable: false),
                    CPF = table.Column<string>(type: "character varying(11)", nullable: false),
                    RG = table.Column<string>(type: "character varying(10)", nullable: true),
                    Email = table.Column<string>(type: "character varying(150)", nullable: true),
                    Telefone = table.Column<string>(type: "character varying(15)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "date", nullable: false),
                    DataDemissao = table.Column<DateTime>(type: "date", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Cargo = table.Column<string>(type: "text", nullable: false),
                    Departamento = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colaboradores");
        }
    }
}
