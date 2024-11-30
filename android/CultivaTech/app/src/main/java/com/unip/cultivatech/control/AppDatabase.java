package com.unip.cultivatech.control;

import android.content.Context;
import androidx.room.Database;
import androidx.room.Room;
import androidx.room.RoomDatabase;
import com.unip.cultivatech.model.Usuario;
import com.unip.cultivatech.dao.UsuarioDao;
import com.unip.cultivatech.model.Produto;
import com.unip.cultivatech.dao.ProdutoDao;

@Database(entities = {Usuario.class, Produto.class}, version = 1)
public abstract class AppDatabase extends RoomDatabase {

    // DAOs
    public abstract UsuarioDao usuarioDao();
    public abstract ProdutoDao produtoDao();

    // Instância do banco de dados
    private static AppDatabase INSTANCE;

    public static AppDatabase getDatabase(Context context) {
        if (INSTANCE == null) {
            synchronized (AppDatabase.class) {
                if (INSTANCE == null) {
                    INSTANCE = Room.databaseBuilder(context.getApplicationContext(),
                                    AppDatabase.class, "app_database")
                            .fallbackToDestructiveMigration()  // Para a migração do banco, caso necessário
                            .build();
                }
            }
        }
        return INSTANCE;
    }
}
