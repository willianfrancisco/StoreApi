# StoreApi

## Sobre o desafio
O desafio consiste em criar uma API REST que contenha os seguintes end-points:

- GET starstore/products -> Retorna uma lista com todos os produtos adicionados. <br>
- POST starstore/product -> Acrescenta um produto novo. <br>
- POST starstore/buy -> Realiza uma nova compra. <br>
- GET starstore/history -> Retorna uma lista com todas as compras realizadas. <br>
- GET starstore/history/{clientID} -> Retorna uma lista com todas as compras realizadas por um cliente.

## Solucao
Para resolver o desafio eu optei por utilizat o dotnet core 6, aplicando uma arquitetura camadas juntos com os padrões arquiteturais do DDD, Arquitetura Limpar e SOLID, e utilizei o MSSQL Server como banco de dados da applicação.

Para esse projeto foi criado um arquivo Docker e docker-compose para dockerizar a api e o banco de dados.

## Como rodar o projeto
Para rodar o docker e subir o container com o projeto basta entrar dentro da pasta src da applicação e rodar o comando docker-compose up.
No navegador acessar a url http://localhost:7281/swagger/index.html.

Para gerar o token utilize o seguinte request body:
```json
{
  "user": "admin",
  "password": "1234"
}
```

