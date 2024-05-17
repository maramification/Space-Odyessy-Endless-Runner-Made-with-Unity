# README

## Go Go Power Rangers Game

### Overview
This project is a mini-game developed as part of the Advanced Computer Lab course at the German University in Cairo. The game is an endless runner inspired by the popular Power Rangers series, similar to Subway Surfers. The primary goal is to test and enhance game development skills using Unity and C#.

### Project Objective
The main aim of this mini-project is to test the ability to develop the core parts of a video game that can be deployed on both desktop and mobile (bonus) platforms. In this project, a simple game based on the Power Rangers series is created. The game is an endless runner similar to Subway Surfers.

### Gameplay Overview
- **Player Control**: A sphere moving forward automatically on an infinite floor divided into three lanes.
- **Objective**: Avoid obstacles while collecting different orbs to switch forms and use powers. The goal is to achieve the highest score before the game ends.

### Rules of Play

#### Movement
- **Perspective**: Third-person view behind the sphere.
- **Automatic Forward Movement**: The sphere moves forward automatically.
- **Steering**: The player can steer left and right to change lanes, either continuously or discretely. The player cannot exit the three lanes while steering.
- **Speed**: Consistent across devices, not too fast or too slow.

#### Item Generation
- **Automatic and Random Generation**: Orbs and obstacles are generated automatically and randomly across three lanes throughout the game.
- **Orb Types**: Red, green, and blue orbs can be collected.
- **Obstacles**: Fully occupy one lane and must be avoided.
- **Lane Occupancy**: Each lane can either be empty or occupied by one game item generated in its center. Multiple horizontal lines of items are visible in front of the player at all times.
- **Object Pooling**: All game objects are pooled or discarded after they are no longer needed to avoid memory leaks.

#### Energy & Score
- **Energy Points**: Three types - red, green, and blue. Initial value is zero, maximum value is five.
- **Score Counter**: Initially set to zero. Collecting an orb normally increases both the score and the corresponding energy points by one.

#### Switching Forms
- **Initial Form**: Normal form (white).
- **Switching Criteria**: Switch forms when the energy points of a particular color are at their maximum value (five points) by pressing “J”, “K”, and “L” for red, green, and blue forms respectively. Switching consumes one point of the corresponding energy.
- **Form Benefits**: Collecting an orb of the same color as the current form increases the score by two points, while energy points are unaffected.

#### Powers
- **Activation**: Powers can only be used in their corresponding forms by pressing “Space Bar”, consuming one point of the corresponding energy.

##### Red Power (Nuke)
- **Effect**: Eliminates all obstacles ahead. Obstacle generation continues normally after activation.

##### Green Power (Multiplier)
- **Effect**: The next orb collected provides five times the score and double the energy points. The multiplier is deactivated after collecting one orb or switching forms.

##### Blue Power (Shield)
- **Effect**: A shield surrounds the player, protecting from one obstacle hit. The shield is deactivated after hitting one obstacle or switching forms.

#### Obstacle Damage
- **Form Reversion**: Hitting an obstacle in colored form reverts the player to normal form.
- **Game Over**: Hitting an obstacle in normal form ends the game.

### Game Controls

#### Windows
- **Movement**: Left/Right arrow keys or "A"/"D".
- **Switch Forms**: "J", "K", "L".
- **Activate Power**: "Space Bar".
- **Pause/Resume**: "Escape".

#### Android (Optional)
- **Movement**: Swipe to move left/right.
- **Switch Forms**: Buttons on the left side of the screen.
- **Activate Power**: Button on the right side of the screen.
- **Pause**: Button on the top of the screen.

### Screens & UI

#### Title Screen
- **Options**:
  - How to Play
  - Credits
  - Mute Sound
- **Play**
- **Quit**

#### Gameplay HUD
- **Energy Points**: Red, green, and blue.
- **Score Counter**

#### Pause Menu
- **Resume**
- **Restart**
- **Main Menu**

#### Game Over Screen
- **Final Score**
- **Restart**
- **Main Menu**

### Sounds

#### Sound Effects/Feedback
- Collecting orbs
- Switching forms
- Using powers
- Hitting obstacles
- Invalid actions

#### Soundtracks
- Slow-paced for title, pause, game over screens.
- Exciting for gameplay.

### Cheats (Optional)

#### Windows Only
- **Invincibility**: Press "U" to toggle invincibility.
- **Increase Energy Points**: Press "I", "O", "P" to increase red, green, and blue energy points by one respectively.
