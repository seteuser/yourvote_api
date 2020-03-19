# yourvote_api

lucasluizss@live.com 
William Moreira de Souza <william.m.souza@live.com> 

Repositórios:
http://brilhamuito.apphb.com/
https://trello.com/b/wQ96siWz/apibrilhamuito

https://bitbucket.org/lucasluizss/yourvote/src/master/
https://bitbucket.org/wmoreirasouza/
https://bitbucket.org/wmoreirasouza/api.brilhamuito/src/master/


Breve descrição do projeto mobile e suas peculiaridades
*Opcional: Desenvolvimento de aplicação crossplataform nativa para solução na tomada de decisões em comissões realizadas pela igreja.*
 
Tecnologias que você tem usado no seu projeto:
    • React Native – Framework JS do Facebook para desenvolvimento de App’s nativos;
    • Android Studio – Para a execução do emulador Android;
    • Expo XDE – Emula a aplicação em qualquer device;
    • Bitbucket (Git) – Guardar as versões do código fonte do App (Posteriormente podemos migrar o código para o Github e deixar aberto);
    • Postman – Realizar testes rápidos com as requisições disponíveis na API consumida;
    • Chrome / Debugger / LocalStorage;
    • API Rest com Mongo DB hospedada com infraestrutura AWS;
    • Para o código: JavaScript ES6, Node, JSX, Babel etc...
    • *Avaliando a aplicação de uma biblioteca visual (React Native Paper) após a parte funcional.
 
Descrição:
    • Desenvolvimento ágil de aplicações crossplataform utilizando JavaScript em conjunto com um conhecido framework do Facebook o React, para suprir uma necessidade encontrada na tomada de decisões quanto à escolha de membros durante uma votação em comissões da igreja, que hoje é realizada presencialmente com uma alta demanda de tempo e disponibilidade de todas as partes envolvidas.
    • Em termos técnicos, poder proporcionar um ganho de performance, usabilidade e tudo o que um App nativo pode oferecer em dispositivos mobiles utilizando apenas de um código fonte (o que pode também incluir códigos nativos quando preciso) com aproveitamento de múltiplas plataformas para uso e múltiplos componentes, permitindo o desenvolvimento ágil e maiores entregas. Consumindo uma API Rest disponível em nuvem e utilizada para o tratamento de dados salvos em uma base de dados não relacional, mas orientada à documentos, onde serão guardadas todas as informações pertinentes à utilização da aplicação.
 
Objetivos/Desafios:
    • Desenvolvimento de uma aplicação crossplataform com apenas um código consumindo uma API e proporcionando integrações contínuas.
    • No começo a compreensão da documentação disponibilizada teve seu grau médio de dificuldade, mas a cada etapa o avanço era perceptível era iminente.
    • Talvez o maior desafia tenha sido na estilização da aplicação (levando em consideração que tenho mais convivência para o desenvolvimento back-end) e nas definições de layout.
    • O alinhamento das funcionalidades e a comunicação indireta com o cliente final da aplicação trouxe algumas dificuldades na modelagem das funcionalidades e do desenvolvimento da aplicação.
    • Compreensão do framework como um todo para o avanço durante os erros encontrados e para o material no início ainda ser escasso por conta da tecnologia ainda estar em seu começo.
    • Seguir com o desenvolvimento de uma aplicação sem antes ter tido um preparo prévio para enfrentar os desafios vistos, sendo guiado pela documentação e ocorrências similares em sites de desenvolvimento.
 
Resultados/Vantagens/
    • Os resultados de funcionamento foram os esperados e visíveis em questão de performance e usabilidade, penando apenas para o quesito visual que necessita ser melhorado.
    • Agilidade no desenvolvimento e alinhamento com as funcionalidades da API consumida, facilidade de encontrar problemas através das ferramentas disponibilizadas para o desenvolvimento da aplicação que geralmente já são conhecidas por desenvolvedores e facilidade na compreensão dos códigos escritos. A utilização de ferramentas simples para integrações contínuas e testes da aplicação em qualquer dispositivo utilizando EXPO como emulador com apenas um link para abrir a aplicação.
    • Se algum desenvolvedor que tenda para o desenvolvimento web e por necessidade ou iniciativa própria queira desenvolver uma aplicação nativa para dispositivos mobile, a ferramenta ideal seria o framework do Facebook, React Native juntamente com todos os recursos que ele disponibiliza. 
 
 
PS:*Se eu puder contribuir com alguma informação a mais estarei com total disponibilidade.*




Aplicação RESTful para o gerenciamento na tomada de decisões de comissões internas em igrejas (Proposta de tema final)
Descrição:
    • Há hoje um problema visto como desafio onde a deslocação e agrupamento de membros da IASD para solução de possíveis problemas internos se torna algo inviável de se realizar presencialmente. Visto o problema e em alinhamento com integrantes da liderança parte da solução se dá na construção de uma API (Application Programming Interface) para o gerenciamento de dados relacionados a tomadas de decisões em comissões da igreja, em auxílio da agilidade no desenvolvimento quanto às necessidades encontradas.
    • As tecnologias e ferramentas utilizadas em questão são:
        ◦ Visual Studio, para a criação e definição da arquitetura da solução desenvolvida com C# (C Sharp) juntamente com .Net framework 4.5.
        ◦ Swagger como ferramenta no auxílio da estrutura da solução para ecossistemas escaláveis e contribuição para consumir serviços RESTful.
        ◦ Aplicação de alguns tipos de design patterns na arquitetura da solução, incluindo abstração de classes e funcionalidades acopladas em modelos de estruturação.
        ◦ AppHarbor como ferramenta de hospedagem da solução, uma plataforma baseada em AWS (Amazon Web Services) para soluções SAAS, contribuindo com um deploy simples baseado em GIT com ferramentas úteis de logs do sistema e facilidades em realizações de testes.
        ◦ Utilizando o MLab um serviço DBAAS(Banco de dados em nuvem) como base de dados o mongoDB como solução para gerenciamento de dados, uma base de dados não relacional orientada à coleção de documentos, utilizando o software RoboMongo como SGBD.
        ◦ Postman para realização de testes, e verificação dos end-points da aplicação.
        ◦ Bitbucket para armazenar o código da solução, inicialmente um repositório privado para desenvolvimento e análises dos contribuidores (revisores).
        ◦ Testes automatizados utilizando NUnit, Mock e o Jmeter para testes de carga e verificação de end-points.
        ◦ Injeção de dependência (Dependency Injection) é um padrão de desenvolvimento de programas de computadores utilizado quando é necessário manter baixo o nível de acoplamento entre diferentes módulos de um sistema.


Objetivos/Desafios:
    • Os objetivos para o desenvolvimento da solução se atribuem na entrega e resolução de problemas quanto necessidade por parte do cliente. Durante o desenvolvimento não houve total disponibilidade para levantamento de requisitos como um todo do sistema, ocasionando algumas defasagens nos módulos existentes necessitando a melhoria dos mesmos.
    • Como principal desafio identificado, a definição dos componentes de software e de arquitetura tornando possível um estudo aprofundado no desenvolvimento ágil de soluções RESTful totalmente escaláveis. Há também o alinhamento com a solução visual para o cliente onde se acentuou a falta de esclarecimento nas especificações.

Resultados/Vantagens:
    • Como esperado a solução entrega os módulos básicos do que foi requerido incialmente possibilitando a expansão continuamente rápida e proporcionando eficiência em seu desenvolvimento e utilização, tanto para o desenvolvedor quanto para o usuário final.
    • Uma das principais vantagens de se utilizar uma aplicação RESTful se da na possibilidade das diversas interfaces possíveis para usabilidade por parte do cliente, não se limitando apenas a um tipo de aplicação.

Problemas enfrentados:
    • Durante o desenvolvimento da solução houve algumas questões pendentes para a resolução que teve indução direta de profissionais com mais experiência em arquiteturas de softwares auxiliando a modelagem como um todo. Após toda a definição, o desenvolvimento pôde fluir com mais rapidez em uma construção de um sistema totalmente modular e escalável.



Segue a Url hospedado no appharbor, configurado e funcionando o swagger!
http://brilhamuito.apphb.com/
Nele você pode testar requisições PUT,GET,DELETE e POST.
Se precisar de qualquer alteração, por favor me avise.

Estou tentando configurar essa url na qual comprei o domínio na kinghost.
http://www.api.brilhamuito.swagger

A dois erros:
1 - Mal configuração do IIES
2 - KingHost precisa liberar o IP para acessar o mongoDb no mLab(provedor do mongoDb). 
lucasluizss@live.com 
William Moreira de Souza <william.m.souza@live.com> 

Repositórios:
http://brilhamuito.apphb.com/
https://trello.com/b/wQ96siWz/apibrilhamuito

https://bitbucket.org/lucasluizss/yourvote/src/master/
https://bitbucket.org/wmoreirasouza/
https://bitbucket.org/wmoreirasouza/api.brilhamuito/src/master/


Breve descrição do projeto mobile e suas peculiaridades
*Opcional: Desenvolvimento de aplicação crossplataform nativa para solução na tomada de decisões em comissões realizadas pela igreja.*
 
Tecnologias que você tem usado no seu projeto:
    • React Native – Framework JS do Facebook para desenvolvimento de App’s nativos;
    • Android Studio – Para a execução do emulador Android;
    • Expo XDE – Emula a aplicação em qualquer device;
    • Bitbucket (Git) – Guardar as versões do código fonte do App (Posteriormente podemos migrar o código para o Github e deixar aberto);
    • Postman – Realizar testes rápidos com as requisições disponíveis na API consumida;
    • Chrome / Debugger / LocalStorage;
    • API Rest com Mongo DB hospedada com infraestrutura AWS;
    • Para o código: JavaScript ES6, Node, JSX, Babel etc...
    • *Avaliando a aplicação de uma biblioteca visual (React Native Paper) após a parte funcional.
 
Descrição:
    • Desenvolvimento ágil de aplicações crossplataform utilizando JavaScript em conjunto com um conhecido framework do Facebook o React, para suprir uma necessidade encontrada na tomada de decisões quanto à escolha de membros durante uma votação em comissões da igreja, que hoje é realizada presencialmente com uma alta demanda de tempo e disponibilidade de todas as partes envolvidas.
    • Em termos técnicos, poder proporcionar um ganho de performance, usabilidade e tudo o que um App nativo pode oferecer em dispositivos mobiles utilizando apenas de um código fonte (o que pode também incluir códigos nativos quando preciso) com aproveitamento de múltiplas plataformas para uso e múltiplos componentes, permitindo o desenvolvimento ágil e maiores entregas. Consumindo uma API Rest disponível em nuvem e utilizada para o tratamento de dados salvos em uma base de dados não relacional, mas orientada à documentos, onde serão guardadas todas as informações pertinentes à utilização da aplicação.
 
Objetivos/Desafios:
    • Desenvolvimento de uma aplicação crossplataform com apenas um código consumindo uma API e proporcionando integrações contínuas.
    • No começo a compreensão da documentação disponibilizada teve seu grau médio de dificuldade, mas a cada etapa o avanço era perceptível era iminente.
    • Talvez o maior desafia tenha sido na estilização da aplicação (levando em consideração que tenho mais convivência para o desenvolvimento back-end) e nas definições de layout.
    • O alinhamento das funcionalidades e a comunicação indireta com o cliente final da aplicação trouxe algumas dificuldades na modelagem das funcionalidades e do desenvolvimento da aplicação.
    • Compreensão do framework como um todo para o avanço durante os erros encontrados e para o material no início ainda ser escasso por conta da tecnologia ainda estar em seu começo.
    • Seguir com o desenvolvimento de uma aplicação sem antes ter tido um preparo prévio para enfrentar os desafios vistos, sendo guiado pela documentação e ocorrências similares em sites de desenvolvimento.
 
Resultados/Vantagens/
    • Os resultados de funcionamento foram os esperados e visíveis em questão de performance e usabilidade, penando apenas para o quesito visual que necessita ser melhorado.
    • Agilidade no desenvolvimento e alinhamento com as funcionalidades da API consumida, facilidade de encontrar problemas através das ferramentas disponibilizadas para o desenvolvimento da aplicação que geralmente já são conhecidas por desenvolvedores e facilidade na compreensão dos códigos escritos. A utilização de ferramentas simples para integrações contínuas e testes da aplicação em qualquer dispositivo utilizando EXPO como emulador com apenas um link para abrir a aplicação.
    • Se algum desenvolvedor que tenda para o desenvolvimento web e por necessidade ou iniciativa própria queira desenvolver uma aplicação nativa para dispositivos mobile, a ferramenta ideal seria o framework do Facebook, React Native juntamente com todos os recursos que ele disponibiliza. 
 
 
PS:*Se eu puder contribuir com alguma informação a mais estarei com total disponibilidade.*




Aplicação RESTful para o gerenciamento na tomada de decisões de comissões internas em igrejas (Proposta de tema final)
Descrição:
    • Há hoje um problema visto como desafio onde a deslocação e agrupamento de membros da IASD para solução de possíveis problemas internos se torna algo inviável de se realizar presencialmente. Visto o problema e em alinhamento com integrantes da liderança parte da solução se dá na construção de uma API (Application Programming Interface) para o gerenciamento de dados relacionados a tomadas de decisões em comissões da igreja, em auxílio da agilidade no desenvolvimento quanto às necessidades encontradas.
    • As tecnologias e ferramentas utilizadas em questão são:
        ◦ Visual Studio, para a criação e definição da arquitetura da solução desenvolvida com C# (C Sharp) juntamente com .Net framework 4.5.
        ◦ Swagger como ferramenta no auxílio da estrutura da solução para ecossistemas escaláveis e contribuição para consumir serviços RESTful.
        ◦ Aplicação de alguns tipos de design patterns na arquitetura da solução, incluindo abstração de classes e funcionalidades acopladas em modelos de estruturação.
        ◦ AppHarbor como ferramenta de hospedagem da solução, uma plataforma baseada em AWS (Amazon Web Services) para soluções SAAS, contribuindo com um deploy simples baseado em GIT com ferramentas úteis de logs do sistema e facilidades em realizações de testes.
        ◦ Utilizando o MLab um serviço DBAAS(Banco de dados em nuvem) como base de dados o mongoDB como solução para gerenciamento de dados, uma base de dados não relacional orientada à coleção de documentos, utilizando o software RoboMongo como SGBD.
        ◦ Postman para realização de testes, e verificação dos end-points da aplicação.
        ◦ Bitbucket para armazenar o código da solução, inicialmente um repositório privado para desenvolvimento e análises dos contribuidores (revisores).
        ◦ Testes automatizados utilizando NUnit, Mock e o Jmeter para testes de carga e verificação de end-points.
        ◦ Injeção de dependência (Dependency Injection) é um padrão de desenvolvimento de programas de computadores utilizado quando é necessário manter baixo o nível de acoplamento entre diferentes módulos de um sistema.


Objetivos/Desafios:
    • Os objetivos para o desenvolvimento da solução se atribuem na entrega e resolução de problemas quanto necessidade por parte do cliente. Durante o desenvolvimento não houve total disponibilidade para levantamento de requisitos como um todo do sistema, ocasionando algumas defasagens nos módulos existentes necessitando a melhoria dos mesmos.
    • Como principal desafio identificado, a definição dos componentes de software e de arquitetura tornando possível um estudo aprofundado no desenvolvimento ágil de soluções RESTful totalmente escaláveis. Há também o alinhamento com a solução visual para o cliente onde se acentuou a falta de esclarecimento nas especificações.

Resultados/Vantagens:
    • Como esperado a solução entrega os módulos básicos do que foi requerido incialmente possibilitando a expansão continuamente rápida e proporcionando eficiência em seu desenvolvimento e utilização, tanto para o desenvolvedor quanto para o usuário final.
    • Uma das principais vantagens de se utilizar uma aplicação RESTful se da na possibilidade das diversas interfaces possíveis para usabilidade por parte do cliente, não se limitando apenas a um tipo de aplicação.

Problemas enfrentados:
    • Durante o desenvolvimento da solução houve algumas questões pendentes para a resolução que teve indução direta de profissionais com mais experiência em arquiteturas de softwares auxiliando a modelagem como um todo. Após toda a definição, o desenvolvimento pôde fluir com mais rapidez em uma construção de um sistema totalmente modular e escalável.



Segue a Url hospedado no appharbor, configurado e funcionando o swagger!
http://brilhamuito.apphb.com/
Nele você pode testar requisições PUT,GET,DELETE e POST.
Se precisar de qualquer alteração, por favor me avise.

Estou tentando configurar essa url na qual comprei o domínio na kinghost.
http://www.api.brilhamuito.swagger

Existem dois erros:
1 - Má configuração do IIES
2 - KingHost precisa liberar o IP para acessar o mongoDb no mLab(provedor do mongoDb). 

