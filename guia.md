
# Como criar o projeto?
dotnet new webapi --name Unirota.Example.Api -minimal

## tags
--name -> usada para definir o nome do projeto
-minimal -> criar projeto como uma minimal API (sem controller)

# Como executar o projeto pelo terminal? 
dotnet run -c Release

# Como instalo um pacote em uma aplicação .net? (similar ao NPM do node)
no .NET temos o gerenciador de pacotes NuGet. 
1. clicar com o botão direito em cima do proejto que deseja instalar o pacote.
2. clicar em 'Gerenciar Pacotes do NuGet'.
3. pesquisar pacote desejado.
4. instalar o pacote e escolher a versão.
5. o pacote já estará disponível para uso no projeto.


# O que são extension methods em c#? 
São uma forma de adicionarmos métodos ou funcionalidades à algum tipo (ou classe) já existente.
Geralmente são utilizados para configurar algo.

# O que é uma prop/propriedade em c#? 
É uma forma de encapsulamento de getters e setters de um atributo(POO), tornando desnecessário a criação de métodos para isso.

# Exclusão física vs Lógica
física -> o registro é removido da tabela, e apagado do banco de dados (similar a excluir um arquivo do seu computador).
lógica -> é utilizado um campo no banco de dados, ou algo similar, para que o registro não seja perdido.

# O que é o Entity Framework Core?
É um ORM similar ao mongoose, sequelize, prisma. Ele permite que você mapeie as entidades da sua aplicação e faça manipulações, sem precisar executar comandos SQL diretamente.

Após instalar o ORM, é necessário instalar a sua extensão que permitirá definir o banco que será utilizado.
Neste exemplo, usaremos SQLite, portanto iremos instalar o pacote EntityFrameworkCore.SQLite


# O que é o DbContext? 
O DbContext funciona como um "agrupador" das entidades da sua aplicação, é nele que você irá definir quais são as entidades que irão representar tabelas no banco de dados.
Ele também é responsável pela comunicação com o banco.

# O que é o DbSet? 
É uma representação de uma tabela em específico do seu banco, permitindo manipular a entidade.

# O que é uma migration?
Uma migration é uma forma de termos um histórico das alterações do nosso banco de dados, geralmente em sua nomenclatura irá possuir data e hora da criação da migration, e também o que foi alterado no banco.

# Como adicionar uma migration com entity-framework? 
instalar o pacote entityframework.Design;
executar o comando: dotnet ef migrations add nomeDaMigration

# Como executar uma migration? 
executar o comando dotnet ef database update

# Como remover uma migration? 
executar o comando dotnet ef migrations remove

# Como visualizar o banco de dados SQLite? 
Baixar a extensão Database Client - Weijan Chen no visual studio CODE
escolher o SQLite
escolher o arquivo SQLite que deseja abrir.

importante: NUNCA apagar dados da tabela __EFMigrationsHistory, pois irá quebrar o histórico de alterações.

# O que é um record em C#?
É um tipo imutável, utilizado para definir objetos de valor. (menos complexos do que classes)


# ciclo de vida de serviços em c#: 
## O que é Scoped?
a instancia é limitada a requisição, portanto uma nova instancia é criada para cada requisição.

## O que é Transient? 
é criada uma nova instância, sempre que o serviço é requisitado.

## O que é Singleton?
a instancia é a mesma durante todo o ciclo de vida da aplicação.

## qual a diferença entre Scoped vs Transient?
Scoped dura uma requisição inteira, enquanto Transient cria uma nova instância toda vez que é solicitado, independentemente da requisição.


# Por que preciso executar o SaveChanges? 
O entity framework funciona como transações, portanto a entidade do banco só é alterada no final.
podemos fazer uma analogia do SaveChanges com o commit das transações SQL.

# Quando executar o SaveChanges?
sempre que modificar/criar uma entidade.

# O que o SingleOrDefault faz? 
retorna o primeiro usuário que atende o parametro passado, e caso tenha mais de um, da erro.
