![](prometheus.png)

## Rodando no Kubernets via helm


## Informações importantes

* Utilizado para o monitoramento de **unidades** de aplicacoes (Request Count, Request Duration, Exceptions Count) e hardware (CPU Status, Memory/Disk Space Usage);
* Utiliza uma base de dados organizada em TimeSeries (Storage), o qual organiza os dados por eventos ao longo do tempo;
* Possui alertas que podem ser configurados para disparar acoes;
* O Prometheus funciona de forma ativa (Retrival), ele que consulta as metricas nas aplicacoes (Pulls from HTTP endpoints) expostas na rota /metrics, em um formato definido que o prometheus entende, utilizando um **exporter** (muitos sao disponiveis como containers docker, existem node exporters para linux, bibliotecas para liguagens como Java, C#, etc);
* Possui uma interface HTTP que aceita querys (PromQl Query Language) para consultas dos dados salvos no storage;
* Possui uma WebUI propria, mas e comumente utilizadoo com o **Grafana**;
* Entradas das metricas sao organizadas em 2 atributos **Type** (Count: ...how many times x happened | Gauge: ...what`s the current value of <CPUUtilization, MemoryUtilization, Capacity Disk, etc> now | Histogram: ...how long or how big (e.g. resquest size) ) e **HELP** (descricao do que a metrica e)
* Sua configuracao e feita por um arquivo de configuracao prometheus.yaml, o qual dizemos quais sao os targets e qual o intervalo de busca das metricas;
* Os alertas do prometheus podem disparar diversos tipos de acoes, como envio de email, mensagem no slack, etc. Suas regras sao declaradas no arquivo de configuracao do prometheus;


| Vantagens  | Desvantagens  |
|---|---|
| Confiavel  |  Dificil de escalar horizontalmente |
| Funciona sem a dependencia de outros componentes  | Possui um numero limitado de metricas  |
| Consegue trabalhar mesmo se outras partes da infraestrutura cairem  | A escolha do numero de metricas depende da capacidade do ambiente em que o prometheus esta rodando  |
| Nao e caro e e facil de se aplicar  |  |