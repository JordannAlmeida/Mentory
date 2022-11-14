![](prometheus.png)

## Rodando no Kubernets via [helm](https://github.com/prometheus-community/helm-charts)

## Separados:
add repo to helm:
```console
helm repo add prometheus-community https://prometheus-community.github.io/helm-charts
helm repo update
```

Apply kube-state-metrics:
```console
helm install [RELEASE_NAME] prometheus-community/kube-state-metrics [flags]
```
Apply prometheus node exporter:
```console
helm install [RELEASE_NAME] prometheus-community/prometheus-node-exporter
```

Apply prometheus postgress exporter:
```console
helm install [RELEASE_NAME] prometheus-community/prometheus-postgres-exporter
```

Apply prometheus redis exporter:
```console
helm install [RELEASE_NAME] prometheus-community/prometheus-redis-exporter
```

Apply prometheus alert manager:
```console
helm install [RELEASE_NAME] prometheus-community/alertmanager
```

Apply prometheus:
```console
helm install [RELEASE_NAME] prometheus-community/prometheus -f values.yaml -f service1-alert.yaml -f service2-alert.yaml
```
To see configurations of prometheus:
```console
helm show values prometheus-community/prometheus
```

Add helm [grafana](https://github.com/grafana/helm-charts/tree/main/charts/grafana)


## Helm com quase tudo que é necessário (sem exporters de postgres e redis):
```console
helm install [RELEASE_NAME] prometheus-community/kube-prometheus-stack
```


## Informações importantes

* Utilizado para o monitoramento de **unidades** de aplicacoes (Request Count, Request Duration, Exceptions Count) e hardware (CPU Status, Memory/Disk Space Usage);
* Utiliza uma base de dados organizada em TimeSeries (Storage), o qual organiza os dados por eventos ao longo do tempo;
* Possui alertas que podem ser configurados para disparar acoes;
* O Prometheus funciona de forma ativa (Retrival), ele que consulta as metricas nas aplicacoes (Pulls from HTTP endpoints) expostas na rota /metrics, em um formato definido que o prometheus entende, utilizando um **exporter** (muitos sao disponiveis como containers docker, existem node exporters para linux, bibliotecas para liguagens como Java, C#, etc);
* Possui uma interface HTTP que aceita querys (PromQl Query Language) para consultas dos dados salvos no storage;
* Possui uma WebUI propria, mas e comumente utilizadoo com o **Grafana**;
* Entradas das metricas sao organizadas em 2 atributos **Type** (Count: ...how many times x happened | Gauge: ...what`s the current value of <CPUUtilization, MemoryUtilization, Capacity Disk, etc> now | Histogram: ...how long or how big (e.g. resquest size) ) e **HELP** (descricao do que a metrica e)
* Sua configuracao e feita por um arquivo de configuracao prometheus.yaml, o qual dizemos quais sao os targets e qual o intervalo de busca das metricas;
* Os alertas (AlertManager) do prometheus podem disparar diversos tipos de acoes, como envio de email, mensagem no slack, etc. Suas regras sao declaradas no arquivo de configuracao do prometheus;


| Vantagens  | Desvantagens  |
|---|---|
| Confiavel  |  Dificil de escalar horizontalmente |
| Funciona sem a dependencia de outros componentes  | Possui um numero limitado de metricas  |
| Consegue trabalhar mesmo se outras partes da infraestrutura cairem  | A escolha do numero de metricas depende da capacidade do ambiente em que o prometheus esta rodando  |
| Nao e caro e e facil de se aplicar  |  |