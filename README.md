# GameProject-Lab

1.	layered background (background /foreground)
  a.	Background is shown in the game scenes names: SampleScene, SampleScene2, SampleScene3. Background image is placed in the background. The player, dart, and balloon sprite images are placed in the foreground
2.	at least one image
  a.	Images used in the lab are background image, player image, balloon, and the dart image
3.	a player-controlled sprite
  a.	Player controlled sprite available in SampleScene, SampleScene2, and SampleScene3
4.	a balloon sprite with automatic movement
  a.	On each level, depending on the level there will be corresponding number of balloons for the player to pop. Each balloon is preset to move automatically in a horizontal motion from left to right repeatedly.
5.	the ability for the player to shoot pins at the enemy
  a.	Player sprite has a script that instantiates a dart GameObject once the player hits the left control key
6.	collision detection of pins, using tags so that a player does not pop himself with his own bullets
  a.	The balloon, player, and dart are tagged with its own unique tag so there will be no unexpected collisions between them. Program is set so that if the dart collides with the balloon, it’ll pop
7.	sound effect on collisions
  a.	Balloons have a pop sound once it hits the dart named popsound
8.	displayed score for player
  a.	On each level, there is a text object that displays the score of the player on the bottom left of the screen
9.	increasing size of balloon and impact on score
  a.	The balloons have a expand() function that incrementally increases the scale of the balloons. If the player does not pop the balloons in time, the balloon will pop and the level will be restarted. 
10.	at least three levels in increasing order of difficulty. Document the difficulty of each level in the directions.
  a.	There are three levels of difficulty in which the consequent level will have more balloons on the other. Furthermore, depending on the, the expansion rate will be different. 
11.	Fleeing algorithm implemented as one of the levels (balloon escapes player)
  a.	Not implemented
12.	scene transitions: Every time that your player pops the balloon, the game should transition to the next level. Every time the balloon gets too big and disappears, the current level should be restarted.
  a.	When player dart hits balloon, score, and darts update, and will be taken to the next level. Should the balloon pop, the level is loaded again and the score and dart count is loaded from the previous level;
13.	directions (include the basics of each level)
  a.	In instructions page, basic game mechanics are described as well as the difficulty of each level
14.	settings, including a volume setting with a slider
  a.	Available in the settings page. To get there click on settings button in menu page
15.	Menu
  a.	Menu has 4 buttons, instructions, settings, play, and high score. Furthermore, in the game stage, a menu panel is available should menu be clicked on
16.	pause/resume and link back to menu
  a.	Pause button in each of three stages. Once clicked, resume and menu are active and clickable. Click menu to open menu panel with warning and choice to proceed to menu or go back. Resume sets the prior two buttons inactive and resumes the game.
17.	some other UI (dropdown, toggle, input)
  a.	The other UI element is the panel used to warn the players when they click on menu
18.	a data item that persists from scene to scene
  a.	Score persists throughout the scenes
19.	a second data item that persists
  a.	The second data item are the dart count, counting the number of darts players use
20.	high scores (at least 5, presented in order)
  a.	Available through highscores button in menu page or by progressing the game and completing the third level
21.	animation #1
  a.	Idle animation included into the Player sprite where if there is no vertical or horizontal motion, it’ll run the idle animation
22.	animation #2
  a.	Run animation is added to the player sprite where if there is a vertical or horizontal movement, idle animation will transition to run animation. If there is no movement, run animation transitions to idle animation
23.	Extra credit: difficulty selection by player (with documentation about difficulty)
  a.	Difficulty available when clicking on play. Players will be prompted to choose a difficulty level when playing. The harder the stage, the slower the darts will move in the game
