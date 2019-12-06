# Primeiro projeto de Inteligência Artificial

## Projeto realizado por:
- Diana Nóia, a21703004
- Inês Gonçalves, a21702076
- Inês Nunes, a21702520

## Divisão de tarefas:
### Diana Nóia
- efewf

### Inês Gonçalves
- fefrg

### Inês Nunes
- wegrht

## Introdução

### Descrição do problema

Neste projeto foi-nos pedido que simulassemos um festival de música onde existisse
pelo menos dois palcos, uma zona de restaurção, duas zonas de espaços verdes,
saídas do recinto, sendo que estas serão valores parametrizáveis, e caminhos bem
definidos entre as diferentes zonas.
Este festival tinha que suportar no mínimo 100 agentes, sendo que cada um terá
um comportamento autónomo.

Os agentes têm três comportamentos diferentes:
- Assistir aos concertos;
- Comer;
- Descansar.

O agente irá decidir qual irá realizar conforme o seu estado atual, sendo que
esses estados são: com fome, cansado ou "normal", que será quando não está em
nenhum dos outros e no qual vai assistir aos concertos.
Cada um destes estados tem depois um comportamento específico quando o agente estiver na area designada como seu destino.

Os agentes terão que respeitar os caminhos e evitar as paredes e os obstáculos, sendo que podem andar um pouco fora dos caminhos caso seja necessário.

Nesta simulação foi-nos também pedido que quem estiver a controlá-la possa
depoletar explosões onde este escolher, sendo que os agentes vão ter que reagir de acordo com esse acontecimento.

As reações pretendidas são:
- Os agentes que se encontrarem no raio principal da explosão serão eliminados;
- Os que se estiverem no raio secundário ficarão paralisados nos primeiros
segundos, sendo que quando se voltarem a puder mover andarão apenas a metade
da sua velocidade normal.
- Existe ainda um raio terciário no qual os agentes entrarão num estado de
pânico no qual irão fugir na direção oposta à explosão e em direção da saída.
Os agentes fora deste raio serão também afetados se um agente próximo deles
entrar em pânico.
Os agentes nestes estado andarão também ao dobro da sua velocidade normal.


## Metodologia

## Resultados e discussão

## Conclusões

## Agradecimentos

## Referências