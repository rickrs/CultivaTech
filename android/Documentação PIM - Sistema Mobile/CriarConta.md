# CriarConta - Tela de Criação de Conta

A classe **CriarConta** é responsável pela interface de criação de contas de usuário no aplicativo **CultivaTech**. Ela coleta informações do usuário, como nome, e-mail, senha, telefone, endereço e outros dados, e os salva no banco de dados.

## Componentes

- **EditText**:
  - `etNome`: Campo de texto para o nome do usuário.
  - `etEmail`: Campo de texto para o e-mail do usuário.
  - `etSenha`: Campo de texto para a senha do usuário.
  - `etTelefone`: Campo de texto para o telefone do usuário.
  - `etRua`: Campo de texto para a rua do usuário.
  - `etCidade`: Campo de texto para a cidade do usuário.
  - `etEstado`: Campo de texto para o estado do usuário.
  
- **Button**:
  - `btnCadastrar`: Botão para registrar os dados inseridos pelo usuário.

- **Auth**: Classe responsável por gerenciar a autenticação e o registro de novos usuários no banco de dados.

## Fluxo de Execução

### Método `onCreate()`

1. **Inicialização do Layout**:
   - O layout da tela de criação de conta é configurado com o arquivo XML `activity_criar_conta.xml`.

2. **Inicialização dos Campos de Entrada**:
   - Os campos de entrada (`EditText`) e o botão (`Button`) são inicializados a partir do layout.

3. **Inicialização do Serviço de Autenticação**:
   - A classe `Auth` é instanciada, permitindo que as operações de registro de usuários sejam executadas.

4. **Ação do Botão "Cadastrar"**:
   - O botão `btnCadastrar` possui um ouvinte de clique configurado. Quando o usuário clica no botão:
     - Os dados dos campos de texto são recuperados e armazenados em variáveis.
     - Uma validação simples é realizada para garantir que todos os campos foram preenchidos.
     - Se algum campo estiver vazio, um `Toast` é exibido solicitando que o usuário preencha todos os campos.
     - Se todos os campos estiverem preenchidos, o método `registrarUsuario` da classe `Auth` é chamado para registrar o novo usuário no banco de dados.

5. **Feedback para o Usuário**:
   - Após a criação da conta, um `Toast` é exibido informando que a conta foi criada com sucesso.
   - O usuário é redirecionado para a tela de login (`MainActivity`) após a criação da conta.

6. **Redirecionamento e Encerramento da Tela de Cadastro**:
   - O método `finish()` é chamado para fechar a tela de criação de conta e impedir que o usuário retorne à tela de cadastro.

