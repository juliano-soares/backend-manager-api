# Backend Para Aplicativo de Gamificação de Eventos

<img src="./src/.github/Captura.PNG" alt="exemplo imagem">

> Este projeto tem como objetivo transformar os eventos em games, incentivando as pessoas a se tornarem mais participativas durante o evento com incentivo de pontuações e recompensas por ações que elas fazem. Este projeto terá dois aplicativos, um para os usuários verem suas pontuações e poderem escanear QR Codes durante o evento que lhes darão pontuações caso elas terminem o desafio proposto no QR Code, também poderão fazer perguntas durante as palestras, compartilhar, ser notificado caso um evento ira começar, avaliar as palestras assistidas, escanear QR Codes de outros usuários e poder visualizar suas redes sociais e assim poder se conectar com elas. O outro será um aplicativo gerenciador para as pessoas do grupo de organização do evento para fazer o check-in, e atribuir pontos aos usuários caso necessário, também visualizar a lista de presença e o ranking da gamificação, e sortear prêmios para as pessoas presentes em uma palestra.  

### Ajustes e melhorias

O projeto ainda está em desenvolvimento e as próximas atualizações serão voltadas nas seguintes tarefas:

- [x] CRUD de usuários na aplicação.
- [x] Ao inserir um usuário gerar automaticamente um QR Code para ele.
- [ ] CRUD de palestras/workshops/eventos
- [ ] Atribuição de pontuação
- [ ] Ranking

## 💻 Pré-requisitos

Antes de começar, verifique se você atendeu aos seguintes requisitos:
* C#
* .Net Core
* Azure
* SQL Server

## API

> Esta Api e o banco de dados estão hopedados no Microsoft Azure e pode ser acessada pelo seguinte link:
[Manager API Swagger](https://sbseg.azurewebsites.net/swagger/index.html)

Ela possui os seguintes rotas:

### Auth

* Login

  Rota de login: para que o usuário faça o login na aplicação e receba um token.

  -  https://sbseg.azurewebsites.net/api​/v1​/auth​/login
  -  Que recebe no corpo o e-mail e a senha do usuário

  ```JSON
  {
    "email": "string",
    "password": "string"
  }
  ```
    
### Upload

* Avatar

  Rota de upload de um avatar: para que o usuário faça um upload de uma imagem base64 para seu perfil.

  -  https://sbseg.azurewebsites.net/api​/v1​/auth​/avatar
  -  Que recebe no corpo o e-mail e um avatar que é uma imagem do tipo base64
  -  Essa requisição também deve ter um token do tipo Bearer vindo do login

  ```JSON
  {
    "email": "string",
    "avatar": "string"
  }
  ```

### User

* Create

  Rota de criação: serve para inserir/criar um novo usuário.

  -  https://sbseg.azurewebsites.net/api​/v1​/users/create
  -  Que recebe no corpo o name, e-mail, password e username

  ```JSON
  {
  "name": "string",
  "email": "stringstri",
  "password": "stringst",
  "username": "stringst"
  }
  ```

* Remove

  Rota de remoção: serve para remover um usuário.

  -  https://sbseg.azurewebsites.net/api​/v1​/users/remove/{id}
  -  Que recebe como parâmetro o id do usuário a ser removido
  -  Essa requisição também deve ter um token do tipo Bearer vindo do login

* Get

  Rota de get: serve para buscar um usuário em específico.

  -  https://sbseg.azurewebsites.net/api​/v1​/users/get/{id}
  -  Que recebe como parâmetro o id do usuário a ser buscado retornando ele caso encontre
  -  Essa requisição também deve ter um token do tipo Bearer vindo do login

* Get-All

  Rota de get: serve para buscar todos os usuários da aplicação

  -  https://sbseg.azurewebsites.net/api​/v1​/users/get-all
  -  Essa requisição também deve ter um token do tipo Bearer vindo do login

* Get-By-Email

  Rota de remoção: serve para remover um usuário.

  -  https://sbseg.azurewebsites.net/api​/v1​/users/get-by-email
  -  Que recebe como parâmetro uma querry com uma string do e-mail do usuário a ser buscado
  -  Essa requisição também deve ter um token do tipo Bearer vindo do login

* Search-by-name

  Rota de get pelo nome: serve para buscar usuários com nome semelhante do requisitado.

  -  https://sbseg.azurewebsites.net/api​/v1​/users/search-by-name
  -  Que recebe como parâmetro uma querry com uma string do nome do usuário a ser buscado
  -  Essa requisição também deve ter um token do tipo Bearer vindo do login

* Search-by-email

  Rota de get pelo email: serve para buscar usuários com email semelhante do requisitado.

  -  https://sbseg.azurewebsites.net/api​/v1​/users/search-by-email
  -  Que recebe como parâmetro uma querry com uma string do email do usuário a ser buscado
  -  Essa requisição também deve ter um token do tipo Bearer vindo do login

## 📫 Contribuindo
<!---Se o seu README for longo ou se você tiver algum processo ou etapas específicas que deseja que os contribuidores sigam, considere a criação de um arquivo CONTRIBUTING.md separado--->
Para contribuir, siga estas etapas:

1. Bifurque este repositório.
2. Crie um branch: `git checkout -b <nome_branch>`.
3. Faça suas alterações e confirme-as: `git commit -m '<mensagem_commit>'`
4. Envie para o branch original: `git push origin <nome_do_projeto> / <local>`
5. Crie a solicitação de pull.

Como alternativa, consulte a documentação do GitHub em [como criar uma solicitação pull](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/creating-a-pull-request).

## 🤝 Colaboradores

Agradecemos às seguintes pessoas que contribuíram para este projeto:

<table>
  <tr>
    <td align="center">
      <a href="#">
        <img src="https://avatars.githubusercontent.com/u/37117169" width="100px;" alt="Foto do Juliano Soares no GitHub"/><br>
        <sub>
          <b>Juliano Leonardo Soares</b>
        </sub>
      </a>
    </td>
  </tr>
</table>