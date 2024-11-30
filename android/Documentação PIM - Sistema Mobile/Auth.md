# Classe Auth - Serviço de Autenticação de Usuários

A classe `Auth` fornece funcionalidades para registro, login, atualização e exclusão de usuários no aplicativo **CultivaTech**. Ela interage com o banco de dados local, utilizando o **Room Database**.

## Métodos

### Construtor
#### `Auth(Context context)`
- **Descrição**: Construtor que inicializa a classe com o contexto da aplicação e cria a instância do banco de dados **Room**.
- **Parâmetros**:
  - `context`: O contexto da aplicação, utilizado para criar o banco de dados.
  
### Método: Registrar Usuário
#### `registrarUsuario(String nome, String email, String senha, String telefone, String rua, String cidade, String estado)`
- **Descrição**: Registra um novo usuário no banco de dados.
- **Parâmetros**:
  - `nome`: Nome completo do usuário.
  - `email`: E-mail do usuário (será utilizado para login).
  - `senha`: Senha do usuário (pode ser uma string simples, mas recomenda-se fazer um hash da senha antes de salvar).
  - `telefone`: Número de telefone do usuário.
  - `rua`: Endereço do usuário.
  - `cidade`: Cidade onde o usuário reside.
  - `estado`: Estado onde o usuário reside.
- **Execução**: Insere os dados de um novo usuário no banco de dados em uma thread separada.

### Método: Login de Usuário
#### `loginUsuario(String email, String senha)`
- **Descrição**: Realiza o login de um usuário verificando as credenciais fornecidas.
- **Parâmetros**:
  - `email`: E-mail do usuário para buscar no banco de dados.
  - `senha`: Senha do usuário para comparação.
- **Retorno**: Retorna `true` se o login for bem-sucedido (email e senha coincidirem), caso contrário, retorna `false`.
- **Execução**: Busca o usuário pelo email no banco de dados e verifica se a senha corresponde à armazenada.

### Método: Atualizar Usuário
#### `atualizarUsuario(String id, String nome, String email, String senha, String telefone, String rua, String cidade, String estado)`
- **Descrição**: Atualiza os dados de um usuário no banco de dados.
- **Parâmetros**:
  - `id`: E-mail ou identificador do usuário a ser atualizado.
  - `nome`: Novo nome do usuário.
  - `email`: Novo e-mail do usuário.
  - `senha`: Nova senha do usuário (pode ser uma string simples, mas recomenda-se fazer um hash da senha antes de salvar).
  - `telefone`: Novo número de telefone do usuário.
  - `rua`: Novo endereço do usuário.
  - `cidade`: Nova cidade do usuário.
  - `estado`: Novo estado do usuário.
- **Execução**: Busca o usuário no banco de dados pelo e-mail e atualiza os campos fornecidos. A atualização ocorre em uma thread separada.

### Método: Deletar Usuário
#### `deletarUsuario(String email)`
- **Descrição**: Deleta um usuário do banco de dados.
- **Parâmetros**:
  - `email`: E-mail do usuário a ser deletado.
- **Execução**: Busca o usuário no banco de dados pelo e-mail e deleta os dados desse usuário. A exclusão ocorre em uma thread separada.

## Observações

- **Uso de Threads**: Todas as operações de banco de dados (inserir, atualizar, deletar) são realizadas em threads separadas para evitar bloquear a thread principal da UI.
- **Validação de Senha**: A senha é armazenada sem hash na versão atual, mas é altamente recomendado que ela seja criptografada antes de ser salva no banco de dados.
- **Permissões de Banco de Dados**: O banco de dados é acessado na thread principal para fins de testes (`allowMainThreadQueries()`), mas em uma aplicação de produção, deve-se utilizar operações assíncronas para acessar o banco de dados para não bloquear a interface do usuário.

## Dependências

- **Room Database**: A classe utiliza a biblioteca Room para interação com o banco de dados local SQLite.
- **Banco de Dados**: A base de dados utilizada é `cultivatech.db`.

