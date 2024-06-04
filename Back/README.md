# Ramen GO API!

## Introdução
Bem-vindo à RamenGo API! Esta API foi construída para permitir que os usuários montem pedidos de ramen, escolhendo entre diferentes opções de caldos e proteínas. Abaixo, você encontrará informações sobre como configurar, utilizar e contribuir para este projeto.

## Objetivo do Projeto
O objetivo deste projeto é construir uma API que forneça endpoints para listar as opções de caldos e proteínas disponíveis para um pedido de ramen, além de um endpoint que permita ao usuário fazer um pedido com suas seleções.

## Tecnologias Utilizadas
- C#
- ASP.NET Core
- AWS Lambda
- API Gateway
- PostgreSQL (RDS)

## Configuração e Instalação
Antes de executar a aplicação, certifique-se de ter o .NET 8.0 e instalado em sua máquina, e també mo visual staudio para uma usabilidade mais fácil do projeto.

**Front-end:**
1. Clone o repositório do projeto do GitHub:
```
git clone https://github.com/CzR21/RamenGo-Backend.git
```
2. Navegue até o diretório do projeto:
```
cd RamenGo-Backend
```
3. Execute o aplicativo:
```
dotnet run
```

## Tecnologias Utilizadas
**API:**
- React: Para a construção da interface do usuário.
- TypeScript: Para adicionar tipagem estática ao JavaScript, aumentando a robustez do código.

**Hosting:**
- AWS Lambda: Para execução de código.
- AWS API Gateway : Para criar, publicar, manter, monitorar e proteger APIs.
- AWS RDS PostgreSQL: Para armazenamento de dados dos pacientes.

## Documentação da API

A RamenGo API é documentada utilizando Swagger, o que permite uma visualização interativa e amigável dos endpoints disponíveis e como utilizá-los.

### Acessando a Documentação

Você pode acessar a documentação completa da API no Swagger através do seguinte link:

[Documentação Swagger da RamenGo API](https://yquxto04gk.execute-api.us-east-1.amazonaws.com/Prod/index.html)

### Autenticação

Para acessar os endpoints da API, é necessário incluir um cabeçalho de autenticação com a API key. A chave deve ser incluída nos cabeçalhos das requisições da seguinte forma:

- **Chave do Cabeçalho:** `x-api-key`
- **Valor do Cabeçalho:** `ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf`

Exemplo de Cabeçalho:
```http
x-api-key: ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf
```

## Licença
Este projeto é licenciado sob a MIT License.

## Contato
Para dúvidas ou mais informações sobre o projeto, entre em contato com **César Arandas Silva** - [@CzR21](https://github.com/CzR21).
