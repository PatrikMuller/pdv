INSERT INTO "UnidadeMedida"("Descricao", "Sigla")
    VALUES ('UNIDADE', 'UNID');

INSERT INTO "Fabricantes"("Descricao")
    VALUES ('AQUARIUS');

INSERT INTO "Items"("Nome", "FabricanteId", "UnidadeMedidaId", "Quantidade", "Preco", "Desconto")
    VALUES ('ANTENA', 1, 1, 15.000, 350.00, 0.00)

INSERT INTO "CarrinhoItems"("Ordem", "CarrinhoId", "ItemId", "Quantidade", "Preco", "Desconto")
    VALUES (1, 1, 1, 2, 345.45, 0.00)




SELECT * FROM "Items"
SELECT * FROM "CarrinhoItems"