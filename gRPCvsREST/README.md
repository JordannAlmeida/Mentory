## Comparativo entre gRPC e REST em um ambiente simulado de microserviços encadeados.

Imagine o seguinte cenário: Temos um conjunto de 2 microserviços, 1 relacionado a pagamentos e outro relacionado a conferência de fraude, sendo que o primeiro sempre chama o segundo para validar os pagamentos, como pode ser visto abaixo:

<p align="center">
  <img src="assets/imageMD/architectural_diagram.png" alt="Sublime's custom image"/>
</p>

Sendo assim, iremos coletar metricas relacionadas a uma comunicação HTTP comum do tipo REST e também de uma comnunicação HTTP utilizando gRPC, entre os serviços, na medida em que usuários simulados utilizam chamam nosso sistema.


Para iniciar os serviços feitos em dotnet, basta rodar o comando:

```
docker-compose up -d
```

# Geração do código do teste de carga

Iremos utilizar o [K6](https://k6.io/), e o código contido na pasta 'src/loadTest' para rodar o teste de carga foi gerando a partir da ferramenta [GPT chat](https://chat.openai.com/chat), utilizando a instrução

```
Create a load test using k6 lib and node.js. Rules:
- it should last 60 seconds;
- it'll simulate 100 users by endpoint;
- it'll test two endpoints, 'https://localhost:8082/payment/creditCard' and 'https://localhost:8082/payment/creditCardRPC'
- The body to be sent from both requests are {\"creditCardNumber\":\"string\",\"creditCardAmoun\":0.0,\"validate\":\"2022-12-17T13:56:50.078Z\",\"cvv\":\"string\",\"latitude\":0.0,\"longitude\":0.0,\"nameOwner\":\"string\",\"codeBank\":\"string\",\"paymentDate\":\"2022-12-17T13:56:50.078Z\",\"creditCardLimit\":0};
- Bouth endpoints are POST methods;
- it must count the sum of the times spent by all the requests, for each endpoint, during the test;
- Finally it'll show on console the result of sums times of each endpoint, in table format, and compare who was fastter;

Show me the comand to execute the load test
```

Para rodar o teste usar o comando:
```
npm run test
```