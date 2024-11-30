package com.unip.cultivatech.service;

import android.content.Context;

import com.unip.cultivatech.control.AppDatabase;
import com.unip.cultivatech.model.Produto;

import java.util.List;

public class ProdutoManager {
    private Context context;

    public ProdutoManager(Context context) {
        this.context = context.getApplicationContext(); // Evitando vazamento de memória
    }

    public void mostrarProdutos() {
        // Usar a variável `context` para acessar o banco de dados
        new Thread(() -> {
            AppDatabase db = AppDatabase.getDatabase(context);
            List<Produto> produtos = db.produtoDao().listarProdutos();

            if (produtos != null && !produtos.isEmpty()) {
                // Mostrar os produtos, talvez em uma lista na UI
                for (Produto produto : produtos) {
                    System.out.println("Produto: " + produto.getNome());
                    System.out.println("Descrição: " + produto.getDescricao());
                    System.out.println("Preço: " + produto.getPreco());
                    System.out.println("Quantidade: " + produto.getQuantidade());
                }
            } else {
                // Nenhum produto encontrado
                System.out.println("Nenhum produto encontrado.");
            }
        }).start();
    }

    public void adicionarProduto(String nome, String descricao, double preco, int quantidade) {
        // Criar um novo produto
        Produto produto = new Produto();
        produto.setNome(nome);
        produto.setDescricao(descricao);
        produto.setPreco(preco);
        produto.setQuantidade(quantidade);

        // Inserir o produto no banco de dados
        new Thread(() -> {
            AppDatabase db = AppDatabase.getDatabase(context);
            db.produtoDao().inserirProduto(produto);

            // Após inserir, você pode exibir os produtos ou dar um feedback ao usuário
            System.out.println("Produto " + nome + " inserido com sucesso!");
        }).start();
    }

}
