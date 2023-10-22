# 🌍 BrazilGeoAPI

A BrazilGeoAPI é uma API que fornece informações geográficas sobre cidades e estados do Brasil. Este projeto é parte de um desafio de desenvolvimento e visa criar uma API robusta com funcionalidades de autenticação, cadastro, pesquisa e importação de dados.

## 🚀 Funcionalidades

- **Autenticação e Autorização:** A API oferece autenticação segura e autorização para proteger os dados sensíveis.

- **Cadastro de E-mail e Senha:** Os usuários podem se cadastrar na plataforma para acessar recursos protegidos.

- **Login (Token, JWT):** A autenticação é baseada em tokens JWT para garantir a segurança das sessões.

- **CRUD de Localidade:** A API permite criar, ler, atualizar e excluir informações sobre códigos, estados e cidades do Brasil.

- **Pesquisa por Cidade e Estado:** Os usuários podem pesquisar cidades e estados com base em critérios específicos.

- **Importação de Dados:** É possível importar dados geográficos a partir de um arquivo Excel.

## 💫   Tecnologias Utilizadas

- **.NET 7:** Versão do Framework .NET para desenvolvimento de aplicações.

- **Asp.Net Core 7:** Framework para desenvolvimento de Apis e aplicações web da Microsoft.

- **Entity Framework core:** tecnologia de ORM para o relacionamenteo entre objectos e entidades do banco de dados, usamos tambem a abordagem Code First para gerar as tabelas apartir das classes de entidaide.

- **SQL Server:** Sistema de Gestão de Base de Dados SGBD da Microsoft escolhido para o respectivo projecto.

- **FLUNT:** Padráo de Notificação desenvolvido pela Balta.io.

- **CQRS:** Padrão arquitectural com o proposito de separar as responsabilidade entre comandos e consultas (Command Query Responsability Segregation).

-  **Adapter:** O padrão Adapter atua como uma ponte entre duas interfaces incompatíveis, para transformar uma entidade em um Dto usamos o padrão adapter.
  
-  **Clean Architecture:** Arquitetura Limpa permite que as mudanças tenham impacto isolado e permite que o sistema seja facilmente estendido e mantido. 


     ![image](https://github.com/RaMadaSilva/BrasilGeoWebApi/assets/91338367/6931f1b7-5d8e-425d-8a07-cc52ba5a00e3)

## Link da API Publicada e Swagger 🔗

API URL: https://brasilgeowebapi.azurewebsites.net
Swagger Docs: https://brasilgeowebapi.azurewebsites.net/index.html/index.html

## 📦 Como Usar

1. Clone este repositório.

2. Configure o ambiente de desenvolvimento e as dependências necessárias.

3. Execute a aplicação.

4. Acesse a documentação da API (Swagger) para entender as rotas e funcionalidades disponíveis.

5. Comece a utilizar as funcionalidades da API.

## 🤝 Contribuição

Sinta-se à vontade para contribuir com melhorias, correções de bugs e novas funcionalidades. Para contribuir, siga os passos:

1. Faça um fork deste repositório.

2. Crie uma branch para sua contribuição: `git checkout -b feature/sua-feature`.

3. Desenvolva e teste suas alterações.

4. Faça commit das alterações: `git commit -m 'Adicione sua mensagem aqui'`.

5. Envie as alterações para seu fork: `git push origin feature/sua-feature`.

6. Crie um pull request neste repositório.

## 📄 Licença

Este projeto está licenciado sob a Licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
