# MainActivity - Tela de Login

A `MainActivity` é responsável pela interface de login do aplicativo **CultivaTech**. Ela permite que o usuário insira seu e-mail e senha para realizar o login e também fornece um botão para redirecionar o usuário para a tela de cadastro.

## Componentes

- **EditText**:
  - `editTextEmail`: Campo para o usuário inserir o e-mail.
  - `editTextPassword`: Campo para o usuário inserir a senha.
  
- **Button**:
  - `btnLogin`: Botão para realizar o login.
  - `btnCadastro`: Botão para redirecionar o usuário à tela de criação de conta.

- **AppDatabase**: Utiliza o Room Database para acessar os dados do usuário.

## Fluxo de Execução

### Método `onCreate()`

1. **Inicialização do Banco de Dados**:
   - O banco de dados **Room** é inicializado, permitindo o acesso à base de dados `cultivatech.db` com a configuração `allowMainThreadQueries()` (uso para testes, não recomendado em produção).
   
2. **Inicialização das Views**:
   - As views `editTextEmail`, `editTextPassword`, `btnLogin` e `btnCadastro` são inicializadas com os respectivos IDs do layout XML.
   
3. **Listagem de Usuários**:
   - O método `listarUsuarios()` é utilizado para buscar todos os usuários armazenados no banco de dados. O nome de cada usuário é exibido no log usando `Log.d()`.

4. **Configuração do Botão de Login**:
   - O botão `btnLogin` é configurado para, ao ser clicado, capturar os dados inseridos pelo usuário no `editTextEmail` e `editTextPassword`.
   - Se os campos de e-mail ou senha estiverem vazios, o usuário será notificado com uma mensagem via `Toast`.
   - Se os campos não estiverem vazios, o método `loginUsuario()` da classe `Auth` é chamado para validar as credenciais.

5. **Verificação do Login**:
   - Se o login for bem-sucedido, o ID do usuário é salvo no `SharedPreferences` para persistir a sessão.
   - O usuário é então redirecionado para a tela `MenuProdutos` usando um `Intent`.
   - Se o login falhar, uma mensagem de erro é exibida usando `Toast`.

6. **Configuração do Botão de Cadastro**:
   - O botão `btnCadastro` redireciona o usuário para a tela `CriarConta` para permitir que ele crie uma nova conta.

## Funcionamento Detalhado

- **Login de Usuário**:
  - Quando o usuário clica no botão de login, o aplicativo verifica se o e-mail e a senha são válidos.
  - Se o login for bem-sucedido, o ID e o e-mail do usuário são salvos no `SharedPreferences`.
  - Em seguida, o usuário é redirecionado para a tela de menu de produtos.

- **Cadastro de Usuário**:
  - O botão de cadastro redireciona o usuário para a tela `CriarConta`, onde ele pode se cadastrar.
