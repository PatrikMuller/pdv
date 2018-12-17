using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace pdvInfraestrutura.Migrations
{
    public partial class pdv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarrinhoPessoaTipos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoPessoaTipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DataAbertura = table.Column<DateTime>(nullable: false),
                    LoginUsuarioAbertura = table.Column<string>(nullable: true),
                    DataFechamento = table.Column<DateTime>(nullable: true),
                    LoginUsuarioFechamento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParcelamentoStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelamentoStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nome = table.Column<string>(nullable: true),
                    CpfCnpj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadeMedida",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descricao = table.Column<string>(nullable: true),
                    Sigla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeMedida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoFormaPagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CarrinhoId = table.Column<int>(nullable: true),
                    FormaPagamentoId = table.Column<int>(nullable: true),
                    ValorPagar = table.Column<double>(nullable: false),
                    QtdParcelas = table.Column<int>(nullable: false),
                    Juros = table.Column<double>(nullable: false),
                    ValorParcela = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoFormaPagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrinhoFormaPagamentos_Carrinhos_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarrinhoFormaPagamentos_FormaPagamentos_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormaPagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FormaPagamentoParcelamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FormaPagamentoId = table.Column<int>(nullable: true),
                    QtdParcelas = table.Column<int>(nullable: false),
                    Juros = table.Column<double>(nullable: false),
                    ParcelamentoStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamentoParcelamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormaPagamentoParcelamentos_FormaPagamentos_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormaPagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormaPagamentoParcelamentos_ParcelamentoStatuses_Parcelamen~",
                        column: x => x.ParcelamentoStatusId,
                        principalTable: "ParcelamentoStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoPessoas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CarrinhoId = table.Column<int>(nullable: true),
                    PessoaId = table.Column<int>(nullable: true),
                    CarrinhoPessoaTipoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoPessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrinhoPessoas_Carrinhos_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarrinhoPessoas_CarrinhoPessoaTipos_CarrinhoPessoaTipoId",
                        column: x => x.CarrinhoPessoaTipoId,
                        principalTable: "CarrinhoPessoaTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarrinhoPessoas_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nome = table.Column<string>(nullable: true),
                    FabricanteId = table.Column<int>(nullable: true),
                    UnidadeMedidaId = table.Column<int>(nullable: true),
                    Quantidade = table.Column<double>(nullable: false),
                    Preco = table.Column<double>(nullable: false),
                    Desconto = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Fabricantes_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_UnidadeMedida_UnidadeMedidaId",
                        column: x => x.UnidadeMedidaId,
                        principalTable: "UnidadeMedida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Ordem = table.Column<int>(nullable: false),
                    CarrinhoId = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: true),
                    Quantidade = table.Column<double>(nullable: false),
                    Preco = table.Column<double>(nullable: false),
                    Desconto = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrinhoItems_Carrinhos_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarrinhoItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoFormaPagamentos_CarrinhoId",
                table: "CarrinhoFormaPagamentos",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoFormaPagamentos_FormaPagamentoId",
                table: "CarrinhoFormaPagamentos",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItems_CarrinhoId",
                table: "CarrinhoItems",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItems_ItemId",
                table: "CarrinhoItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoPessoas_CarrinhoId",
                table: "CarrinhoPessoas",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoPessoas_CarrinhoPessoaTipoId",
                table: "CarrinhoPessoas",
                column: "CarrinhoPessoaTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoPessoas_PessoaId",
                table: "CarrinhoPessoas",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_FormaPagamentoParcelamentos_FormaPagamentoId",
                table: "FormaPagamentoParcelamentos",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_FormaPagamentoParcelamentos_ParcelamentoStatusId",
                table: "FormaPagamentoParcelamentos",
                column: "ParcelamentoStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_FabricanteId",
                table: "Items",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UnidadeMedidaId",
                table: "Items",
                column: "UnidadeMedidaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoFormaPagamentos");

            migrationBuilder.DropTable(
                name: "CarrinhoItems");

            migrationBuilder.DropTable(
                name: "CarrinhoPessoas");

            migrationBuilder.DropTable(
                name: "FormaPagamentoParcelamentos");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Carrinhos");

            migrationBuilder.DropTable(
                name: "CarrinhoPessoaTipos");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "FormaPagamentos");

            migrationBuilder.DropTable(
                name: "ParcelamentoStatuses");

            migrationBuilder.DropTable(
                name: "Fabricantes");

            migrationBuilder.DropTable(
                name: "UnidadeMedida");
        }
    }
}
