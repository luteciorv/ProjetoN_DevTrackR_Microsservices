# Projeto N - Mini curso de Microsserviços

### Descrição
        * A ideia do projeto era acompanhar a playlist de vídeos do Luis Dev https://www.youtube.com/playlist?list=PLI2XdbZhEq4l-nnF4bfzsUBnnZXTtcV1D sobre microsserviços
        * Eu não finalizei ela, pois o último vídeo trata de filas Rabbit e eu não estou tão familiarizado ainda com isso
        * O projeto utiliza o banco de dados MongoDb, que eu utilizei uma imagem no Docker para rodar no localhost 27017
        * A deste projeto é um serviço de envio de pedidos, onde é possível adicionar, resgatar um pedido e resgatar todos os 
        serviços possíveis de serem utilizados nos pedidos

### Organização do Projeto
        - Camada de apresentação
                . DevTrackR.ShippingOrders.API

        - Camada de Aplicação
                . DevTrackR.ShippingOrders.Application

        - Camada de Infraestrutura
                . DevTrackR.ShippingOrders.Persistence

        - Camada Core
                . DevTrackR.ShippingOrders.Core

### Implementações
        - Conexão com o banco de dados MongoDb (Docker)
        - InputModel e ViewModels (DTOs)
        - Mapeamento manual através dos DTOs
        - Entidades ricas (value objects e comportamento)

### Telas do Projeto
	* Swagger
![](Images/swagger-endpoint.png?raw=true)

	* Solução
![](Images/solution.png?raw=true)