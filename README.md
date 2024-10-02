# ASP.NET Core MVC Clean Architecture Project

![image](https://github.com/user-attachments/assets/4a8ad1b0-bfb5-45d7-bd0e-4157f03fd9c6)

## Descrição do Projeto

Este projeto é uma aplicação ASP.NET Core MVC desenvolvida seguindo os princípios da **Clean Architecture** e as melhores práticas de engenharia de software. A arquitetura limpa garante que a aplicação seja modular, fácil de manter, testar e estender, separando as responsabilidades em diferentes camadas e respeitando as regras de dependência.

### Objetivo

O objetivo deste projeto é demonstrar a implementação de uma aplicação ASP.NET Core MVC moderna e aderente aos princípios da **Clean Architecture**, utilizando as tecnologias mais recentes, como .NET 8, CQRS, e padrões de design como o Repository e o Domain-Driven Design (DDD).

## Estrutura do Projeto

A solução foi estruturada em 5 projetos principais, cada um com uma responsabilidade clara:

- **Domain**: Contém as entidades do domínio, interfaces de repositório e validações. Não depende de nenhuma outra camada, garantindo a independência de frameworks.
- **Application**: Implementa a lógica de negócios e regras de aplicação. Utiliza o padrão **CQRS** para a separação de comandos e consultas e **MediatR** para a orquestração das operações.
- **Infrastructure**: Camada responsável pelo acesso a dados e comunicação externa (ex.: banco de dados SQL Server). Implementa os repositórios e os contratos definidos na camada de domínio.
- **IoC (Inversion of Control)**: Centraliza as injeções de dependência da aplicação. Aqui configuramos os serviços necessários para todas as camadas.
- **Presentation**: A aplicação ASP.NET Core MVC, que consome as camadas de domínio e aplicação para exibir os dados de forma organizada e interativa para o usuário final.
- **API**: Um módulo adicional que expõe os serviços por meio de uma API RESTful, utilizando **Swagger** para documentação, **JWT** para autenticação, e **Entity Framework** para gerenciamento de usuários.

## Tecnologias Utilizadas

- **.NET 8**: Framework principal utilizado para o desenvolvimento da aplicação.
- **ASP.NET Core MVC**: Camada de apresentação para exibir e gerenciar as interações do usuário.
- **Entity Framework Core**: Para o mapeamento objeto-relacional (ORM) e gerenciamento de dados com o SQL Server.
- **CQRS (Command Query Responsibility Segregation)**: Implementado para separar as operações de leitura e escrita.
- **MediatR**: Biblioteca para implementar o padrão CQRS, facilitando a comunicação entre componentes.
- **AutoMapper**: Para mapeamento automático entre DTOs e entidades do domínio.
- **Injeção de Dependência**: Configurada para garantir um código modular e testável.
- **Domain-Driven Design (DDD)**: Padrão para modelar o sistema baseado no domínio da aplicação.
- **Repository Pattern**: Para centralizar a lógica de acesso a dados e promover o encapsulamento.
- **Swagger**: Para documentar a API e facilitar a interação com os endpoints.
- **JWT (JSON Web Token)**: Para autenticação segura nas requisições da API.
- **ASP.NET Core Identity**: Para gerenciar a autenticação e autorização de usuários.

## Arquitetura

### Princípios da Clean Architecture

A Clean Architecture garante que as dependências entre os projetos respeitem as direções corretas e que as regras de negócio sejam independentes de frameworks, UI ou bancos de dados. As regras de dependência principais incluem:

1. **Independência de Frameworks**: O projeto de domínio não conhece as bibliotecas externas, mantendo-se puro.
2. **Independência da UI**: As camadas de negócio podem ser testadas sem a necessidade da interface gráfica.
3. **Teste e Manutenção Facilitados**: A estrutura modular facilita a aplicação de testes unitários e de integração, além de facilitar a inclusão de novas funcionalidades.

## Estrutura do Código

- **Domain/Entities**: Entidades principais que representam os objetos de negócio.
- **Application/Services**: Regras de negócio e coordenação de operações entre as camadas.
- **Infrastructure/Data**: Implementações concretas dos repositórios e persistência de dados.
- **Presentation/Controllers**: Controladores responsáveis por receber as requisições e retornar as respostas à UI.
- **API/Controllers**: Controladores da API responsáveis por expor os serviços e gerenciar as requisições da API.

## Configuração e Execução

### Pré-requisitos

- **.NET 8 SDK**
- **SQL Server** (ou outro banco de dados configurado no `appsettings.json`)

### Passos para Executar

1. **Clonar o Repositório**:
   ```bash
   git clone https://github.com/seu-usuario/seu-projeto.git
   cd seu-projeto
   ```

2. **Restaurar as Dependências**:
   ```bash
   dotnet restore
   ```

3. **Aplicar Migrações e Atualizar o Banco de Dados**:
   No projeto Infra.Data
   ```bash
   dotnet ef database update
   ```

5. **Rodar a Aplicação**:
   No projeto WebUI ou API
   ```bash
   dotnet run
   ```
   
7. A aplicação estará disponível em `https://localhost` na porta configurada.

## Rotas da API

### 1. Categories

| Método | Rota                  | Descrição                             | Exemplo de Request                                                                                                  | Exemplo de Response                                                  |
|--------|-----------------------|---------------------------------------|---------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------|
| GET    | `/api/categories`     | Obtém todas as categorias             | N/A                                                                                                                 | `[{"id":1, "name":"Category 1"}, {"id":2, "name":"Category 2"}]` |
| GET    | `/api/categories/{id}`| Obtém uma categoria por ID            | N/A (para obter a categoria com ID 1)                                                                               | `{"id":1, "name":"Category 1"}`                                   |
| POST   | `/api/categories`     | Cria uma nova categoria               | ```json { "name": "New Category" } ```                                                                              | `{"id":3, "name":"New Category"}`                                 |
| PUT    | `/api/categories`     | Atualiza uma categoria existente      | ```json { "id": 1, "name": "Updated Category" } ```                                                                | `{"id":1, "name":"Updated Category"}`                             |
| DELETE | `/api/categories/{id}`| Remove uma categoria por ID           | N/A (para remover a categoria com ID 1)                                                                             | `{"id":1, "name":"Category 1"}`                                   |

### 2. Products

| Método | Rota                  | Descrição                             | Exemplo de Request                                                                                                  | Exemplo de Response                                                  |
|--------|-----------------------|---------------------------------------|---------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------|
| GET    | `/api/products`       | Obtém todos os produtos               | N/A                                                                                                                 | `[{"id":1, "name":"Product 1", "description":"Desc 1", "price":9.99, "stock":10, "categoryId":1}]` |
| GET    | `/api/products/{id}`  | Obtém um produto por ID               | N/A (para obter o produto com ID 1)                                                                                 | `{"id":1, "name":"Product 1", "description":"Desc 1", "price":9.99, "stock":10, "categoryId":1}` |
| POST   | `/api/products`       | Cria um novo produto                  | ```json { "name": "New Product", "description": "Desc", "price": 19.99, "stock": 50, "categoryId": 1 } ```      | `{"id":3, "name":"New Product", "description":"Desc", "price":19.99, "stock":50, "categoryId":1}` |
| PUT    | `/api/products`       | Atualiza um produto existente         | ```json { "id": 1, "name": "Updated Product", "description": "Updated Desc", "price": 29.99, "stock": 20, "categoryId": 1 } ``` | `{"id":1, "name":"Updated Product", "description":"Updated Desc", "price":29.99, "stock":20, "categoryId":1}` |
| DELETE | `/api/products/{id}`  | Remove um produto por ID              | N/A (para remover o produto com ID 1)                                                                               | `{"id":1, "name":"Product 1", "description":"Desc 1", "price":9.99, "stock":10, "categoryId":1}` |


## Funcionalidades

- Criação, leitura, atualização e exclusão (CRUD) de dados de exemplo.
- Exemplo de aplicação de CQRS para segregação das operações.
- Injeção de dependências configurada e aplicada em todos os serviços.
- Autenticação e autorização utilizando **ASP.NET Core Identity**.
- API RESTful documentada com Swagger.
- Autenticação JWT para segurança nas requisições.
- Aplicação modular e facilmente extensível.

## Melhorias Futuras

- Adicionar testes unitários e de integração com **xUnit**.
- Adicionar cache e otimização de consultas para maior eficiência.

## Conclusão

Esta aplicação demonstra como a combinação das melhores práticas de arquitetura e as tecnologias modernas permite criar sistemas escaláveis, de fácil manutenção e extensíveis. A Clean Architecture aplicada em ASP.NET Core com .NET 8 oferece uma base sólida para qualquer projeto moderno de software.
