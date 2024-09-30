# Guia de Configuração - VIMA

## 1. Download dos Projetos BackEnd e FrontEnd:
- **FrontEnd**: [https://github.com/MatheusJr014/FrontEnd-Vima](https://github.com/MatheusJr014/FrontEnd-Vima)
- **BackEnd**: [https://github.com/MatheusJr014/BackEnd-Vima](https://github.com/MatheusJr014/BackEnd-Vima)

## Configuração do FrontEnd:
1. Baixe e instale o Node.js: [https://nodejs.org/pt](https://nodejs.org/pt)
2. Extraia o projeto baixado do GitHub e abra-o no Visual Studio Code.
3. No terminal, execute o comando `npm install` para instalar os módulos necessários.
4. Para rodar o projeto, utilize o comando `npm run dev`.
5. O projeto estará rodando. Copie a URL gerada e cole no navegador para visualizar.

## Configuração do BackEnd:
1. Baixe e instale o MySQL Workbench: [https://www.mysql.com/products/workbench/](https://www.mysql.com/products/workbench/)
2. Após a instalação, crie uma nova conexão SQL no Workbench. Clique no símbolo "+" para adicionar uma conexão, nomeie-a como "localhost", e clique em "Test Connection" para verificar se a conexão foi estabelecida corretamente.
3. Crie um banco de dados com o nome `vima`. Feito isso, a configuração do Workbench estará concluída.

## Iniciando o Projeto com C#:
1. Extraia o projeto e abra o arquivo `VimaV2.csproj` no Visual Studio (certifique-se de que o Visual Studio esteja instalado).
2. No terminal do Visual Studio, execute os seguintes comandos para instalar as dependências:

    ```bash
    dotnet add package {Library}
    dotnet add package Pomelo.EntityFrameworkCore.MySql
    dotnet add package Pomelo.EntityFrameworkCore.MySql.Design
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    dotnet tool install --global dotnet-ef
    dotnet ef
    dotnet add package Swashbuckle.AspNetCore
    ```

3. Na pasta `Database`, localize a linha de código responsável pela conexão com o banco de dados. Substitua os parâmetros da conexão com os seguintes valores: 
   - `server=localhost`
   - `user id=root`
   - `database=vima` 
   
   Adicione a senha caso tenha configurado uma no banco.

4. Para carregar as tabelas no banco de dados, execute o comando:

    ```bash
    dotnet ef database update
    ```

5. Após seguir todos os passos, rode o backend clicando em "Play" no Visual Studio.

## Requisitos para Execução:
- Certifique-se de que o BackEnd e o FrontEnd estejam rodando simultaneamente.
- Mantenha o banco de dados ativo durante a execução.
