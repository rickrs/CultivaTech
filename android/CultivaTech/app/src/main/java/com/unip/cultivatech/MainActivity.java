package com.unip.cultivatech;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.room.Room;

import com.unip.cultivatech.control.AppDatabase;
import com.unip.cultivatech.model.Usuario;
import com.unip.cultivatech.service.Auth;
import com.unip.cultivatech.view.CriarConta;
import com.unip.cultivatech.view.MenuProdutos;

import java.util.List;

public class MainActivity extends AppCompatActivity {

    private EditText editTextEmail, editTextPassword;
    private Button btnLogin, btnCadastro;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        AppDatabase db = Room.databaseBuilder(this, AppDatabase.class, "cultivatech.db")
                .allowMainThreadQueries()
                .build();

        // Inicializar as views
        editTextEmail = findViewById(R.id.editTextEmail);
        editTextPassword = findViewById(R.id.editTextPassword);
        btnLogin = findViewById(R.id.btnLogin);
        btnCadastro = findViewById(R.id.btnCadastro);

        List<Usuario> usuarios = db.usuarioDao().listarUsuarios();
        for(Usuario usuario : usuarios){
            Log.d("MainActivity", "onCreate: " + usuario.getNome());
        }

        // Configurar o clique do botão de login
        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // Obter os dados dos campos de login
                String email = editTextEmail.getText().toString().trim();
                String senha = editTextPassword.getText().toString().trim();

                // Validar se os campos não estão vazios
                if (email.isEmpty() || senha.isEmpty()) {
                    Toast.makeText(MainActivity.this, "Por favor, preencha todos os campos.", Toast.LENGTH_SHORT).show();
                    return;
                }

                // Criar uma instância de Auth e tentar fazer o login
                Auth auth = new Auth(MainActivity.this);
                boolean loginSucesso = auth.loginUsuario(email, senha);

                // Exibir o resultado usando Toast
                if (loginSucesso) {
                    // Exemplo: Suponha que você tenha o ID do usuário no objeto Usuario após login
                    Usuario usuarioLogado = db.usuarioDao().buscarUsuarioPorEmail(email);

                    if (usuarioLogado != null) {
                        // Salvar o ID do usuário no SharedPreferences
                        SharedPreferences sharedPreferences = getSharedPreferences("UserPrefs", MODE_PRIVATE);
                        SharedPreferences.Editor editor = sharedPreferences.edit();
                        editor.putInt("userId", usuarioLogado.getId());  // Salva o ID do usuário
                        editor.putString("email", usuarioLogado.getEmail()); // Se desejar salvar o nome também
                        editor.apply();
                    }

                    Toast.makeText(MainActivity.this, "Login realizado com sucesso!", Toast.LENGTH_SHORT).show();

                    Intent intent = new Intent(MainActivity.this, MenuProdutos.class);
                    startActivity(intent);
                    finish();
                } else {
                    Toast.makeText(MainActivity.this, "Login falhou. Verifique suas credenciais.", Toast.LENGTH_SHORT).show();
                }
            }
        });

        btnCadastro.setOnClickListener(v -> {
            Intent intent = new Intent(this, CriarConta.class);
            startActivity(intent);
        });
    }
}
