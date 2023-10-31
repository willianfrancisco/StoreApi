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

### Escolha da arquitetura 
- Eu optei pela escolha de arquitetura em camadas junto ao padrão arquitetural de arquitetura limpa e SOLID  pois isso geraria uma organização simples e clara no quesito de responsabilidades facilitaria o entendimento e organização do codigo.
- Poderia utilizar uma arquitetura com 4 camadas, Domain,Application,Infra.Data e UI, porém isso geraria um forte acoplamento entre as camadas de Infra.Data e UI e seria necessario instalar pacotes que não seriam utilizados pela camada de UI, por esse motivo criei a Infra.Data.Ioc que servira como um intermediador entre as duas camadas. 

### Escolha da linguagem
- Optei pelo uso do asp net core 6 web api pela performace da linguagem e facilidade para utilizar o entity framework core para utilizar o padrão de coding first, assim economizando tempo na hora de criar o banco de dados e as tabelas.
- Eu coloquei na startup do projeto para applicar a migration assim que fosse iniciado o projeto para que assim que o docker suba ele crie o banco de dados que sera utilizado, em um ambiente empresarial eu não usaria dessa forma pois se você tiver mais de um nó em execução (por exemplo, se estiver executando uma configuração com balanceamento de carga), é possível que cada nó tente executar as migrações na inicialização.

### Escolha do banco de dados
- Optei pelo uso do MS-SQL SERVER por ser um banco de dados relacional que no contexto do desafio por ser uma loja ele precisa garantir ACID.

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

