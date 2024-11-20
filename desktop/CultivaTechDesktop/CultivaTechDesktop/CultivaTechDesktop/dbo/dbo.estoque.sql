CREATE TABLE [dbo].[estoque] (
    [id_produto]   INT             IDENTITY (1, 1) NOT NULL,
    [nome_produto] NVARCHAR (100)  NOT NULL,
    [qtd_produto]  INT             DEFAULT ((0)) NULL,
    [image]        VARBINARY (MAX) NULL,
	insert_date DATE DEFAULT GETDATE(),       -- Data de inserção
    update_date DATE NULL,                    -- Data de atualização
    delete_date DATE NULL                     -- Data de exclusão (soft delete)
    PRIMARY KEY CLUSTERED ([id_produto] ASC),
    CHECK ([qtd_produto]>=(0))
);


GO
CREATE NONCLUSTERED INDEX [idx_estoque_nome]
    ON [dbo].[estoque]([nome_produto] ASC);

