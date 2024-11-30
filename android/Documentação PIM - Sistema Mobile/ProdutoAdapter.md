# Classe `ProdutoAdapter`

A classe `ProdutoAdapter` é responsável por adaptar uma lista de objetos `Produto` e exibi-los em um `RecyclerView` dentro de uma interface de usuário Android. O adapter infla um layout personalizado para cada item da lista e vincula os dados aos componentes da interface, como o nome, preço e imagem do produto.

## Requisitos de Funcionalidades

1. **Exibição dos produtos**: A classe adapta uma lista de objetos `Produto` e exibe as informações de cada produto em um item do `RecyclerView`.
   
2. **Exibição de informações do produto**:
   - **Nome do produto**: O nome do produto é exibido em um `TextView`.
   - **Preço do produto**: O preço do produto é formatado como "R$ X,XX" e exibido em um `TextView`.
   - **Imagem do produto**: A imagem do produto é carregada usando a biblioteca **Glide** a partir da URL fornecida e exibida em um `ImageView`.
   
3. **Ação de compra**: Ao clicar no botão "Comprar", o usuário é redirecionado para a `TelaProduto`, passando o objeto `Produto` selecionado como `Intent`.

## Métodos

### `onCreateViewHolder`
- **Objetivo**: Inflar o layout para cada item da lista e criar uma nova instância do `ProdutoViewHolder`.
- **Parâmetros**:
  - `parent`: O `ViewGroup` que irá conter o item de layout.
  - `viewType`: O tipo de visualização, utilizado para diferentes tipos de itens.
- **Retorno**: Retorna um novo `ProdutoViewHolder`, que mantém as referências aos componentes do layout.

### `onBindViewHolder`
- **Objetivo**: Vincular os dados do produto ao `ViewHolder` para cada item da lista.
- **Parâmetros**:
  - `holder`: O `ProdutoViewHolder`, que contém as referências para os componentes da interface.
  - `position`: A posição do item na lista de produtos.
- **Processos**:
  - O nome e o preço do produto são configurados nos `TextViews` correspondentes.
  - A imagem do produto é carregada usando **Glide** a partir da URL do produto.
  - Um listener de clique é configurado no botão "Comprar" para iniciar uma nova `Activity` (`TelaProduto`), passando o produto como dado extra na `Intent`.

### `getItemCount`
- **Objetivo**: Retornar o número total de itens na lista de produtos.
- **Retorno**: Retorna o tamanho da lista `produtos`.

### `ProdutoViewHolder`
- **Objetivo**: Representar um item de layout de produto dentro do `RecyclerView`, mantendo referências aos componentes da interface.
- **Componentes**:
  - `tvNomeProduto`: `TextView` que exibe o nome do produto.
  - `tvPrecoProduto`: `TextView` que exibe o preço do produto formatado.
  - `ivProduto`: `ImageView` para exibir a imagem do produto.
  - `btnComprar`: `Button` para iniciar a ação de compra e redirecionar para a tela do produto.
  
## Fluxo de Execução

1. O `ProdutoAdapter` é criado com a lista de produtos e o contexto.
2. Cada item de produto é inflado e vinculado aos componentes da interface no método `onBindViewHolder`.
3. Quando o botão "Comprar" é clicado, o produto selecionado é enviado para a `TelaProduto` através de uma `Intent`.

## Dependências

- **Glide**: Utilizada para carregar imagens do produto de forma eficiente.
- **RecyclerView**: Utilizado para exibir a lista de produtos de forma reciclada e eficiente.
