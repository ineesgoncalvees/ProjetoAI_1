# Primeiro projeto de Inteligência Artificial

## Projeto realizado por:
- Diana Nóia, a21703004
- Inês Gonçalves, a21702076
- Inês Nunes, a21702520

## Divisão de tarefas:

### Diana Nóia

- Relatório: Introdução (pesquisa), Metodologia, Resultados e discussão, Conclusão;
- Relatório: Figuras para ilustrar a Finite State Machine desenvolvida;
- Relatório: UML do projeto
- Iniciar código para input do utilizador do número de agentes;

### Inês Gonçalves

(Não colaborou mais devido à sobreposição de projetos, principalmente o
projeto 1 de LP2, o qual priorizou)

- Relatório: Introdução - Descrição do problema;
- Comentários XML;
- Ajudou com as transições entre estados;
- Ajudou a corrigir bugs no estados;

### Inês Nunes

- Layout do mapa do festival;
- Corrigir código para input do utilizador do número de agentes;
- Doxygen;

## Introdução

### Descrição do problema

Neste projeto foi-nos pedido que simulássemos um festival de música, onde 
existissem pelo menos dois palcos, uma zona de restauração, duas zonas de 
espaços verdes, saídas do recinto, e caminhos bem definidos entre as diferentes
zonas.
Este festival deve suportar no mínimo 100 agentes, sendo que cada um terá um 
comportamento autónomo.

Os agentes têm três comportamentos diferentes:

- Assistir aos concertos;
- Comer quando estão com fome;
- Descansar quando estão cansados;

O agente deverá decidir qual irá realizar conforme o seu estado atual, sendo que
esses estados são: com fome, cansado ou "normal", o qual será quando não está em
nenhum dos outros e vai assistir aos concertos.
Cada um destes estados tem depois um comportamento específico quando o agente
estiver na área designada como o seu destino.

Os agentes terão que respeitar os caminhos e evitar as paredes e os obstáculos,
sendo que podem andar um pouco fora dos caminhos caso seja necessário.

Nesta simulação foi-nos também pedido que o utilizador possa despoletar
explosões onde este escolher, sendo que os agentes vão ter que reagir de acordo
com esse acontecimento.

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

Para desenvolver este projeto, utilizámos a Navigation Mesh com A* para o
movimento e pathfinding dos agentes; para a designação das zonas onde os agentes
têm de ir utilizámos tags para cada tipo de elemento (uma tag para Agents, uma
tag para Stages, etc.), e uma FSM para a mudança de estados (comportamentos) dos
agentes.

### Pesquisa

O comportamento coletivo mais comum em situações de pânico em multidões é a fuga
descontrolada, que acontece de forma extremamente desorganizada, e é também
apelidada de debandada. Acontece normalmente em situações onde existe ameaça de
morte, como em incêndios, tiroteios ou explosões, entre outros.

Quando eventos deste género acontecem são extremamente trágicos, pois costumam
levar à morte de pessoas, que são esmagadas pela multidão. É, contudo, uma
situação ainda bastante rara, mas a frequência tem infelizmente vindo a
aumentar, devido ao aumento da densidade populacional bem como ao fácil acesso
a meios de transporte. Estes dois fatores fazem com que haja maior facilidade em
ir a eventos públicos como concertos, eventos desportivos, etc. [1]

Existem poucas teorias quantitativas capazes de prever as dinâmicas de uma
multidão humana, logo simulações do comportamento humano, com agentes,em
situações deste género podem ser extremamente útil para observar e prever
situações de pânico, e utilizar estes resultados para arranjar estratégias para
evacuar espaços durante estas crises com o menor número possível de problemas.

A área de pesquisa que usa a simulação com agentes chama-se _Agent-Based_
_Social_ _Simulation_ (ABSS) [2], e intersecta três campos cientificos:

- Computção Baseada em Agentes : maioritariamente dentro da ciência da computação, e
  inclui, por exemplo, _agent-based_ _modelling_, _design_, e _programming_;
- Ciências Sociais: um grande conjunto de diferentes campos científicos, que
  estudam a interação entre entidades sociais, por exemplo, psicologia social,
  gestão, várias áreas da biologia,etc.;
- Simulação Computacional: estuda diferentes técnicas para simular fenómenos num
  computador. O fenómeno simulado pode ser um evento ou sequência de eventos
  num sistema natural ou artificial (ou uma combinação de ambos) que podem
  existir ou não enquanto a simulação está a decorrer;

Assim, pode-se resumir que a ABSS investiga o uso de tecnologia de agentes para
simular fenómenos sociais num computador e providencia modelos e ferramentas
para isso, de forma a aplicar em diferentes áreas. A contribuição da Computação
Baseada em Agentes no campo da Simulação Computacional, dentro desta área é um
novo paradigma para a simulação de sistemas complexos com muita interação entre
as entidades do sistema. Simulações deste tipo são técnicas de simulação micro,
que tentam replicar explicitamente comportamentos de individuos especificos.

Isto pode ser contrastado com técnicas de simulação macro, que são tipicamente
baseadas em modelos matemáticos onde as caracteristicas de uma população são
tidas em conta, e o modelo tenta simular mudanças neste conjunto de
características para toda a população simulada. Ou seja, em simulações macro,
o conjunto de individuos é visto como uma estrutura, podendo ser caracterizada
por um número de variáveis, enquanto que em simulações micro a estrutura é vista
como emergente  das interações entre os individuos. [3]

Para o caso desta simulação, um dos problemas colocados foi arranjar maneira
dos agentes se deslocarem por caminhos certos, para áreas especificas do mapa.
Isto é chamado de Pathfinding [4]. Falando de forma geral, PathFinding é o
processo de determinar um conjunto de movimentos para um objecto de uma posição
para outra, sem colidir com nenhum obstáculo no seu caminho.
Este é um problema fundamental da maioria dos jogos.

Neste caso especifico, é necessário fazer também uma pesquisa acerca de
Multi-Agent Pathfinding (MAPF), que é o problema em encontrar caminhos para
múltiplos agentes, de forma a que cada agente atinja o seu objetivo e que os
agentes não colidam. O interesse acerca deste processo tem vindo a crescer
nestes últimos anos na comunidade de pesquisa de Inteligência Artificial,
parcialmente devido a aplicações no mundo real, como em gestão de armazéns,
gestão de aviões, etc. [5]

Devido ao aumento da complexidade dos jogos atuais, as soluções antiigas têm
sido tornadas obsoletas. O algoritmo A*, que é um algoritmo clássico, já não é
suficiente para resolver este problema. É necessário utilizar a Navigation Mesh,
que utiliza o A* duma forma mais avançada [4]. Esta é uma técnica que representa
o mundo através de polígonos convexos, e é simples e altamente eficiente a
representar ambientes 3D.

## Metodologia

Na nossa solução do projeto, a simulação foi implementada em 3D com movimento
Dinâmico. Para o movimento e pathfinding dos agentes, implementámos uma
Navigation Mesh, que é uma malha de polígonos convexos bidimensionais que
definem quais as áreas de um ambiente os agentes podem passar.

A busca de caminhos num destes polígonos pode ser feita numa linha reta, porque
o polígono é convexo e podem passar pelo mesmo. A busca de caminhos entre
polígonos na malha é ser feita com o algoritmo de pesquisa A *, que é usado
pela sua eficiência de optimização, mas tem a desvantagem do uso de espaço, pois
guarda todos os nodes gerados na memória. Existem algoritmos que pré-processam o
gráfico para obter melhor performance, mas A* continua a ser a melhor solução em
muitos casos, como nesta solução.Os valores que estão parametrizáveis no nosso
projeto são:

- A fome do agente;
- A velocidade do agente;
- A energia do agente;
- O número de agentes instanciados;

Os agentes terão diferentes estados, nomeadamente

- Assistir aos concertos (watch concerts);
- Comer quando estão com fome (Eating);
- Descansar quando estão cansados (Resting);
- Entrar em pânico se estiver no raio 2 ou 3 duma explosão (Panic);
- Morrer se estiver no raio 1 duma explosão (Dead);

Utilizámos uma Finite State Machine para a mudança de estados dos agentes;

<p align="center">
  <img src="https://imgur.com/gczH92k" alt="FSM"/>
</p>

Definimos as seguintes classes:

-
-
-


## Resultados e discussão

Após implementar a nossa solução para o nosso problema,

Os aspectos mais interessantes foram... (encontramos algum comportamento 
emergente?(comportamento não explicitamente programado nos agentes))

Interpretar os resultados observados, realçar correlações entre estes e
parametrizações definidas, resultados inesperados com hipótese explicativas

## Conclusões

relacionar introdução (problema apresentado) com resultados
explicar como a nossa abordagem  se relaciona no panorama geral da pesquisa efetuada sobre simulação de pânico em multidões

## Agradecimentos

Agradecemos ao nosso colega Pedro Inácio, que nos deu a sugestão de usar um array de agentes;

Agradecemos ao nosso colega Flávio Santos, que nos deu a sugestão de usar uma lista para os agentes;

Agradecemos ao professor Nuno Fachada, por proporcionar o código no qual nos baseamos para fazer
os statess e as transitions

## Referências

Código fornecido em aula de Inteligência Artificial;

[1]: [Helbing D., Farkas I.J., Vicsek T. (2002) Crowd Disasters and Simulation of Panic Situations. In: The Science of Disasters. Springer, Berlin, Heidelber](https://link.springer.com/chapter/10.1007/978-3-642-56257-0_11)

[2]: [Helbing, D., Farkas, J., Vicsek, T.(2000). Simulating dynamical features of escape panic](https://www.nature.com/articles/35035023)

[3]: [Davidsson, P. (2002). Agent Based Social Simulation: A Computer Science View](http://jasss.soc.surrey.ac.uk/5/1/7.html)

[4]: [Cui, X., Shi, H. (2012). An Overview of Pathfinding in Navigation Mesh](https://pdfs.semanticscholar.org/fc76/604df1d9fb50d3a2b3e69d9caba214262798.pdf)

[5]: [Stern, R. (2019). Multi-Agent Path Finding – An Overview](https://link.springer.com/chapter/10.1007/978-3-030-33274-7_6)
