# Classe `TelaUsuario`

A classe `TelaUsuario` é responsável por exibir as informações do usuário logado, incluindo nome, e-mail, telefone e endereço. Também oferece a funcionalidade de modificar ou deletar os dados do usuário e sair da conta, utilizando o banco de dados local (com a biblioteca **Room**) e o compartilhamento de preferências (SharedPreferences) para manter o estado do login.

## Requisitos de Funcionalidades

1. **Exibição das informações do usuário**: A classe exibe os dados do usuário logado, incluindo:
   - **Nome**: Exibido em um `TextView` (`tvNomeUsuario`).
   - **E-mail**: Exibido em um `TextView` (`tvEmailUsuario`).
   - **Senha**: A senha do usuário é mascarada e exibida como "Senha: ********".
   - **Telefone**: Exibido em um `TextView` (`tvTelefoneUsuario`).
   - **Endereço**: Exibido em um `TextView` (`tvEndereco`), assumindo que o endereço é uma `String`.

2. **Modificação de dados**: Ao clicar no botão "Modificar", o usuário é redirecionado para a tela `AtualizarConta` para modificar suas informações.

3. **Deletação de conta**: Ao clicar no botão "Deletar", o usuário é redirecionado para a tela `DeletarUsuario` para realizar a exclusão de sua conta.

4. **Logout**: Ao clicar no botão "Sair", os dados compartilhados (como o e-mail do usuário) são limpos, realizando o logout. O usuário é então redirecionado para a `MainActivity`, onde provavelmente ocorre o processo de login.

## Métodos

### `onCreate(Bundle savedInstanceState)`
- **Objetivo**: Inicializar a tela, preencher os campos com os dados do usuário logado e configurar as ações dos botões.
- **Processos**:
  - As **views** da interface (como `TextViews` e `Buttons`) são inicializadas com o método `findViewById`.
  - O e-mail do usuário logado é recuperado dos **SharedPreferences**.
  - O banco de dados local é acessado utilizando a biblioteca **Room**, e o usuário é buscado através do e-mail.
  - Caso o usuário seja encontrado, os campos de texto são preenchidos com seus dados.
  - Se o usuário não for encontrado no banco de dados, é exibida uma mensagem informando isso.
  - Os botões de **modificar**, **deletar** e **sair** são configurados com listeners para realizar as ações respectivas:
    - **Modificar**: Redireciona o usuário para a tela de atualização de conta (`AtualizarConta`).
    - **Deletar**: Redireciona o usuário para a tela de deletação de conta (`DeletarUsuario`).
    - **Sair**: Limpa os dados do usuário nos **SharedPreferences** e redireciona o usuário para a `MainActivity`, finalizando a tela atual.

### Ações dos Botões

- **Modificar**: Quando o botão "Modificar" é clicado, a tela é redirecionada para a `AtualizarConta`, onde o usuário pode editar suas informações.
- **Deletar**: Quando o botão "Deletar" é clicado, o usuário é levado para a `DeletarUsuario`, onde pode excluir sua conta.
- **Sair**: Quando o botão "Sair" é clicado, o login é removido dos **SharedPreferences**, o que faz com que o usuário seja deslogado, e a `MainActivity` é aberta para que o usuário possa fazer login novamente.

## Fluxo de Execução

1. O usuário entra na tela de perfil `TelaUsuario` após o login bem-sucedido.
2. O e-mail do usuário logado é recuperado dos **SharedPreferences** e utilizado para buscar as informações do usuário no banco de dados **Room**.
3. Se o usuário for encontrado no banco de dados, suas informações são exibidas na tela.
4. O usuário pode então modificar seus dados, deletar sua conta ou sair da conta, interagindo com os respectivos botões.
5. O logout limpa as preferências compartilhadas e redireciona para a tela de login (`MainActivity`).

## Dependências

- **Room**: Usado para interagir com o banco de dados local e buscar os dados do usuário.
- **SharedPreferences**: Usado para armazenar o e-mail do usuário logado, permitindo recuperar o estado do login.
- **Toast**: Usado para exibir mensagens rápidas de feedback, como "Usuário não encontrado" ou "Você saiu da conta."

## Pontos a Melhorar

- A senha do usuário não é exibida diretamente (apenas como um placeholder "********"), mas talvez seja interessante incluir uma opção de visualizar/editar a senha de maneira segura.
- A exclusão de conta (`DeletarUsuario`) pode precisar de uma confirmação adicional para evitar exclusões acidentais.
