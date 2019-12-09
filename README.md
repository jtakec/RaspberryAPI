# RaspberryAPI

RaspberryAPI é um Serviço Web REST/API desenvolvido em .NET Core 3.0 para configurar e testar os pinos GPIO do Raspberry PI 3 ou superior.
Este serviço é apenas para uso em treinamento e experimentação com implementação de algumas funções básicas.
Além de utilizar o framework .NET Core 3.0, utiliza o pacote Nuget Unosquare que possui as APIs para acesso às funções do raspberry PI.

A solução está divida em três projetos:
   RaspberryAPI.csproj - Serviço Web REST/API para ser executado no Raspberry PI de preferência no Sistema Operacional Raspbian 
   RaspberryLibrary.csproj - Biblioteca de objetos e funções compartilhadas
   RaspberryTesterClient.csproj - programa de teste das funcionalidades básicas do raspberry PI, consome os Serviços do RaspberryAPI.                                       Pode rodar no próprio Raspberry PI ou no seu computador pessoal.  
                                  Configure o arquivo app.json que possui o endereço HTTP para acesso ao Raspberry PI.

# Providências para utilização do programa

1) No Raspberry PI instalar o framework .NET Core 3.0 ou superior.

2) Abrir a solução do RaspberryAPI usando o Visual Studio 2019:

     - Selecione o projeto RaspberryAPI.csproj e publique (clicar o botão direito do mouse em cima de Publicar/Publish)
     - Copie os arquivos publicados em C:\RaspberryAPI\ para o Raspberry PI.
     - No terminal do Raspberry PI, entre na pasta do programa e execute ./RaspberryAPI para executar o serviço.       

     - Selecione o projeto RaspberryTesterClient.csproj e publique
     - Edite o arquivo app.json com o endereço HTTP correto para acesso ao RaspberryAPI e copie para a pasta 
       c:\RespberryAPI\RaspberryTesterClient, onde está o executável do testador do serviço web REST/API.
     - Execute o testador c:\RespberryAPI\RaspberryTesterClient\RaspberryTesterClient.exe   
   
