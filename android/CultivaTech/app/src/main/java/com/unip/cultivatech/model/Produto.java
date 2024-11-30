package com.unip.cultivatech.model;

import androidx.annotation.NonNull;
import androidx.room.Entity;
import androidx.room.PrimaryKey;

import java.io.Serializable;

@Entity(tableName = "produto") // Define a tabela "produto"
public class Produto implements Serializable {

    @PrimaryKey(autoGenerate = true)
    private int id;

    @NonNull
    private String nome;

    private double preco;  // Preço do produto (utilizando tipo double)

    private String imagem;  // Caminho ou URL da imagem do produto (pode ser um string com o link da imagem)

    private int quantidade; // Quantidade disponível no estoque

    private String descricao; // Descrição do produto

    public Produto(){}

    public Produto(@NonNull String nome, double preco, String imagem, int quantidade, String descricao) {
        this.nome = nome;
        this.preco = preco;
        this.imagem = imagem;
        this.quantidade = quantidade;
        this.descricao = descricao;
    }

    // Getters e Setters
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getNome() {
        return nome;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public double getPreco() {
        return preco;
    }

    public void setPreco(double preco) {
        this.preco = preco;
    }

    public String getImagem() {
        return imagem;
    }

    public void setImagem(String imagem) {
        this.imagem = imagem;
    }

    public int getQuantidade() {
        return quantidade;
    }

    public void setQuantidade(int quantidade) {
        this.quantidade = quantidade;
    }

    public String getDescricao() {
        return descricao;
    }

    public void setDescricao(String descricao) {
        this.descricao = descricao;
    }
}
