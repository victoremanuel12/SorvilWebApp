# SorvilWebApp
<h2>Resumo da aplicação</h2>
</br>
 Aplicação C# MVC que incorpora os princípios do Padrão de Arquitetura MVC (Model-View-Controller) para criar uma plataforma abrangente que oferece uma experiência de gerenciamento de livros de alta qualidade. Nesta aplicação, integrei vários conceitos e tecnologias para fornecer uma solução completa para os amantes de livros.
<h3>Padrões e tecnologias utilizadas:</h3>
</br>
Padrão MVC: A arquitetura MVC divide a aplicação em três componentes interconectados: o Modelo, que representa os dados e a lógica de negócios, a Visão, que cuida da interface do usuário e o Controlador, que gerencia as solicitações do usuário e coordena as interações entre o Modelo e a Visão. Essa estrutura proporciona uma separação clara de responsabilidades, tornando o código mais organizado e fácil de manter.

DTO (Data Transfer Object): Utilizei DTOs para transferência de dados entre as camadas da aplicação. Isso ajuda a otimizar o desempenho e a reduzir o acoplamento entre as camadas, garantindo que apenas os dados necessários sejam transmitidos.

Padrões de Projetos Repository e Unit of Work: Implementei os padrões Repository e Unit of Work para facilitar o acesso e a manipulação de dados no banco de dados SQL Server. Esses padrões oferecem uma abstração eficaz sobre a camada de persistência, tornando o código mais limpo e flexível.

Razor Pages: Utilizei o Razor Pages para criar uma interface do usuário intuitiva e responsiva, permitindo que os usuários interajam de forma eficaz com a aplicação.

Consumo da API do Google Books: Integrei a API do Google Books para fornecer informações detalhadas sobre livros, como título, autor e capa. Isso enriquece a experiência do usuário e permite que os usuários encontrem facilmente livros de seu interesse.

Relacionamento de Tabelas no SQL Server: Projetei o banco de dados SQL Server para permitir o relacionamento entre os usuários e os livros que eles adicionam à sua prateleira, marcando-os como lidos, não lidos ou desejados.

Área de Configurações: Implementei uma área de configurações que permite aos usuários redefinir seu e-mail, senha e adicionar uma foto ao seu perfil. Isso oferece flexibilidade e personalização aos usuários.

Entity Framework Core: Utilizei o Entity Framework Core como meu O/RM (Mapeador Relacional de Objeto) para mapear os objetos do aplicativo para as tabelas do banco de dados. Isso facilita o desenvolvimento e a manutenção, permitindo que os desenvolvedores trabalhem com objetos em vez de escrever consultas SQL diretamente.

Code First: Adotei a abordagem Code First, permitindo que o modelo de banco de dados seja definido por meio de código C# em vez de criar o banco de dados manualmente. Isso promove a escalabilidade e a evolução contínua do aplicativo.
</br>
<h3>Objetivos alcançados:</h3>
<b>No geral, minha aplicação C# MVC é uma solução robusta para o gerenciamento de livros que incorpora as melhores práticas de desenvolvimento, proporcionando uma experiência aprimorada para os entusiastas da leitura. Ela une tecnologia moderna e uma abordagem centrada no usuário para criar um ambiente onde os amantes de livros podem explorar, organizar e compartilhar suas paixões literárias de maneira eficaz e personalizada.</b>
