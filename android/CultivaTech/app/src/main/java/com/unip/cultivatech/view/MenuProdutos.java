package com.unip.cultivatech.view;

import android.content.Intent;
import android.os.Bundle;
import android.widget.ImageView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import androidx.room.Room;

import com.unip.cultivatech.R;
import com.unip.cultivatech.control.AppDatabase;
import com.unip.cultivatech.model.Produto;

import java.util.ArrayList;
import java.util.List;

public class MenuProdutos extends AppCompatActivity {

    private RecyclerView recyclerView;
    private ProdutoAdapter produtoAdapter;
    private List<Produto> listaProdutos;
    private ImageView iconUser;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_menu_produtos);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        AppDatabase db = Room.databaseBuilder(this, AppDatabase.class, "cultivatech.db")
                .allowMainThreadQueries()
                .build();

        // Configurar o RecyclerView
        recyclerView = findViewById(R.id.recyclerViewProdutos);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));  // Usando um LayoutManager linear
        recyclerView.setHasFixedSize(true); // Melhor performance se o tamanho dos itens for fixo

        // Inicializar lista de produtos
        listaProdutos = db.produtoDao().listarProdutos();

        produtoAdapter = new ProdutoAdapter(this, listaProdutos);
        recyclerView.setAdapter(produtoAdapter);

        // Configurar o padding para a área de conteúdo, levando em consideração a barra de sistema
        iconUser = findViewById(R.id.iconUser);
        iconUser.setOnClickListener(v -> {
            Intent intent = new Intent(this, TelaUsuario.class);
            startActivity(intent);
        });


    }
}
