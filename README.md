# Tower of Babel
Este proyecto tiene como base [este otro](https://github.com/yeagob/Super2DProject) de mi profesor. Originalmente el juego muestra a un astronauta ascendiendo por una cueva, representando el camino del GameDev.  
El enunciado es simple: Acabar el juego y **hacerlo tuyo**.


## Cambios y adiciones

### Gameplay
- Se han añadido cinco niveles.
- El nivel actual se muestra en la UI, encima de la altura.
- Al pasar de nivel se activa un nuevo Ground a modo de check point.
- Se ha añadido luz dinámica.

### Player y Jetpack
- El Player camina (animación + físicas).
- El Player siempre mira hacia donde se desplaza.
- El Jetpack deja un rastro de partículas cuando vuela.
    - Justificación: Me parece más coherente con la narrativa, ya que lo que mueve al Player es su fe.
- El Jetpack se regenera al estar sobre una superficie.
- Ya no se mueve por ``AddForce``, ahora se usa ``.velocity``.
    - Justificación: Considero que acumular fuerzas continuamente puede llevar a perder el control y que la fuerza horizontal quede demasiado minimizada. Este nuevo método me pareció más fiable.

### Código
- Los elementos Player, Jetpack e InputController utilizan un sistema de eventos.
    - Justificación: Pienso que es una opción más limpia y ordenada. Me parece especialmente eficaz a la hora de gestionar inputs.
Pero, cuando la relación acción-reacción es más bien directa (como los efectos de los items), este sistema no ha sido establecido.
 
### Estética
- Se ha cambiado por completo el arte y la [narrativa](#Narrativa).
- La apariencia, partículas y sonido de los items ha sido modificada por completo. 
- Se ha cambiado la música y añadido al menú principal.


## Assets
### Sprites
Player - [3 Direction NPC Characters](https://assetstore.unity.com/packages/2d/characters/3-direction-npc-characters-205182)  

Tilemap + Props + Items - [Dungeon Tale - Fantasy RPG Sprites FX Tileset](https://assetstore.unity.com/packages/2d/environments/dungeon-tale-fantasy-rpg-sprites-fx-tileset-296458)  

### Audio
Música MainMenu - [C-Greg-rocks.aif](https://freesound.org/people/ducksingel/sounds/274265/)  

Música InGame - [spiritual journey around the world](https://freesound.org/people/memnosis/sounds/503254/)  

Partículas Scroll1 - [Geben macht mehr glücklich als nehmen.mp3](https://freesound.org/people/Roses1401/sounds/619591/)  

Partículas Scroll2 - [Credo.wav](https://freesound.org/people/cormi/sounds/113653/)  

Partículas Hammer - [bell.wav](https://freesound.org/people/craigmaloney/sounds/370507/)

## Narrativa

### La Torre de Babel original
La historia de la Torre de Babel se relata en el libro del Génesis.  
  
Los pocos supervivientes del diluvio universal se juntaron en la ciudad de Babilonia (en hebreo, Babel). Movidos por su fe, quisieron construir una torre tan alta que llegara hasta el cielo, y así empezó la construcción de la Torre de Babel.  
  
Pero su dios, Yahweh, tenía otros planes para los humanos. Así que esparce los diferentes idiomas entre ellos, impidiendo que se comuniquen y consiguiendo la suspensión de su objetivo, así como del levantamiento de la Torre de Babel.  
  
De ahí el origen de los idiomas y del esparcimiento de la humanidad por la Tierra.  
  
### La Torre de Babel en el universo del juego
Cada partida del juego es un intento de Nimrod de alcanzar lo más alto de la torre, movido por su fe. En su camino se encontrará con **pergaminos escritos** en lenguas que no conoce que dificultarán su ascenso. También hallará **martillos** que le ayudarán a seguir subiendo.  
  
En contraposición con el relato original, existe la posibilidad de alcanzar el cielo, ganando el juego.


---
