# ConsoleTetris
Just a bit of space to practice good manners and thoughtful coding... and fun, of course.

#### Some of the stuff I want to try here

##### 1. Solve the following using RX:
* Game engine clock with observable from interval (running main cycle on subscription to it) [X]
* Keyboard input buffered and read using a stream
* Pushing game-state to be renderd via a stream to the rendering component
* Check correct usage of schedulers (separate logic and UI refresh)

##### 2. Implement minimalistic physics (although not really needed for tetris)
* Make objects have both position and velocity (horizontal and vertical)
* Apply gravity (adjustable, to increase difficulty, making pieces fall faster)
* Collision detection

##### 3. Drawing on Console without moving the cursor [X]
&nbsp;
##### 4. Make the app run in a fullscreen Console programatically, avoiding the scroll bar as well [X]
&nbsp;
##### 5. Try to design the system with testability in mind, maybe try a bit of BDD with SpecFlow
&nbsp;
##### 6. Try to use F# to solve some simple stuff, and then move on to replace larger chunks to work in a fully functional way
&nbsp;
##### 7. Add sound support
&nbsp;
##### 8. Maybe fiddle with making it multiplayer over the internet (sounds like fun, haven't done MP logic before)
* Split screen with two tetris fields, increasing the gravity of the opponent when completing a row

##### 9. VoiP support?
&nbsp;
##### 10. AI for same MP gameplay against PC
* Try to make the PC learn to play using a neural network approach (see. Mario example online)
&nbsp;

##### 11. Retire
&nbsp;
## Current issues
~~Workin on making an API to correctly double buffered the console window, based on [this article](https://code.msdn.microsoft.com/windowsdesktop/C-Console-Double-Buffer-adc31032)
So far I can get a correct handle on the screen buffer, but blitting seems to be a bit off (as in not working at all)~~
