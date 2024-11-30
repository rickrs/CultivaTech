package com.unip.cultivatech.dao;
import androidx.room.Dao;
import androidx.room.Insert;
import androidx.room.Query;
import androidx.room.Update;
import androidx.room.Delete;

import com.unip.cultivatech.model.Usuario;

import java.util.List;

@Dao
public interface UsuarioDao {

    // Inserir um novo usuário
    @Insert
    void inserirUsuario(Usuario usuario);

    // Atualizar um usuário
    @Update
    void atualizarUsuario(Usuario usuario);

    // Deletar um usuário
    @Delete
    void deletarUsuario(Usuario usuario);

    // Buscar um usuário pelo email (para login)
    @Query("SELECT * FROM usuario WHERE email = :email")
    Usuario buscarUsuarioPorEmail(String email);

    // Listar todos os usuários (opcional)
    @Query("SELECT * FROM usuario")
    List<Usuario> listarUsuarios();
}
