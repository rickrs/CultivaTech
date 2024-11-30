# MenuProdutos - Tela de Exibição de Produtos

A classe **MenuProdutos** é responsável pela tela que exibe uma lista de produtos, usando um `RecyclerView` para mostrar os itens de forma eficiente. Além disso, oferece navegação para a tela de informações do usuário.

## Componentes

- **RecyclerView**:
  - `recyclerView`: Componente que exibe a lista de produtos.
  - **ProdutoAdapter**: Adaptador que popula o `RecyclerView` com os produtos recuperados do banco de dados.

- **ImageView**:
  - `iconUser`: Ícone do usuário que, ao ser clicado, redireciona para a tela de informações do usuário.

## Fluxo de Execução

### Método `onCreate()`

1. **Inicialização do Layout**:
   - O layout da tela é configurado com o arquivo XML `activity_menu_produtos.xml`.

2. **Configuração das Barras de Sistema**:
   - A interface é configurada para respeitar as barras de sistema (como a barra de status e navegação) usando a biblioteca `EdgeToEdge` e o método `ViewCompat.setOnApplyWindowInsetsListener`.

3. **Instância do Banco de Dados**:
   - Uma instância do banco de dados `AppDatabase` é criada, permitindo o acesso às entidades de produtos.

4. **Configuração do RecyclerView**:
   - O `RecyclerView` é configurado com um `LinearLayoutManager`, que organiza os itens de forma linear (um abaixo do outro).
   - O método `setHasFixedSize(true)` é chamado para melhorar a performance, pois o tamanho dos itens é fixo.

5. **Recuperação da Lista de Produtos**:
   - A lista de produtos é recuperada do banco de dados através do método `listarProdutos` da `produtoDao`.

6. **Configuração do Adapter**:
   - O `ProdutoAdapter` é instanciado e passado para o `RecyclerView`, com a lista de produtos a ser exibida.

7. **Ação do Ícone do Usuário**:
   - O ícone de usuário (`iconUser`) é configurado com um ouvinte de clique. Quando o ícone é clicado, o usuário é redirecionado para a tela de informações do usuário (`TelaUsuario`).

