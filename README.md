# Tower

Repositório: [GitHub - Tower](https://github.com/CrCardd/Tower/tree/newFeatureTemp)  
Autor: [**@CrCardd**](https://github.com/CrCardd)  
Tecnologia: **C#**  
Versão: **v0.1.1**  

### Descrição
                O objetivo do Tower é ganhar tempo quando trabalhamos com arquitetura 
        limpa, permitindo uma configuração um tanto quanto primitiva da organização 
        das pastas, no entanto personalizável. 
        
                Esse projeto foi desenvolvido devido à repetição de tarefas ao trabalhar 
        com Arquitetura Limpa, a mesma configuração de arquivos feita repetidas vezes 
        resulta em um processo cansativo, portanto aqui temos comandos que facilitam o 
        desenvolvimento.
        
    O projeto conta com:

    - Iniciar um novo projeto.
    - Configuração de dependências.
    - Referências a outras camadas.
    - Inicialização de novas entidades com seus devidos arquivos.
    - Criação de features/usecases

### Detalhes
                Para modificar o comportamento do projetos é necessário editar o código fonte. 
        Dentro da pasta 'Layers' podemos encontrar a configuração de cada camada, 
        organização de pastas e criação de novas entidades, a construção da estrutura foi 
        feita de modo que é facilmente editável, embora um pouco complexo é possível compreender 
        seu funcionamento. Temos a classe IArchive, portanto tanto pastas quanto arquivos 
        herdam de tal, e podemos organizar a estrutura de pastas por conta disso.

        Para alterar as dependências de uma camada, editamos dentro do método 'Packages()' e 
        adicionamos: 
        
        Install("reference_project")


        Para alterar as referências de uma camada, editamos dentro do método 'References()' e 
        adicionamos:
        
        RefencesTo("reference_project")

        Após a configuração de estrutura, dependências e referências dentro do arquivo da 
        camada, prosseguimos conforme o exemplo:

        var ExampleLayer = new Layer("project_name")
        ExampleLayer.CreateLayer() 
        ExampleLayer.CreateReferences() 
        ExampleLayer.InstallPackages()
 


### Começar novo projeto

> **Tower** new cleanWA <name>  

exemplo:  
> **Tower** new cleanWA TowerAPI

#### * Se não for especififcado o nome, o projeto será iniciado na pasta atual

---
### Criar nova entidade (IRepository, Model, Controller)
> **Tower** new e | entity <name>  

exemplo:  
> **Tower** new e User        


---
### Criar novas features/usecases
> **Tower** new f | feature <entity_associated> <feature_name>  

exemplo:

> **Tower** new f User Auth


### Opções: 
> -f <feature_folder_name> (default: <entity_associated>_)  

exemplo:  
> **Tower** new f User Auth -f UserFeatures

 
---
! Implementação futura: !
- C++
- Controle de camadas
- Configurações personalizadas
- Usuário dev com personalização de comandos e criação de novos arquivos
---