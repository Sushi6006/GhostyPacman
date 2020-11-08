**The University of Melbourne**\
**COMP30019 – Graphics and Interaction**
<!-- omit in toc -->
# GHOSTY PACMAN - Group 33 Reimagined Potato

<div align="center">
    <p><b>We re-created Pac-Man in 3D.</b></p>
    <a href="https://youtu.be/c720pBMu_3k">
        <img src="https://img.youtube.com/vi/c720pBMu_3k/0.jpg">
        <p>Watch Game Trailer on YouTube Now</p>
    </a>
</div>

<!-- [![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/c720pBMu_3k/0.jpg)](https://youtu.be/c720pBMu_3k) -->
<!-- [Watch Game Trailer on YouTube](https://youtu.be/c720pBMu_3k).<br> -->

<br>

Pac-Man was originally developed and released in 1980 by the Japanese company, Namco (Puck Man). It became one of the most successful arcade games in history. Over the years, a lot of variations emerge from different places across the whole world. 40 years later, we, Reimagined Potato, decided to recreate the game, but in 3D. Upon this stage, we have created a working version of this game for both Windows and Mac; however, this is NOT our destination. Soonly enough, we will create VR version of this game and let the hard-core gamers to have the opportunity to enjoy the classic classic old but gold game.<br><br>

<div align="center"><b><i>Anyway. Enjoy!</i></b></div>

<br><br>


<!-- omit in toc -->
# GHOSTY PACMAN  README

<!-- omit in toc -->
## Table of contents
- [Team Members](#team-members)
- [Explanation of the Game](#explanation-of-the-game)
  - [How to Run](#how-to-run)
  - [How to Play](#how-to-play)
- [Technologies](#technologies)
- [How We Completed the Main Features](#how-we-completed-the-main-features)
  - [Menu & UI](#menu--ui)
  - [Shader](#shader)
    - [Toon Shader](#toon-shader)
    - [Transparent Shader](#transparent-shader)
  - [Player Control](#player-control)
    - [Pacman Control](#pacman-control)
    - [Camera](#camera)
  - [Ghosts (AI)](#ghosts-ai)
  - [Pacdot and Power-ups](#pacdot-and-power-ups)
  - [Map Creation](#map-creation)
- [Resources Used](#resources-used)
- [Evaluation](#evaluation)
  - [Observation Methods](#observation-methods)
    - [Think Aloud](#think-aloud)
    - [Post-task Walkthroughs](#post-task-walkthroughs)
    - [Developers' Conclusion from Observation Methods](#developers-conclusion-from-observation-methods)
  - [Query Techniques](#query-techniques)
  - [Changes Made](#changes-made)
- [Final Words from Team Reimagined Potato](#final-words-from-team-reimagined-potato)

<br><br>

## Team Members
<table>
  <tr>
    <th>Name</th>
    <th>Task</th>
  </tr>
  <tr>
    <td>Wei Ge<br><code>@gewg</code></td>
    <td>
      <li>Player Movements</li>
      <li>NPC Developments</li>
      <li>Game Mechanics
        <ul>
          <li>Eating pacdots and stuff</li>
          <li>Eating ghosts</li>
        </ul>
      </li>
    </td>
  <tr>
  <tr>
    <td>Leyan Lin<br><code>@Sushi6006</code></td>
    <td>
      <li>Music</li>
      <li>Sound Effects</li>
      <li>Map Creation</li>
      <li>Documentations</li>
    </td>
  <tr>
  <tr>
    <td>Xubin Zou<br><code>@NicKZ-gene</code></td>
    <td>
      <li>Menu</li>
      <li>Game UI</li>
      <li>Particle System</li>
      <li>Aesthetics</li>
    </td>
  <tr>
  <tr>
    <td>Chang Shen<br><code>@ChangShen0925</code></td>
    <td>
      <li>Map (first version)</li>
    </td>
  </tr>
</table>

<br><br>

## Explanation of the Game

### How to Run
1. Clone this repository with the command
   `git clone https://github.com/Graphics-and-Interaction-COMP30019/project-2-project2_group_33.git ReimaginedPotato`
2. Import the folder `ReimaginedPotato` as an Unity project in *Unity Hub*.
3. click da lil play button lah :relaxed:
4. If it does not work, the reason may be, according to our past experience, because of different platforms (i.e. Windows/macOS). `Reimport All` solves the problem.
5. If step 3 works, just `Reimport All` to avoid potential problems.

**OR**

Simply open the `GhostyPacman.exe` or `GhostyPacman.app` depending on your operating system and that should be working just fine.

<br><br>

### How to Play
**Goal:**\
Live, run away from ghosts (some are chasing you!), and eat as many pacdots as you can before you die (just like the original one).

**Game Mechanics:**\
However, there are stuff that work differently compared to the original Pac-man:
- Some ghosts will be permanently chasing you, some will completely ignore you.
- Pacdots respawn, after every period of time. So do the power-ups.
- Besides the power-dot (yellow) that allows you to eat Ghosts, we give another two powerups: *speed-up* (blue) that allows you to, as the name suggests, run really fast, and *shield* (green) that blocks one ghost attack.
- You will know when you can eat ghosts when there is red particals around you; you will know when it is safe to bump into a ghost when there is a translucent shield around you; and you can know you have a speed-up buff when you, obviously, run really fast.

**Controls:**\
In *Ghosty Pacman*, we have two control system:
- Default Pac-man WASD Control (DPWC for reference)
  - *DPWC* was inherited from the very original arcade Pac-man game, where you are always moving forwards and WASD keys are used to change the direction you are going towards.
- FP(but no shooting) WASD+Mouse Control (FPWC for reference)
  - *FPWC* was inspired by modern FPS games where WASD keys are used to move in the given direction and the direction of "forward" is controlled by the mouse. 

Players can use `C` to switch between two control systems. If you are not sure what mode you're in:
- If you are moving forward without pressing any keys, you are in DPWC, use WASD to change directions
- If you are stationary without pressing keys, you are in FPWC, use WASD to start moving

Also, the `V` key can be used to switch between third-person view and first-person view.

**One More Thing:**\
Press `ESC` to pause the game.

<br><br>
	
## Technologies
Project is created with:
- Unity 2019.4.8f1

Tools we have used:
- Windows 10 (Wei) / macOS Catalina (Others)
- Git/GitHub *(for version control and collaboration)*
- WeChat/Discord/Zoom *(for communications)*
- VS Code *(for writing C# code)*
- Photoshop *(for icons and buttons)*
- Bfxr *(for sound effects)*
- Bosca Ceoil *(for music)*
- ProBuilder & ProGrid in Unity *(for map creation)*
- Google/YouTube/StackOverflow/UnityDocumentation/UnityForum *(for learning)*
  - special thanks to: [Brackeys (YouTube)](https://www.youtube.com/user/Brackeys)

<br><br>

## How We Completed the Main Features

### Menu & UI
Unity Animator and Canvas (the UI GameObject) were used to create a fantastic UI for our game.

The animator was used to create the animations for all the buttons of three of our menus: main, pause and after-game. The script controls the functionalities and the animations of the buttons.

### Shader
#### Toon Shader
Because we have weak light elements in our game, we choose Toon shader, which is basically unaffected by light. Another reason is the Toon shader makes the object adorable, suitable with our Pacman theme.

Toon shader is generated by 4 parts: ambient + specular + rim: the ambient and specular is not impacted a lot by light, we can manipulate the size of specular, color of ambient manually. 

The directional light gives our shader a basic distinction between dark plane and light plane.

In ambient, we soften the edge between light and dark to remove the jaggedness, **smoothstep()** supports it. 

Specular part is very similar to the Phong shader in the lab, we also soften the specular spot's edge.

The "rim" of an object will be defined as surfaces that are facing away from the camera, we calculate the rim by taking the dot product of the normal and the view direction, and inverting it. 

#### Transparent Shader
Transparent shader is used for shields.

We designed a transparent shader with texture firstly, but we did not use the texture later, Texture parameter is kept in the shader.

We **turn off the depth writes(ZWrite)** to keep further object's rendering and turn on **Blending(Blend SrcAlpha OneMinusSrcAlpha)** for the transparent result.

We add ambient and diffuse in the shader to make our shield more powerful. 

The blending method makes better shield than the depth test method.

### Player Control
#### Pacman Control
We use CharacterController to control our characters, it will ignore the physical engine and bring smooth operation experience. We designed two control systems, the 'turn around effect' in classic mode is made for smooth reflection(really hard part). 

#### Camera
We design two versions of view, the first person and third person, with switching camera's position. The camera is set as pacman's child object to follow the pacman.
 
We add ray between camera and pacman to avoid the camera going through walls, the ray will detect the obstacle and zoom the camera.


### Ghosts (AI)
The chasing system on Ghost is finished by navigation in unity, every ghost is an agent.  At first, we have stairs in our map, so gravity calculation is added to the pacman though the stairs were removed at last. The ghost can float.

### Pacdot and Power-ups
The script not only makes all the pacdots and power-ups respawn after a certain amount of time, but also makes our object float instead of sticking to the ground.

### Map Creation
Our map was a complete copy from the original Pac-man with all the dimensions and scales re-calculated and adjusted. It was created using ProBuilder (Verified Version 4.2.3) and ProGrid (Preview Version 3.0.3). The map consists of only two objects: A "block" with all the walls and a "plane" for the floor. This is different to the first version of the map with hundreds if not thousands of small cubes. Putting all the walls in one game object makes the AI implementation much easier to do, fixing a bug we had where the chasing ghosts (AI) will wait for the player to stop moving to keep chasing.

<br><br>

## Resources Used
Menu was created along with this tutorial:\
[Make A Gorgeous Start Menu (Unity UI Tutorial)!](https://youtu.be/vqZjZ6yv1lA)

Map was created along with this tutorial:\
[MAKING YOUR FIRST LEVEL in Unity with ProBuilder!](https://youtu.be/YtzIXCKr8Wo)

<br><br>

## Evaluation
Field studies were taken after the very first minimum viable prototype was completed (when the trailer was made). Since we are creating a casual/arcade game for everyone to play when relaxing, *laboratory studies* were not suitable for us to investigate in our design. The method of field studies, therefore, were chosen.

We had 6 participants outside from our development team to play/test our game for us. While choosing our participants, we aimed to find people with distinct backgrounds including their gender, age and gaming experience. We believe that, by doing this, what we can conclude from these feedbacks could be extremely meaningful for our project as our game is going to be a casual/arcade game for everyone to play. However, due to the lack of time and resources, we were only able to find 6 participants, including our parents, families and friends.

For privacy purpose, we will use `Participants #[id]` to identify each of our participant. The following table includes the background/information of each participant.

| Participant ID | Age | Gender | Electronic Gaming Experience |
|:--------------:|:---:|:------:|:----------------- |
| 0 | 19 | Male   | Played a few (hyper-)casual games (e.g. Ketchapp/Supercell)
| 1 | 21 | Female | Plays a lot of mobile MOBA-games, played a few casual games
| 2 | 22 | Female | Sometimes play some PUBG or Honor of Kings on mobile phones
| 3 | 13 | Male   | Plays a lot of casual games on iPad
| 4 | 44 | Male   | Played a lot of computer casual/arcade games (e.g. BattleCity)
| 5 | 46 | Female | Barely played any games

*Note:* We have got consent from all our participants to use and share the information included in this report.

### Observation Methods
There were three options to choose from: *Think aloud*, *Cooperative evaluation*, and *Post-task walkthroughs*. We chose *Think aloud* and *Post-task walkthroughs* as our observation methods. We did not choose *Cooperative evaluation* because of how distracting this can be. Also, we figured that our game is simple enough to play and *Think aloud* is enough for the feedback we want; *Cooperative evaluation* can be an overkill with negative effects that come along.

Our implementation of the observation methods is:
1. Start a Zoom meeting with the participants and start recording with consents
2. Interview for their background (included in the table above)
3. Explain the methods we are going to experiment (either *Think aloud* or *Post-task walkthrough*)
4. Send the executable files to them (either `.app` for macOS or `.exe` for Windows)
5. Let them play and get feedback
6. Review the recordings and fill the details that were potentially missed in the previous step

For participants 0, 1 and 4, we used *Think Aloud* observation methods and for participants 2, 3 and 5 we chose *Post-task Walkthroughs*.

*Note:* The feedback recorded might not be direct words that came out from them. This is simply what we have concluded from their responses. However, we ensured that we did not alter the meaning of their sentences by double checking our concluded feedback with the corresponding participants.

#### Think Aloud
The reason why we have chosen this observation method is that it gives instant feedback on players' feelings towards a certain action or a specific scene of the game. Though some might say this method is distracting, we feel that the distraction level is totally fine for a casual game like ours after experiencing this observation method within our own team.

**Participant #0**
- Expects a "snake game" like control system, instead of WASD+Mouse
  - *given at the very start of the game*
- Thinks the pyramid is creative, innovative, but unnecessary
  - *about 30 seconds into the game*
- Finds the lighting system (day&night) weird and unnecessary
  - *after 3-4 minutes into the game*
- Finds the Ghosts not chasing (*Developers' Note:* because the AI was not working correctly as mentioned)
- Finds the map boring. "It is just sides of squares with a pyramid that gives you absolute safety."
  - *at the end*
- Really likes the sfx we have
  - *at the end*

**Participant #1**
- Finds pacdot eating sound too shrill (high-pitch)
  - *after she had about 15 pacdots*
- Still thinks the eating sound is good though, will be better if at a lower pitch
  - *about 45 seconds in*
- Thinks that a background music would be great (*Developers' Note:* we just have not put it in yet)
  - *about 1 minute into the game*
- Finds the Ghosts too creepy at night
  - *about 1 minute into the game*
- Finds that players can bug through the wall if pushing hard enough
  - *after 5 minutes into the game*
- Finds the control system too tiring where you have to hold keys to keep moving
  - *at the end*

**Participant #4**
- Likes the sfx a lot
  - *about 30 seconds into the game*
- Does not like the day & night lighting
  - *1 minute into the game*
- Ghost lighting visual bugs
  - *1 minute into the game*
- Thinks that the game is just too easy (*Developers' Note:* because the AI was not working correctly as mentioned)
  - *at the end*

#### Post-task Walkthroughs
We chose *post-task walkthroughs* as one of our observation methods because of the "undistracted session" our players can have. Though players might forget certain things they encounter and start to make up things that do not exist, we are still curious to see what feedback we can get with this post walkthroughts. It is also a good opportunity to see what differences we can get from two different observation methods.

**Participant #2**
- Does not like the day & night lighting because Ghosts are too creepy
- Does not like the map
- Thinks it is a nice boredom-killer

**Participant #3**
- Thinks the game is fun to play
- Finds the character hard to control

**Participant #5**
- Likes the pyramid
- Likes the sfx

#### Developers' Conclusion from Observation Methods
There was a clear difference between the quantity and quality of feedbacks given from *Think aloud* and *Post-task walkthroughs*. For *Post-task walkthroughs*, we even asked questions such as "What do you think about our player control system?" and the responses were pretty pointless. In future development, we as game developers will definitely emphasises more on the feedbacks from the method *Think aloud*. Also, for the *Think aloud* method, while rewatching the recordings, I found out that because we were busy noting their feedback, we barely gave reply to their feedback. This might discourage them from giving frequent or meaningful feedback in the latter part of testing and this is definitely something we should improve on.

Since our sample size was incredibly small, we have to value each feedback as important as the others even though they may only appeared once. 

We have summarised some key points from all the feedback we have got from *Observation Methods*:
- Player control system may be weird
- Day & Night lighting system is widely disliked
- Bugs need to be fixed (such as AI not working)
- Features need to be completed (such as background music)
- Sfx could be improved

<br><br>

### Query Techniques
We use SUS (System Usability Scale) as our query technique (which was shown in the lecture) for all our 6 participants. All members of our development team like this template a lot and think this is a good form for our game. The following are the questions we listed for our particpants (with scale of 1-5 for each):

(1: Strongly Disagree, 5: Strongly Agree)
1. I think that I would like to play this game frequently
2. I found this game unnecessarily complex
3. I thought the game was easy to use
4. I think I would need someone to teach me to be able to play this game
5. I found the controls and the game mechanics in this game were well integrated
6. I thought there was too much inconsistency in the game
7. I would imagine that most people would learn how to play this game very quickly
8. I found the game very cumbersome to use
9. I felt confident playing this game correctly
10. I needed to learn a lot of controls and game mechanicms before I could start play the game normally

We gave google forms for our participants to fill in, and the following table shows their responses:
| Participant ID | Q1 | Q2 | Q3 | Q4 | Q5 | Q6 | Q7 | Q8 | Q9 | Q10 | SU Score |
|:--------------:|:--:|:--:|:--:|:--:|:--:|:--:|:--:|:--:|:--:|:---:|:---------:|
| 0 | 5 | 1 | 5 | 1 | 3 | 1 | 5 | 1 | 5 | 1 | 95.0 |
| 1 | 2 | 1 | 5 | 1 | 5 | 1 | 5 | 1 | 5 | 2 | 90.0 |
| 2 | 4 | 1 | 4 | 1 | 5 | 1 | 5 | 1 | 5 | 1 | 95.0 |
| 3 | 5 | 1 | 5 | 1 | 5 | 1 | 5 | 1 | 5 | 2 | 97.5 |
| 4 | 2 | 1 | 5 | 1 | 5 | 1 | 5 | 1 | 5 | 1 | 92.5 |
| 5 | 3 | 1 | 3 | 1 | 4 | 1 | 3 | 1 | 4 | 4 | 72.5 |

Average SU Score = 90.41667

Our SU score is pretty high, meaning that our game is easy to play. This is a good indication that we are on the right track while designing different elements in our game. However, this data is not very meaningful for two reasons. The first one is that our sample size is extremely small with only 6 participants. The second reason is that all participants are our families and friends. Though we already asked them to not show any "mercy" while giving us feedback, it is still possible that they gave us scores thinking that their family/friend made this game so cannot be too harsh. 

We later had discussions with our participants on why they gave out some scores, the following are some meaningful responses (either for us to improve or to give reasons on why certain scores were given):
- "Not my type of game"/"Don't play games anymore"
- "Not used to the control system"
- "Gamemode is interesting"
- "FPS control on arcade games does not feel comfortable"

### Changes Made
Thanks to all the responses we get, we made some big improvements to our game. Here is a list of what we changed after the evaluation process:
- New control system (WASD only) is now added and users can choose whatever they want wheneven they want it. 
- Some sound effects are updated with lower pitch and volume. Background music is added
- Whole lighting mechanism was remade:
  - day & night effect is now gone
  - fixed ghost lighting visual bug
  - whole map is lit up
- Map was remade with respect to the original Pac-man.

<br><br>

## Final Words from Team Reimagined Potato
2020 has been a tough year for all of us, stucking at home getting mental issues. I, Sushi6006, would like to thank our subject coordinator and lecturer Dr. Jorge Goncalves for giving us this amazing opportunity bringing us together to complete this project. It has been a great semester having the opportunity to participate in this subject thanks to our lecturer' and tutors' hardwork. 

This was the first time developing a full size game for all of us and we all had an amazing time creating what only existed in our mind. Though it may still have bugs, poorly designed flaws, we are proud of what we have achieved and we definitely look forward to complete this game to an industry standard when the holiday is coming up. Great appreciation is to be given to Dr. Goncalves for his kindness giving us a 2-day extension to complete this project.

Lastly, we deeply hope that everyone can enjoy our (prototype) game. Stay safe, and take care!

Best regards,
Team Reimagined Potato