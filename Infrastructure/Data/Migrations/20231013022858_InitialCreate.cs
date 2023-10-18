using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Auditoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreUsuario = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescAccion = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditoria", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EstadoNotificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreEstado = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoNotificacion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Formato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreFormato = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formato", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HiloRespuestaNotificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiloRespuestaNotificacion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModulosMaestro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreModulo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulosMaestro", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PermisoGenerico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombrePermiso = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisoGenerico", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Radicado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radicado", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Submodulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreSubmodulo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submodulo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoNotificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreTipo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoNotificacion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoRequerimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoRequerimiento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RolVsMaestro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    IdMaestro = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolVsMaestro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolVsMaestro_ModulosMaestro_IdMaestro",
                        column: x => x.IdMaestro,
                        principalTable: "ModulosMaestro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolVsMaestro_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MaestrosVsSubmodulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdMaestro = table.Column<int>(type: "int", nullable: false),
                    IdSubmodulo = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaestrosVsSubmodulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaestrosVsSubmodulo_ModulosMaestro_IdMaestro",
                        column: x => x.IdMaestro,
                        principalTable: "ModulosMaestro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaestrosVsSubmodulo_Submodulo_IdSubmodulo",
                        column: x => x.IdSubmodulo,
                        principalTable: "Submodulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Blockchain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdNotificacion = table.Column<int>(type: "int", nullable: false),
                    IdHiloRespuesta = table.Column<int>(type: "int", nullable: false),
                    IdAuditoria = table.Column<int>(type: "int", nullable: false),
                    HashGenerado = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blockchain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blockchain_Auditoria_IdAuditoria",
                        column: x => x.IdAuditoria,
                        principalTable: "Auditoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blockchain_HiloRespuestaNotificacion_IdHiloRespuesta",
                        column: x => x.IdHiloRespuesta,
                        principalTable: "HiloRespuestaNotificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blockchain_TipoNotificacion_IdNotificacion",
                        column: x => x.IdNotificacion,
                        principalTable: "TipoNotificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModuloNotificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AsuntoNotificacion = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdNotificacion = table.Column<int>(type: "int", nullable: false),
                    IdRadicado = table.Column<int>(type: "int", nullable: false),
                    IdEstadoNotificacion = table.Column<int>(type: "int", nullable: false),
                    IdHiloRespuesta = table.Column<int>(type: "int", nullable: false),
                    IdFormato = table.Column<int>(type: "int", nullable: false),
                    IdRequerimiento = table.Column<int>(type: "int", nullable: false),
                    TextoNotificacion = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuloNotificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModuloNotificacion_EstadoNotificacion_IdEstadoNotificacion",
                        column: x => x.IdEstadoNotificacion,
                        principalTable: "EstadoNotificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuloNotificacion_Formato_IdFormato",
                        column: x => x.IdFormato,
                        principalTable: "Formato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuloNotificacion_HiloRespuestaNotificacion_IdHiloRespuesta",
                        column: x => x.IdHiloRespuesta,
                        principalTable: "HiloRespuestaNotificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuloNotificacion_Radicado_IdRadicado",
                        column: x => x.IdRadicado,
                        principalTable: "Radicado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuloNotificacion_TipoNotificacion_IdNotificacion",
                        column: x => x.IdNotificacion,
                        principalTable: "TipoNotificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModuloNotificacion_TipoRequerimiento_IdRequerimiento",
                        column: x => x.IdRequerimiento,
                        principalTable: "TipoRequerimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GenericosVsSubmodulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdGenerico = table.Column<int>(type: "int", nullable: false),
                    IdSubmodulo = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericosVsSubmodulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenericosVsSubmodulo_MaestrosVsSubmodulo_IdSubmodulo",
                        column: x => x.IdSubmodulo,
                        principalTable: "MaestrosVsSubmodulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenericosVsSubmodulo_PermisoGenerico_IdGenerico",
                        column: x => x.IdGenerico,
                        principalTable: "PermisoGenerico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenericosVsSubmodulo_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Blockchain_IdAuditoria",
                table: "Blockchain",
                column: "IdAuditoria");

            migrationBuilder.CreateIndex(
                name: "IX_Blockchain_IdHiloRespuesta",
                table: "Blockchain",
                column: "IdHiloRespuesta");

            migrationBuilder.CreateIndex(
                name: "IX_Blockchain_IdNotificacion",
                table: "Blockchain",
                column: "IdNotificacion");

            migrationBuilder.CreateIndex(
                name: "IX_GenericosVsSubmodulo_IdGenerico",
                table: "GenericosVsSubmodulo",
                column: "IdGenerico");

            migrationBuilder.CreateIndex(
                name: "IX_GenericosVsSubmodulo_IdRol",
                table: "GenericosVsSubmodulo",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_GenericosVsSubmodulo_IdSubmodulo",
                table: "GenericosVsSubmodulo",
                column: "IdSubmodulo");

            migrationBuilder.CreateIndex(
                name: "IX_MaestrosVsSubmodulo_IdMaestro",
                table: "MaestrosVsSubmodulo",
                column: "IdMaestro");

            migrationBuilder.CreateIndex(
                name: "IX_MaestrosVsSubmodulo_IdSubmodulo",
                table: "MaestrosVsSubmodulo",
                column: "IdSubmodulo");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNotificacion_IdEstadoNotificacion",
                table: "ModuloNotificacion",
                column: "IdEstadoNotificacion");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNotificacion_IdFormato",
                table: "ModuloNotificacion",
                column: "IdFormato");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNotificacion_IdHiloRespuesta",
                table: "ModuloNotificacion",
                column: "IdHiloRespuesta");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNotificacion_IdNotificacion",
                table: "ModuloNotificacion",
                column: "IdNotificacion");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNotificacion_IdRadicado",
                table: "ModuloNotificacion",
                column: "IdRadicado");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloNotificacion_IdRequerimiento",
                table: "ModuloNotificacion",
                column: "IdRequerimiento");

            migrationBuilder.CreateIndex(
                name: "IX_RolVsMaestro_IdMaestro",
                table: "RolVsMaestro",
                column: "IdMaestro");

            migrationBuilder.CreateIndex(
                name: "IX_RolVsMaestro_IdRol",
                table: "RolVsMaestro",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blockchain");

            migrationBuilder.DropTable(
                name: "GenericosVsSubmodulo");

            migrationBuilder.DropTable(
                name: "ModuloNotificacion");

            migrationBuilder.DropTable(
                name: "RolVsMaestro");

            migrationBuilder.DropTable(
                name: "Auditoria");

            migrationBuilder.DropTable(
                name: "MaestrosVsSubmodulo");

            migrationBuilder.DropTable(
                name: "PermisoGenerico");

            migrationBuilder.DropTable(
                name: "EstadoNotificacion");

            migrationBuilder.DropTable(
                name: "Formato");

            migrationBuilder.DropTable(
                name: "HiloRespuestaNotificacion");

            migrationBuilder.DropTable(
                name: "Radicado");

            migrationBuilder.DropTable(
                name: "TipoNotificacion");

            migrationBuilder.DropTable(
                name: "TipoRequerimiento");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "ModulosMaestro");

            migrationBuilder.DropTable(
                name: "Submodulo");
        }
    }
}
