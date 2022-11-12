![](redis.png)

## Rodando no Kubernets via helm

helm install redis --set auth.password=testeRedisMentoria123 --set replica.replicaCount=2 --set image.repository=redis --set image.tag=7.0.5 bitnami/redis


## Informações importantes

 * Significa **Re**mote **Di**ctionary **S**erver, database em memória.
 * Usado fortemente em fluxos de cache, com exigência de baixa latência.
 * Aceita vários tipos de dados, como JSON, TimeSeries, Grafos, Texto, Numéricos, Listas, Documents, etc
 * Não relacional - Schemaless
 * Trabalha com réplicas, tendo um nó principal (master)
 * Realiza persistência em disco de tempos em tempos para poder recuperar os dados para disaster recovery. Também tem um arquivo que grava todas as operações realizadas (similar a um log) continuamente em chamado AOF (append only file). Este segundo é mais seguro que o primeiro método de recuperação de dados mas pode apresentar maior latência. O ideal é de se usar um disco desacoplado do servidor (e.g. EBS AWS) para manter os dados gravados.
 * Salvar dados em memória RAM pode ser caro. Para isso podemos usar o REDIS flash, que armazena os dados menos acessados em um disco flash (SSD). Com isso podemos ter um PC com menos memória RAM disponível. No entanto esta disponível apenas para o REDIS enterprise.
 * As réplicas podem ser distribuidas (e é uma boa prática fazer isso) em servidores diferentes.
 * Possui mecanismo de Sharding, dividindo os conjuntos chave /valor em blocos que podem ser distribuidos pelas réplicas. 

| Vantagens  | Desvantagens  |
|---|---|
| Muito rápido  |  limitado a quantidade de memória ram da máquina |
| escalável horizontalmente com cluster  | Não suporta linguagens sql  |
| Muito utilizado com bastante suporte  | segurança fraca, apenas usuário e senha sem políticas de acesso  |
| Suporte nativo em várias clouds  | Roda em um único CPU |