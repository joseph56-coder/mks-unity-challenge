Diretrizes do desafio
---------------

O objetivo principal desse teste é avaliar suas habilidades em POO (Programação orientada a objetos) juntamente com o Unity. Ao terminar, faça o deploy da aplicação (web) e mande-nos o link.

Tarefa (funcional)
---------------

Para esse desafio, você deve desenvolver um **Top-Down Shooter** sobre piratas. Você deve baixar os assets do projeto: [Assets Pirate Game](https://mks-sistemas.nyc3.digitaloceanspaces.com/kenney_piratepack.zip).

1. O game será composto por: <b>Player</b>, <b>Inimigos</b> e <b>Obstáculos</b>.
2. A sessão de cada partida deve durar entre <b>1</b> a <b>3</b> minutos.
3. Ao fim de cada partida, a tela final deve mostrar a pontuação total do jogador e duas escolhas: <b>"Jogar novamente"</b> e <b>"Menu principal"</b>.
4. A barra de vida do <b>Player</b> e dos inimigos devem ser exibidos em cima de seus respectivos barcos.
5. O barco do <b>Player</b> não pode deixar a tela.

<b>Player</b>
--------------

O player deve destruir outros barcos e sobreviver até a sessão do game acabar.

<b>Movimentação</b>

      1. Anda para a frente
      2. Rotaciona

<b>Ataque</b>

       1. Tiro único frontal
       2. Tiro triplo lateral (balas paralelas)
	   
	   
	   
<b>Inimigos</b>
--------------

Existem <b>dois</b> tipos de inimigos, o <b>Chaser</b> e o <b>Shooter</b>. As diferenças deles serão listadas na sessão <b>Ataque</b>.

<b>Movimentação</b>

      1. Anda para a frente
      2. Rotaciona

<b>Ataque</b>

      1. O "Shooter" vai atirar no Player quando chegar perto dele.
      2. O "Chaser" vai perseguir o Player para tentar acertá-lo com o próprio barco. Ele deve explodir quando acertar o Player.
	   
	   
<b>Obstáculos</b>
--------------

Uma ou mais ilhas que parem o player e os barcos inimigos.

<b>Animações</b>
--------------

1. Explosão nos disparos.
2. Explosão na hora da morte.
3. Deterioração dos barcos de acordo com sua vida.

<b>Menu Principal</b>
--------------

1. No menu principal, haverá duas opções: <b>"Jogar"</b> e <b>"Configurações"</b>.
2. Dentro do menu de configurações, haverá duas opções: <b>"Duração da partida"</b> e <b>"Tempo de spawn dos inimigos"</b>.

<b>Recursos</b>
--------------

Download dos assets: [Pirate Game Assets](https://mks-sistemas.nyc3.digitaloceanspaces.com/kenney_piratepack.zip). Sinta-se livre para usar qualquer asset externo que deseje.

<b>Aspectos técnicos</b>
--------------

Todo o código deve ser escritos pelo candidato, enquanto aos assets, estes podem ser de qualquer autor.


Entrega
---------------

Ao finalizar, faça o deploy (web) no lugar que te for confortável e mande-nos o link, juntamente com o link do repositório.
