# DeletarUsuario - Tela de Deleção de Conta

A classe **DeletarUsuario** é responsável pela interface de exclusão da conta do usuário. Ela permite que o usuário forneça sua senha para confirmar a exclusão de sua conta do aplicativo **CultivaTech**.

## Componentes

- **EditText**:
  - `senha`: Campo de texto para o usuário digitar sua senha.
  
- **Button**:
  - `confirmar`: Botão que confirma a exclusão do usuário.
  - `cancelar`: Botão que cancela a exclusão e retorna para a tela anterior.

- **Auth**: Classe responsável por gerenciar a autenticação e a exclusão de usuários no banco de dados.

## Fluxo de Execução

### Método `onCreate()`

1. **Inicialização do Layout**:
   - O layout da tela de deletação de conta é configurado com o arquivo XML `activity_deletar_usuario.xml`.

2. **Configuração das Barras de Sistema**:
   - A interface é configurada para respeitar as barras de sistema (como a barra de status e navegação) usando a biblioteca `EdgeToEdge` e o método `ViewCompat.setOnApplyWindowInsetsListener`.

3. **Recuperação do E-mail do Usuário**:
   - O e-mail do usuário logado é recuperado através do `SharedPreferences`. Ele é usado para buscar o usuário no banco de dados.

4. **Acessando o Banco de Dados**:
   - Uma instância do banco de dados `AppDatabase` é criada, e a classe `Auth` é instanciada para gerenciar a lógica de exclusão do usuário.

5. **Busca do Usuário no Banco de Dados**:
   - O usuário é buscado no banco de dados através do e-mail recuperado dos `SharedPreferences`.

6. **Ação do Botão "Confirmar Deleção"**:
   - O botão `confirmar` tem um ouvinte de clique configurado. Quando o usuário clica em "Confirmar", a senha digitada no campo `senha` é comparada com a senha do usuário recuperada do banco de dados.
   - Se as senhas coincidirem, o método `deletarUsuario` da classe `Auth` é chamado para excluir o usuário do banco de dados.
   - Um `Toast` é exibido informando que o usuário foi deletado, e a tela é redirecionada para a tela de login (`MainActivity`).

7. **Ação do Botão "Cancelar"**:
   - O botão `cancelar` permite que o usuário cancele a operação e retorne para a tela de informações do usuário (`TelaUsuario`).

