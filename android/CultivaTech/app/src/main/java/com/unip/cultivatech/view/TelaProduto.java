package com.unip.cultivatech.view;

import android.os.Bundle;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Button;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.bumptech.glide.Glide;
import com.unip.cultivatech.R;
import com.unip.cultivatech.model.Produto;

public class TelaProduto extends AppCompatActivity {
    Produto produto;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_tela_produto);

        // Aplicar insetos para o layout (Barra de navegação)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        // Recuperando o objeto Produto da Intent
        produto = (Produto) getIntent().getSerializableExtra("Produto");

        // Inicializando os componentes de UI
        ImageView ivProduto = findViewById(R.id.ivProduto);
        TextView tvNomeProduto = findViewById(R.id.tvNomeProduto);
        TextView tvDescricaoProduto = findViewById(R.id.tvDescricaoProduto);
        TextView tvPrecoProduto = findViewById(R.id.tvPrecoProduto);
        TextView tvQuantidadeProduto = findViewById(R.id.tvQuantidadeProduto);
        Button btnComprar = findViewById(R.id.btnComprar);

        // Preenchendo os campos com os dados do Produto
        if (produto != null) {
            // Usando Glide para carregar a imagem do produto
            Glide.with(this)
                    .load(produto.getImagem()) // Aqui você carrega a imagem usando o URL ou caminho
                    .placeholder(R.drawable.cart) // Imagem de placeholder
                    .into(ivProduto);

            // Definindo os outros campos
            tvNomeProduto.setText(produto.getNome());
            tvDescricaoProduto.setText(produto.getDescricao());
            tvPrecoProduto.setText(String.format("R$ %.2f", produto.getPreco())); // Formatando o preço
            tvQuantidadeProduto.setText(String.format("Quantidade: %d", produto.getQuantidade()));

            // Configuração do botão de comprar (Exemplo)
            btnComprar.setOnClickListener(v -> {
                // Adicione o código para ação ao clicar no botão Comprar
            });
        }
    }
}
