package com.unip.cultivatech.view;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.room.Room;

import com.unip.cultivatech.MainActivity;
import com.unip.cultivatech.R;
import com.unip.cultivatech.control.AppDatabase;
import com.unip.cultivatech.model.Usuario;

public class TelaUsuario extends AppCompatActivity {

    private TextView tvNomeUsuario, tvEmailUsuario, tvSenhaUsuario, tvTelefoneUsuario, tvEndereco;
    private Button btnModificarUsuario, btnDeletarUsuario, btnSair;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_tela_usuario);

        // Inicializar as views
        tvNomeUsuario = findViewById(R.id.tvNomeUsuario);
        tvEmailUsuario = findViewById(R.id.tvEmailUsuario);
        tvSenhaUsuario = findViewById(R.id.tvSenhaUsuario);
        tvTelefoneUsuario = findViewById(R.id.tvTelefoneUsuario);
        tvEndereco = findViewById(R.id.tvEndereco);
        btnModificarUsuario = findViewById(R.id.btnModificarUsuario);
        btnDeletarUsuario = findViewById(R.id.btnDeletarUsuario);
        btnSair = findViewById(R.id.btnSair);

        // Recuperar o e-mail do usuário logado
        SharedPreferences sharedPreferences = getSharedPreferences("UserPrefs", MODE_PRIVATE);
        String email = sharedPreferences.getString("email", "Email não encontrado");

        // Obter a instância do banco de dados
        AppDatabase db = Room.databaseBuilder(this, AppDatabase.class, "cultivatech.db")
                .allowMainThreadQueries()
                .build();

        // Buscar o usuário pelo e-mail
        Usuario usuario = db.usuarioDao().buscarUsuarioPorEmail(email);

        if (usuario != null) {
            // Preencher os campos com as informações do usuário
            tvNomeUsuario.setText(usuario.getNome());
            tvEmailUsuario.setText(usuario.getEmail());
            tvSenhaUsuario.setText("Senha: ********"); // Não é seguro exibir a senha, apenas um placeholder
            tvTelefoneUsuario.setText("Telefone: " + usuario.getTelefone());
            tvEndereco.setText("Endereço: " + usuario.getEndereco()); // Assumindo que o endereço é uma String simples

            // Exemplo de ação ao clicar no botão de modificar
            btnModificarUsuario.setOnClickListener(v -> {
                Intent intent = new Intent(this, AtualizarConta.class);
                startActivity(intent);
            });

            // Exemplo de ação ao clicar no botão de deletar
            btnDeletarUsuario.setOnClickListener(v -> {
                Intent intent = new Intent(this, DeletarUsuario.class);
                startActivity(intent);
            });

            // Ação ao clicar no botão de sair
            btnSair.setOnClickListener(v -> {
                // Ação para fazer logout ou sair
                SharedPreferences.Editor editor = sharedPreferences.edit();
                editor.clear();  // Limpar os dados compartilhados
                editor.apply();

                Toast.makeText(TelaUsuario.this, "Você saiu da conta.", Toast.LENGTH_SHORT).show();

                Intent intent = new Intent(this, MainActivity.class);
                startActivity(intent);
                finish(); // Finaliza a atividade atual
            });
        } else {
            Toast.makeText(this, "Usuário não encontrado", Toast.LENGTH_SHORT).show();
        }
    }
}
