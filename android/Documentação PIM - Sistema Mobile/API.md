# Documento de Requisitos de Funcionalidade

## Projeto: SafeEats

### Objetivo
Definir as funcionalidades relacionadas ao gerenciamento de usuários e produtos no banco de dados do aplicativo **SafeEats**, utilizando a biblioteca Room no Android.

---

## Entidades e Classes

### 1. **Banco de Dados: AppDatabase**
A classe `AppDatabase` é responsável por gerenciar as operações do banco de dados do aplicativo.

#### Funcionalidades:
- **Gerenciamento de DAOs:**  
  A classe expõe dois métodos abstratos para obter os DAOs (Data Access Objects) utilizados no sistema:
  - `UsuarioDao`: Gerenciamento de usuários.
  - `ProdutoDao`: Gerenciamento de produtos.
  
- **Instância única do banco de dados:**  
  Garante que apenas uma instância do banco seja criada durante a execução do aplicativo por meio do método:
  - `getDatabase(Context context)`:
    - Retorna a instância do banco de dados.
    - Configurado com `fallbackToDestructiveMigration` para gerenciar migrações simples.

---

### 2. **Interface: UsuarioDao**
A interface `UsuarioDao` define as operações de banco de dados relacionadas à entidade `Usuario`.

#### Funcionalidades:
1. **Inserir um novo usuário**
   - **Método:** `inserirUsuario(Usuario usuario)`
   - **Descrição:** Adiciona um novo usuário ao banco de dados.

2. **Atualizar um usuário**
   - **Método:** `atualizarUsuario(Usuario usuario)`
   - **Descrição:** Modifica os dados de um usuário existente.

3. **Deletar um usuário**
   - **Método:** `deletarUsuario(Usuario usuario)`
   - **Descrição:** Remove um usuário específico do banco de dados.

4. **Buscar um usuário pelo email**
   - **Método:** `buscarUsuarioPorEmail(String email)`
   - **Descrição:** Retorna os dados de um único usuário com base no email informado.

5. **Listar todos os usuários**
   - **Método:** `listarUsuarios()`
   - **Descrição:** Retorna uma lista com todos os usuários cadastrados.

---

### 3. **Interface: ProdutoDao**
A interface `ProdutoDao` define as operações de banco de dados relacionadas à entidade `Produto`.

#### Funcionalidades:
1. **Inserir um novo produto**
   - **Método:** `inserirProduto(Produto produto)`
   - **Descrição:** Adiciona um novo produto ao banco de dados.

2. **Atualizar um produto existente**
   - **Método:** `atualizarProduto(Produto produto)`
   - **Descrição:** Modifica os dados de um produto existente.

3. **Deletar um produto**
   - **Método:** `deletarProduto(Produto produto)`
   - **Descrição:** Remove um produto específico do banco de dados.

4. **Buscar todos os produtos**
   - **Método:** `listarProdutos()`
   - **Descrição:** Retorna uma lista com todos os produtos cadastrados.

5. **Buscar um produto pelo ID**
   - **Método:** `buscarProdutoPorId(int id)`
   - **Descrição:** Retorna os dados de um único produto com base no ID informado.

---

## Benefícios e Objetivos
- **Centralização e organização:**  
  O design permite gerenciar todas as operações de banco de dados de maneira estruturada e eficiente.
  
- **Escalabilidade:**  
  A arquitetura modular possibilita adicionar novas entidades e funcionalidades ao banco de dados de forma simples.

- **Manutenção facilitada:**  
  Utilizar os DAOs garante um código mais limpo, reutilizável e alinhado com boas práticas de desenvolvimento.

---

Esta documentação foi elaborada para auxiliar no entendimento das funcionalidades relacionadas ao banco de dados do projeto **SafeEats**.
