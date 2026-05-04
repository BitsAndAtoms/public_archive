# Pig Java Game

A JavaFX implementation of the classic dice game "Pig" where players race to reach 100 points.

## About the Game

**Pig** is a simple jeopardy dice game where two or more players compete to be the first to reach 100 points. Players take turns rolling a single die as many times as they wish, adding all roll results to a running total. However, if a player rolls a 1, they score nothing for that turn and it becomes the next player's turn.

### Game Rules

1. **Turn Structure:**
   - A player may roll the die as many times as desired during their turn
   - Each roll (except 1) is added to their turn total
   - The player may choose to "hold" at any time to bank their turn total

2. **Rolling a 1:**
   - If a player rolls a 1, their turn ends immediately
   - They score 0 points for that turn
   - All accumulated points for that turn are lost

3. **Holding:**
   - When a player chooses to hold, their turn total is added to their overall score
   - The turn passes to the next player

4. **Winning:**
   - First player to reach or exceed 100 points wins

## Technology Stack

- **Language:** Java
- **UI Framework:** JavaFX
- **IDE:** Eclipse Project
- **Build System:** Eclipse build configuration

## Project Structure

```
pig-java-game/
├── src/                    # Source code
│   └── application/        # Main application package
├── lib/                    # External libraries
├── bin/                    # Compiled classes
├── .classpath              # Eclipse classpath
├── .project                # Eclipse project file
└── build.fxbuild          # JavaFX build configuration
```

## Setup Instructions

### Prerequisites
- JDK 8 or higher with JavaFX support
- Eclipse IDE (or any Java IDE that supports JavaFX)

### Running in Eclipse

1. **Import the Project:**
   ```
   File → Import → Existing Projects into Workspace
   Select: game-projects/pig-java-game
   ```

2. **Configure JavaFX:**
   - Ensure JavaFX libraries are in your build path
   - For JDK 11+, you may need to add JavaFX as a module

3. **Run the Application:**
   - Right-click on the main class
   - Select "Run As → Java Application"

### Running from Command Line

```bash
# Navigate to the project directory
cd pig-java-game

# Compile (if not using IDE)
javac -d bin -cp "lib/*" src/**/*.java

# Run
java -cp "bin:lib/*" application.Main
```

## Strategy Tips

- **Risk vs. Reward:** The more you roll, the higher your potential score, but also the higher the risk of rolling a 1
- **Conservative Play:** Holding after accumulating 20-25 points is often considered safe
- **Aggressive Play:** When trailing, you may need to take more risks
- **Opponent Tracking:** Pay attention to your opponent's score to adjust your strategy

## Game Screenshots

*[Add screenshots here if available]*

## Development Notes

This project was created as a learning exercise in JavaFX game development and demonstrates:
- Event-driven programming
- JavaFX UI components
- Game state management
- Random number generation
- User interaction handling

## Original Repository

This project was originally hosted at:
- [Pig-Java-Game](https://github.com/BitsAndAtoms/Pig-Java-Game)
- **Created:** February 2020
- **Migrated:** December 2025

## License

See parent repository for license information.

## Contributing

This is an archived/portfolio project, but feel free to fork and create your own version!

---

**Status:** Archived  
**Last Updated:** February 2020 (original), December 2025 (migration)
