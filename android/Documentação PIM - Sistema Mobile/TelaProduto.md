# Classe `TelaProduto`

A classe `TelaProduto` é responsável por exibir os detalhes de um produto selecionado. Ela recebe os dados do produto a partir de uma `Intent` e os exibe em uma interface de usuário, incluindo a imagem, nome, descrição, preço e quantidade do produto. Também há um botão de compra, embora a ação de compra ainda precise ser implementada.

## Requisitos de Funcionalidades

1. **Exibição dos detalhes do produto**:
   - **Imagem do produto**: A imagem do produto é carregada a partir de uma URL usando a biblioteca **Glide**, com uma imagem de placeholder sendo exibida enquanto a imagem real é carregada.
   - **Nome do produto**: O nome do produto é exibido em um `TextView`.
   - **Descrição do produto**: A descrição do produto é exibida em um `TextView`.
   - **Preço do produto**: O preço do produto é formatado como "R$ X,XX" e exibido em um `TextView`.
   - **Quantidade do produto**: A quantidade disponível do produto é exibida em um `TextView`.

2. **Ação de compra**: O botão "Comprar" está presente na tela, porém, a funcionalidade para realizar a compra precisa ser implementada.

3. **Ajustes de UI para barras de sistema**: O layout da atividade é ajustado para lidar com barras de sistema (como a barra de status e barra de navegação) utilizando a classe `ViewCompat` e o método `setOnApplyWindowInsetsListener`.

## Métodos

### `onCreate(Bundle savedInstanceState)`
- **Objetivo**: Inicializar a tela e configurar os componentes de interface com os dados do produto.
- **Processos**:
  - A função `EdgeToEdge.enable(this)` permite um layout de borda a borda, utilizando a funcionalidade de telas modernas com Android.
  - O método `setOnApplyWindowInsetsListener` é usado para ajustar o preenchimento da tela de acordo com as barras do sistema (barra de status e navegação).
  - O objeto `Produto` é recuperado da `Intent` que foi passada para essa `Activity`, utilizando `getSerializableExtra("Produto")`.
  - Os componentes de UI (como `ImageView`, `TextView` e `Button`) são inicializados.
  - Os campos são preenchidos com os dados do produto, se o objeto `Produto` for não nulo.

### Configuração dos Componentes de UI
- **Imagem**: A imagem do produto é carregada usando a biblioteca **Glide**, com uma imagem de placeholder definida como `R.drawable.cart`.
- **Nome**: O nome do produto é exibido em um `TextView` (`tvNomeProduto`).
- **Descrição**: A descrição do produto é exibida em um `TextView` (`tvDescricaoProduto`).
- **Preço**: O preço do produto é formatado e exibido em um `TextView` (`tvPrecoProduto`).
- **Quantidade**: A quantidade do produto é exibida em um `TextView` (`tvQuantidadeProduto`).
- **Botão de compra**: O botão de compra (`btnComprar`) está configurado com um listener de clique, mas a ação de compra ainda precisa ser implementada.

## Fluxo de Execução

1. A `TelaProduto` é carregada quando o usuário clica no botão "Comprar" na tela anterior.
2. O produto selecionado é passado através de uma `Intent`, e seus dados são extraídos no método `onCreate`.
3. A tela é preenchida com os detalhes do produto.
4. O usuário pode visualizar os detalhes do produto e, eventualmente, clicar no botão de compra (ação ainda não implementada).

## Dependências

- **Glide**: Usada para carregar a imagem do produto de forma eficiente.
- **ViewCompat e WindowInsetsCompat**: Usadas para adaptar o layout com as barras do sistema, como a barra de status e navegação.
- **EdgeToEdge**: Permite um layout que utiliza toda a área da tela, sem restrições das barras de sistema.

## Pontos a Implementar

- A lógica de compra no botão "Comprar" precisa ser implementada, provavelmente para adicionar o produto ao carrinho ou iniciar o processo de pagamento.
