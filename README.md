**The University of Melbourne**\
**COMP30019 – Graphics and Interaction**
<!-- omit in toc -->
# GHOSTY PACMAN - Group 33 Reimagined Potato
We re-created Pac-Man in 3D. [Watch Game Trailer on YouTube](https://youtu.be/c720pBMu_3k).<br>
[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/c720pBMu_3k/0.jpg)](https://youtu.be/c720pBMu_3k)
<br>

Pac-Man was originally developed and released in 1980 by the Japanese company, Namco (Puck Man). It became one of the most successful arcade games in history. Over the years, a lot of variations emerge from different places across the whole world. 40 years later, we, Reimagined Potato, decided to recreate the game, but in 3D. Upon this stage, we have created a working version of this game for both Windows and Mac; however, this is NOT our destination. Soonly enough, we will create VR version of this game and let the hard-core gamers to have the opportunity to enjoy the classic classic old but gold game.<br><br>
***Anyway. Enjoy.***
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
- [Resources Used](#resources-used)
- [Evaluation](#evaluation)
  - [Observation Methods](#observation-methods)
    - [Think Aloud](#think-aloud)
    - [Post-task Walkthroughs](#post-task-walkthroughs)
  - [Query Techniques](#query-techniques)

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
3. click da lil play button lah
4. If it does not work, the reason may be, according to our past experience, because of different platforms (i.e. Windows/macOS). `Reimport All` solves the problem.

**OR**

Simply open the `GhostyPacman.exe` or `GhostyPacman.app` depending on your operating system and that should be working just fine.

<br><br>

### How to Play

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
There were three options to choose from: *Think aloud*, *Cooperative evaluation*, and *Post-task walkthroughs*. We chose *Think aloud* and *Post-task walkthroughs* as our observation methods. We did not choose *Cooperative evaluation* because of how distracting this can be. Also, we figured that our game is simple enough to play and *Think aloud* is enough for the feedback we want; *Cooperative evaluation* can be an over-kill with negative effects that comes along.

Our implementation of the observation methods is:
1. Start a Zoom meeting with the participants and start recording with consents
2. Interview for their background (included in the table above)
3. Explain the methods we are going to experiment (either *Think aloud* or *Post-task walkthrough*)
4. Send the executable files to them (either `.app` for macOS or `.exe` for Windows)
5. Let them play and get feedback
6. Review the recordings and fill the details that were potentially missed in the previous step

For participants 0, 1 and 4, we used *Think Aloud* observation methods and for participants 2, 3 and 5 we chose *Post-task Walkthroughs*.

*Note:* The feedback recorded might not be direct words that came out from them. This is simply what we have concluded from their responses. However, we ensured that we did not alter the meaning of their sentences by double checking our concluded feedbacks with the corresponding participants.

#### Think Aloud
The reason why we have chosen this observation method is that it gives instant feedbacks on players' feelings towards a certain action or a specific scene of the game. Though some might say this method is distracting, we feel that the destraction level is totally fine for a casual game like ours after experience this observation method within our own team.

**Participant #0**

**Participant #1**

**Participant #4**


#### Post-task Walkthroughs
We chose *post-task walkthroughs* as one of our observation methods because of the "undistracted session" our players can have. Though players might forget on certain things they encounter and start to make up things that do not exits, we are still curious to see what feedback can we back with this post walkthroughts. It is also a good opportunity to see what 


**Participant #2**

**Participant #3**

**Participant #5**



### Query Techniques
*one of these for p2*
- Think Aloud
  - Different control methods then were added
- Post-task walkthroughs

- adding control systems
- changing the sound
- removing the day-night effect