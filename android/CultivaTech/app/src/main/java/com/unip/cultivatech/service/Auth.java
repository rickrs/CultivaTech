package com.unip.cultivatech.service;

import android.content.Context;

import androidx.room.Room;

import com.unip.cultivatech.control.AppDatabase;
import com.unip.cultivatech.model.Usuario;

public class Auth {
    private Context context;
    private AppDatabase db;

    // Construtor para passar o contexto
    public Auth(Context context) {
        db = Room.databaseBuilder(context.getApplicationContext(),
                        AppDatabase.class, "cultivatech.db")
                .allowMainThreadQueries() // Apenas para testes, não usar em produção
                .build();
    }

    public void registrarUsuario(String nome, String email, String senha, String telefone, String rua, String cidade, String estado) {
        // Criar um novo usuário
        Usuario usuario = new Usuario();
        usuario.setNome(nome);
        usuario.setEmail(email);
        usuario.setSenha(senha); // Lembre-se de que você pode hash a senha antes de salvar!
        usuario.setTelefone(telefone);
        usuario.setRua(rua);
        usuario.setCidade(cidade);
        usuario.setEstado(estado);

        // Inserir o usuário no banco de dados
        new Thread(() -> {
            db.usuarioDao().inserirUsuario(usuario);
        }).start();
    }

    public boolean loginUsuario(String email, String senha) {
        boolean loginSuccess = false;
        // Usar a variável `context` para acessar o banco de dados em uma thread separada
        Usuario usuario = db.usuarioDao().buscarUsuarioPorEmail(email);
        if (usuario != null && usuario.getSenha().equals(senha)) {
            // Login bem-sucedido
            loginSuccess = true;
        } else {
            // Login falhou
            loginSuccess = false;
        }

        return loginSuccess;
    }

    // Método para atualizar um usuário
    public void atualizarUsuario(String id, String nome, String email, String senha, String telefone, String rua, String cidade, String estado) {
        // Buscar o usuário no banco de dados
        Usuario usuario = db.usuarioDao().buscarUsuarioPorEmail(id);

        if (usuario != null) {
            // Atualiza os campos necessários
            usuario.setNome(nome);
            usuario.setEmail(email);
            usuario.setSenha(senha); // Lembre-se de que você pode hash a senha antes de salvar!
            usuario.setTelefone(telefone);
            usuario.setRua(rua);
            usuario.setCidade(cidade);
            usuario.setEstado(estado);

            // Atualizar o usuário no banco de dados
            new Thread(() -> {
                db.usuarioDao().atualizarUsuario(usuario);
            }).start();
        }
    }

    // Método para deletar um usuário
    public void deletarUsuario(String email) {
        // Buscar o usuário no banco de dados
        Usuario usuario = db.usuarioDao().buscarUsuarioPorEmail(email);

        if (usuario != null) {
            // Deletar o usuário do banco de dados
            new Thread(() -> {
                db.usuarioDao().deletarUsuario(usuario);
            }).start();
        }
    }
}
