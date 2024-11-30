# AtualizarConta - Tela de Atualização de Conta

A `AtualizarConta` é responsável pela interface de atualização de dados do usuário no aplicativo **CultivaTech**. Ela permite que o usuário altere informações como nome, telefone, e-mail, senha e endereço.

## Componentes

- **EditText**:
  - `etNome`: Campo para o usuário atualizar o nome.
  - `etTelefone`: Campo para o usuário atualizar o telefone.
  - `etEmail`: Campo para o usuário atualizar o e-mail.
  - `etSenha`: Campo para o usuário atualizar a senha.
  - `etRua`: Campo para o usuário atualizar a rua.
  - `etCidade`: Campo para o usuário atualizar a cidade.
  - `etEstado`: Campo para o usuário atualizar o estado.
  
- **Button**:
  - `btnCadastrar`: Botão para salvar as alterações feitas.

- **Auth**: Classe responsável por lidar com a autenticação e atualização de dados no banco de dados.

## Fluxo de Execução

### Método `onCreate()`

1. **Configuração do Layout e Barra de Sistema**:
   - A interface é configurada para trabalhar com barras de sistema de forma adequada, usando a biblioteca `EdgeToEdge` para permitir que o conteúdo ocupe toda a tela.
   - `ViewCompat.setOnApplyWindowInsetsListener` é utilizado para garantir que as barras de sistema (como a barra de status e navegação) não sobreponham o conteúdo.

2. **Inicialização das Views**:
   - Os campos de texto (`EditText`) e o botão de salvar (`Button`) são inicializados a partir do layout `activity_atualizar_conta.xml`.

3. **Recuperação de Dados do Usuário Logado**:
   - O e-mail do usuário logado é recuperado de `SharedPreferences`. Essa informação foi salva na tela de login após o sucesso da autenticação.
   
4. **Acesso ao Banco de Dados**:
   - O banco de dados **Room** é inicializado para buscar os dados do usuário com base no e-mail recuperado.
   
5. **Preenchimento dos Campos**:
   - Os campos de entrada são preenchidos com os dados atuais do usuário, caso o usuário exista no banco de dados.

6. **Configuração do Botão de Salvar**:
   - O botão `btnCadastrar` é configurado para, ao ser clicado, pegar os valores inseridos nos campos e chamar o método `atualizarUsuario()` da classe `Auth`.
   - O método `atualizarUsuario()` atualiza os dados do usuário no banco de dados.

7. **Feedback ao Usuário**:
   - Após a atualização bem-sucedida, uma mensagem de sucesso (`Toast`) é exibida, informando o usuário que seus dados foram atualizados.
   - O usuário é redirecionado para a tela `TelaUsuario` após o sucesso.

