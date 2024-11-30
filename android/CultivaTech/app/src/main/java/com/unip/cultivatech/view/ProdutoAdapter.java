package com.unip.cultivatech.view;

import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;
import com.unip.cultivatech.R;
import com.unip.cultivatech.model.Produto;

import java.util.List;

public class ProdutoAdapter extends RecyclerView.Adapter<ProdutoAdapter.ProdutoViewHolder> {
    private List<Produto> produtos;
    private Context context;

    public ProdutoAdapter(Context context, List<Produto> produtos) {
        this.context = context;
        this.produtos = produtos;
    }

    @NonNull
    @Override
    public ProdutoViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(context).inflate(R.layout.item_produto, parent, false);

        Log.d("ProdutoAdapter", "Iniciando Adapter...");
        return new ProdutoViewHolder(view);
    }

    @SuppressLint("DefaultLocale")
    @Override
    public void onBindViewHolder(@NonNull ProdutoViewHolder holder, int position) {

        Log.d("ProdutoAdapter", "Iniciando ViewHolder");
        Produto produto = produtos.get(position);

        Log.d("ProdutoAdapter", produto.getNome());
        holder.tvNomeProduto.setText(produto.getNome());

        Log.d("ProdutoAdapter", String.format("%f", produto.getPreco()));
        holder.tvPrecoProduto.setText(String.format("R$ %.2f", produto.getPreco()));

        // Carregar imagem do produto
        Glide.with(context)
                .load(produto.getImagem()) // URL da imagem
                .into(holder.ivProduto);

        holder.btnComprar.setOnClickListener(v -> {
            Intent intent = new Intent(context, TelaProduto.class);
            intent.putExtra("Produto", produto);
            context.startActivity(intent);
        });
    }

    @Override
    public int getItemCount() {
        return produtos.size();
    }

    public static class ProdutoViewHolder extends RecyclerView.ViewHolder {
        TextView tvNomeProduto, tvPrecoProduto;
        ImageView ivProduto;
        Button btnComprar;

        public ProdutoViewHolder(@NonNull View itemView) {
            super(itemView);
            tvNomeProduto = itemView.findViewById(R.id.tvNomeProduto);
            tvPrecoProduto = itemView.findViewById(R.id.tvPrecoProduto);
            ivProduto = itemView.findViewById(R.id.ivProduto);
            btnComprar = itemView.findViewById(R.id.btnComprar);
        }
    }
}
