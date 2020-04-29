### Full name, email, and OIT account name for each member of the team

John Jajeh, [jjajeh3@gatech.edu](mailto:jjajeh3@gatech.edu), jjajeh3

Braden Chapman, [bchapman34@gatech.edu](mailto:bchapman34@gatech.edu), bchapman34

Sabrina Wilson, [sawilson@gatech.edu](mailto:sawilson@gatech.edu), swilson86

Jonathan Najjar, [jnajjar@gatech.edu](mailto:jnajjar@gatech.edu), jnajjar6

Mason Dominey, [mdominey3@gatech.edu](mailto:mdominey3@gatech.edu), mdominey3

### Any installation requirements procedures

Download or clone the repository.

Double click &quot;.exe&quot; or &quot;.app&quot; file.

### Gameplay instructions

_PC/MAC_

Move Up/Down/Left/Right – Arrows or WASD

Jump – Spacebar

Move Camera – Move mouse (inverted)

Throwing – First aim with Right Mouse Button and then throw with Left Mouse Button

Receiving hints from friendly NPC – Press &quot;Q&quot;

Pause – Press &quot;Esc&quot;

_PS4 controller_

Move Up/Down/Left/Right – Left Analog Stick

Jump – Square

Move Camera – Right Analog Stick

Throwing – First aim with L2 and then click with R2

Receiving hints from friendly NPC – Press triangle

### Meeting the Requirements

**3D Game Feel**

Our game is mapped in a 3D environment. We communicate success and failure to the player with a health bar and screen pop-ups. Our game includes a start menu and ability to reset after the game ends. Lastly, our game is not a first-person perspective game, and by using the camera, players can view the environment surrounding the character.

**Precursors to Fun Gameplay**

When the player starts our game, an instruction screen clearly identifies the main goal of the game, to get home alive, and the subgoals of finding the key and opening the gate. These goals are reinforced by the compass pickup object; when collected by the player, a target is displayed on screen directing the player to the next goal - the key, the gate, or the house. As the player navigates the environment to complete these goals, they are faced with choices that could lead to consequences or success. For example, monsters are near objects like the key, gate, and some pickups. To collect the item, the player must decide whether to throw rocks at the monster in order to stun it for a short time or try to run around and lead the monster away in order to go back for the object. If the player&#39;s strategy fails, they are attacked by the monster, losing one of three hearts. This requires the player to make another choice - whether to find an apple in order to restore one heart or whether to continue their task. However, if the player loses all three hearts, they die and must restart the game. This gives the player the ability to decide how much risk to take on, such as losing two of the three hearts in order to get the key while the monster is still around, while also providing the opportunity for great success if their risky strategy works out. Our game also allows the player different ways to meaningfully interact with the environment. The player can look for apples and compass objects hidden around the world, which animate when the player approaches, and can use the environment to escape the monsters, such as dodging through the trees. The player must also open the gate separating the environment in order to reach the house. The player can also ask friendly NPC animals in the forest for hints about what to do.

_ **3D Character/Vehicle with Real-Time Control** _

The player&#39;s controls are written in the script titled AJ input. Within this script, the code specifies how the input moves the character. The AJMovement script lays out how the animations are used with the player. Accordingly, this script handles the transitions for animation states. The player can also throw rocks. To throw a rock the player can press the aim button and a crosshair will come upon the HUD then the player can press the throw button to launch a rock.

The character&#39;s animations use two different layers, a base layer, and an upper layer. The upper layer contains an avatar mask that lets animations that affect the upper body of the character blend with the animations that occur in the character&#39;s lower body. At the base layer, there are two custom states, grounded locomotion blend tree, and jump\_fall\_land substate machine. Within the grounded locomotion blend tree there are 8 different animations. These animations are as follows: Happy Idle, Walking (forward), Walking (backward), Running, Left Strafe Walking, Right Strafe Walking, Left Strafe, Right Strafe. In the substate machine, the characters jumping animations are controlled depending on whether the character is jumping or grounded. In this state machine, the character can switch between a jump, falling idle, and landing animations. In the upper body Layer of the characters animator, the animations switch between aiming and launching/throwing. It is of note that all of the animations were found on mixamo.

The camera rig script allows the player to control the camera with either mouse or joysticks. Furthermore, the camera orbits around the player with these controls. This script also allows the player to switch the positioning of the camera in-game onto either shoulder of the character. The camera also checks if a wall is in the way of the camera and the player and repositions itself accordingly. Furthermore, if the camera is adjusted where it collides with the character&#39;s mesh the mesh will be made transparent to not obstruct the player&#39;s view.

**3D World with Physics and Spatial Simulations**

Using assets purchased from the Unity Asset Store, we created our own level for our character to explore. These assets include trees, flowers, mushrooms, walls, water, enemies, and friendly characters. We used these assets to create a dense forest area where the player can easily get lost, with hidden enemies and items that can help or hinder the player. We also included audio to indicate item pick-ups and interactions with enemies and the gate. There is minimal clipping through objects thanks to items having rigidbodies and colliders. Similarly, the walls and terrain have colliders to ensure the player cannot escape the world and infinitely fall. Some other environmental physical interactions include scripted interactions with the gate that only animates when the player has a key, simulated Newtonian physics rigidbody objects with the rocks the player can throw, animated objects using Mecanim with the player, enemies, and friendly NPCs, and destroyable objects with keys, compasses, and apples. Our environment is interactive and offers a 3D simulation with six degrees of freedom in all directions.

**Real-time NPC Steering Behaviors/Artificial Intelligence**

Our game has two different types of real-time NPC Steering Behaviors/AI. Both types of AI use third-party models and animations, but the scripts to control the control, steering, and decision making are all written by our team. The first type is the friendly squirrel that follows the player. The friendly squirrel has two states: following and idle. In the following state, the squirrel jumps as it follows the player around the map. Once the squirrel has reached the player, it stops moving and assumes the idle state where it &quot;eats.&quot; The second type of AI is the enemy that patrols. The enemy has four states: patrolling, chasing, attacking, and idle. The AI reasonably makes decisions of when to change states and animations. The animations are fairly fluid and provide visual feedback of the AI state.

**Polish**

Our game includes a start menu and pause menu, along with an intermediary instruction screen and a lose screen. We ensured that our program emerses the player such that it feels like a game from beginning to end. At any time, the player can pause and quit the game. In our game, there are no &quot;test-mode&quot; or &quot;god-mode&quot; key combinations. As such, the user experience is smooth and intuitive.

Our game includes numerous &quot;environment acknowledges player&quot; features, including: landscape animations (like swaying grass), proximity-based events (enemies will follow and attack if distance between the main character and enemy is small), and auditory representation of game events (e.g. picking up the key, eating the apple, etc.).

Regarding aesthetic, we focused on a cartoon/realistic style and maintained consistent dim lighting throughout the entire environment. We matched a somewhat eerie song to the emotions that the character (and player) should feel when playing the game. The enigmatic nature of the forest also adds to this emotional aspect to playing the game and not being able to predict what lies farther ahead.

Lastly, we thoroughly debugged our game such that there exists no game-related glitches. The player cannot get stuck and all barriers (edges of map) are obvious.

### Detail any deficiencies or known bugs

There are no known bugs. However, there may be a performance deficiency, depending on the computing power of the computer running the game.

### External resources used

Assets:

- [Simplistic Low Poly Nature from Acorn Bringer](https://assetstore.unity.com/packages/3d/environments/simplistic-low-poly-nature-93894)
- [True Horror - Crawler from Witch-A-Twin Studios](https://assetstore.unity.com/packages/3d/true-horror-crawler-70609)
- Aj from Mixamo for character avatar
- [3rd Person Controller + Fly Mode by Vinicius Marques for character animations](https://assetstore.unity.com/packages/templates/systems/3rd-person-controller-fly-mode-28647)
- [Antique Compass by Z3nder](https://assetstore.unity.com/packages/3d/props/antique-compass-86121)
- [AllSky Free - 10 Sky / Skybox Set by rpgwhitelock](https://assetstore.unity.com/packages/2d/textures-materials/sky/allsky-free-10-sky-skybox-set-146014)
- [Fantasy Forest Environment by TriForge Assets](https://assetstore.unity.com/packages/3d/environments/fantasy/fantasy-forest-environment-34245)
- [Simple Heart Health System by OArielG](https://assetstore.unity.com/packages/tools/gui/simple-heart-health-system-120676)
- [Handpainted Keys by RoboCG](https://assetstore.unity.com/packages/3d/handpainted-keys-42044)
- [Fence and Gate by Diana](https://assetstore.unity.com/packages/3d/environments/fence-and-gates-114135)
- [#NVJOB Water Shader by Nicholas Veselov](https://assetstore.unity.com/packages/vfx/shaders/nvjob-water-shader-149916)

Sounds:

- [Apple when eaten](https://youtu.be/1fR2espdrBo?t=3)
- [Gate opening](https://www.youtube.com/watch?v=foUyyBM2ins)
- [Enemy AI attacking](https://www.youtube.com/watch?v=rseuWBKIBP4)
- [Compass when picked up](https://www.youtube.com/watch?v=BbPexd00p34)
- [Background music](https://www.youtube.com/watch?v=lKeK_alwonk)
- [Footstep (Snow and Grass) by MGWSoundDesign](https://assetstore.unity.com/packages/audio/sound-fx/footstep-snow-and-grass-90678)

### Who did what

Mason Dominey – environment

Sabrina Wilson – animations, HUD, playtesting

Jonathan Najjar – character, playtesting

John Jajeh/Braden Chapman – AI, minor polish, music, playtesting

### What scene(s) to open in Unity

&quot;startScene&quot; – start screen

&quot;instructionScene&quot; – instruction screen

&quot;new3rdperson&quot; – main game