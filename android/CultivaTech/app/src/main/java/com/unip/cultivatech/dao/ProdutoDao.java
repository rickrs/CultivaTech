package com.unip.cultivatech.dao;
import androidx.room.Dao;
import androidx.room.Insert;
import androidx.room.Query;
import androidx.room.Update;
import androidx.room.Delete;

import com.unip.cultivatech.model.Produto;

import java.util.List;

@Dao
public interface ProdutoDao {

    // Inserir um novo produto
    @Insert
    void inserirProduto(Produto produto);

    // Atualizar um produto existente
    @Update
    void atualizarProduto(Produto produto);

    // Deletar um produto
    @Delete
    void deletarProduto(Produto produto);

    // Buscar todos os produtos
    @Query("SELECT * FROM produto")
    List<Produto> listarProdutos();

    // Buscar um produto pelo ID
    @Query("SELECT * FROM produto WHERE id = :id")
    Produto buscarProdutoPorId(int id);
}
