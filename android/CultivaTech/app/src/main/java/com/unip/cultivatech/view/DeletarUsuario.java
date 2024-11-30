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

import com.unip.cultivatech.MainActivity;
import com.unip.cultivatech.R;
import com.unip.cultivatech.control.AppDatabase;
import com.unip.cultivatech.model.Usuario;
import com.unip.cultivatech.service.Auth;

public class DeletarUsuario extends AppCompatActivity {

    private EditText senha;
    private Button confirmar, cancelar;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_deletar_usuario);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        // Recuperar o e-mail do usuário logado
        SharedPreferences sharedPreferences = getSharedPreferences("UserPrefs", MODE_PRIVATE);
        String email = sharedPreferences.getString("email", "Email não encontrado");

        AppDatabase db = Room.databaseBuilder(this, AppDatabase.class, "cultivatech.db")
                .allowMainThreadQueries()
                .build();

        Auth auth = new Auth(this);

        // Buscar o usuário pelo e-mail
        Usuario usuario = db.usuarioDao().buscarUsuarioPorEmail(email);
        senha = findViewById(R.id.enviarSenha);
        confirmar = findViewById(R.id.btnConfirmarDelecao);
        cancelar = findViewById(R.id.btnCancelarDelecao);

        confirmar.setOnClickListener(v -> {
            String passwd = senha.getText().toString();

            if(passwd.equals(usuario.getSenha())){
                auth.deletarUsuario(usuario.getEmail());
                Toast.makeText(this, "Usuario deletado", Toast.LENGTH_SHORT).show();
                Intent intent = new Intent(this, MainActivity.class);
                startActivity(intent);
                finish();
            }
            else{
                Toast.makeText(this, "Senha incorreta", Toast.LENGTH_SHORT).show();
            }
        });

        cancelar.setOnClickListener(v -> {
            Intent intent = new Intent(this, TelaUsuario.class);
            startActivity(intent);
        });



    }
}