package com.unip.cultivatech.view;

import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.unip.cultivatech.MainActivity;
import com.unip.cultivatech.R;
import com.unip.cultivatech.service.Auth;

public class CriarConta extends AppCompatActivity {

    private EditText etNome, etEmail, etSenha, etTelefone, etRua, etCidade, etEstado;
    private Button btnCadastrar;
    private Auth authService;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_criar_conta);

        // Inicializando os campos
        etNome = findViewById(R.id.et_nome);
        etEmail = findViewById(R.id.et_email);
        etSenha = findViewById(R.id.et_senha);
        etTelefone = findViewById(R.id.et_telefone);
        etRua = findViewById(R.id.et_rua);
        etCidade = findViewById(R.id.et_cidade);
        etEstado = findViewById(R.id.et_estado);
        btnCadastrar = findViewById(R.id.btn_cadastrar);

        // Inicializando o serviço de autenticação (Auth)
        authService = new Auth(this);

        // Ação do botão de cadastro
        btnCadastrar.setOnClickListener(v -> {
            // Pegando os dados dos inputs
            String nome = etNome.getText().toString().trim();
            String email = etEmail.getText().toString().trim();
            String senha = etSenha.getText().toString().trim();
            String telefone = etTelefone.getText().toString().trim();
            String rua = etRua.getText().toString().trim();
            String cidade = etCidade.getText().toString().trim();
            String estado = etEstado.getText().toString().trim();

            // Validação simples dos campos (verificando se algum campo está vazio)
            if (TextUtils.isEmpty(nome) || TextUtils.isEmpty(email) || TextUtils.isEmpty(senha) ||
                    TextUtils.isEmpty(telefone) || TextUtils.isEmpty(rua) || TextUtils.isEmpty(cidade) || TextUtils.isEmpty(estado)) {
                Toast.makeText(CriarConta.this, "Por favor, preencha todos os campos", Toast.LENGTH_SHORT).show();
            } else {
                // Chamar o método para registrar o usuário
                authService.registrarUsuario(nome, email, senha, telefone, rua, cidade, estado);

                // Exibir uma mensagem de sucesso (para o usuário)
                Toast.makeText(CriarConta.this, "Conta criada com sucesso!", Toast.LENGTH_SHORT).show();

                Intent intent = new Intent(CriarConta.this, MainActivity.class);
                startActivity(intent);
                finish();  // Para fechar a tela de cadastro após o redirecionamento
            }
        });
    }
}
