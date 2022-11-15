![](elastic.png)

## Informações importantes

* ElasticSearch é uma ferramenta distribuida, escalável, baseada em buscas de json e dados analíticos. Comumente o ES é usado na stack ELK (Elasticsearch, logstash, kibana, Beats).
* Kibana é uma ferramenta de visualização dos dados do Elasticsearch (similar ao grafana com o prometheus).
* Logstash serve para receber, formatar e enviar os dados para o padrao esperado pelo Elasticsearch, de diferentes tipos de fontes de dados. Tambem temos o Fluentd que funciona de forma similar.
* O ElasticSearch e praticamente um banco de dados voltado a documentos. Ele tambem e rapido e escalavel, possuindo uma api REST para consultas e manipulacao dos dados.
* Beats e usado como pequenos agentes bem leves, que podem ser colocados em servidores de forma a coletar informacoes (Logs, metricas, Network data, Audit Data, Uptime Monitoring) e enviar para o ElasticSearch/Logstash.

## Como iremos utilizar

Vamos coletar os dados da nossa aplicacao com o Serilog utilizando a stack EK (elasticsearch e kibana). Poderiamos ter por exemplo o logstash para intermediar a comunicacao da nossa aplicacao com o Elasticsearch. Entretanto temos o pacote **Serilog.Sinks.Elasticsearch** que consegue colocar nosso log no formato adequado que o elasticsearch espera. Artigo base para a implementacao em nossa aplicacao .NET: https://renatogroffe.medium.com/net-5-serilog-implementando-logs-com-elasticsearch-sqlite-45d64f5c043e