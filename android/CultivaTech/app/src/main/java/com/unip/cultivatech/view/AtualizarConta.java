package com.unip.cultivatech.view;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.room.Room;

import com.unip.cultivatech.R;
import com.unip.cultivatech.control.AppDatabase;
import com.unip.cultivatech.model.Usuario;
import com.unip.cultivatech.service.Auth;

public class AtualizarConta extends AppCompatActivity {

    private EditText etNome, etTelefone, etEmail, etSenha, etRua, etCidade, etEstado;
    private Button btnCadastrar;
    private Auth auth;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_atualizar_conta);

        // Configurar a interface com as barras de sistema
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        // Inicializar os campos do layout
        etNome = findViewById(R.id.et_nome);
        etTelefone = findViewById(R.id.et_telefone);
        etEmail = findViewById(R.id.et_email);
        etSenha = findViewById(R.id.et_senha);
        etRua = findViewById(R.id.et_rua);
        etCidade = findViewById(R.id.et_cidade);
        etEstado = findViewById(R.id.et_estado);
        btnCadastrar = findViewById(R.id.btn_cadastrar);

        // Recuperar o e-mail do usuário logado
        SharedPreferences sharedPreferences = getSharedPreferences("UserPrefs", MODE_PRIVATE);
        String email = sharedPreferences.getString("email", "Email não encontrado");

        // Obter a instância do banco de dados
        AppDatabase db = Room.databaseBuilder(this, AppDatabase.class, "cultivatech.db")
                .allowMainThreadQueries()
                .build();

        // Buscar o usuário pelo e-mail
        Usuario usuario = db.usuarioDao().buscarUsuarioPorEmail(email);

        // Preencher os campos com os dados do usuário
        if (usuario != null) {
            etNome.setText(usuario.getNome());
            etTelefone.setText(usuario.getTelefone());
            etEmail.setText(usuario.getEmail());
            etSenha.setText(usuario.getSenha());
            etRua.setText(usuario.getRua());
            etCidade.setText(usuario.getCidade());
            etEstado.setText(usuario.getEstado());
        }

        // Definir o comportamento do botão "Salvar"
        btnCadastrar.setOnClickListener(v -> {
            auth = new Auth(this);

            String nome = etNome.getText().toString();
            String email_new = etEmail.getText().toString();
            String senha = etSenha.getText().toString();
            String telefone = etTelefone.getText().toString();
            String rua = etRua.getText().toString();
            String cidade = etCidade.getText().toString();
            String estado = etEstado.getText().toString();

            // Salvar as alterações no banco
            auth.atualizarUsuario(usuario.getEmail(), nome, email_new, senha, telefone, rua, cidade, estado);

            // Informar o usuário que os dados foram salvos
            Toast.makeText(this, "Dados atualizados com sucesso!", Toast.LENGTH_SHORT).show();
            Intent intent = new Intent(this, TelaUsuario.class);
            startActivity(intent);
        });
    }
}
