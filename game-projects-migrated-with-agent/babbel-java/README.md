# Babbel Java

A Java implementation of a word game similar to Scrabble/Boggle, where players form words from letter tiles.

## About the Game

**Babbel** is a tile-based word game where players create words from a collection of letter tiles, each with associated point values. The game tests vocabulary skills and strategic thinking as players maximize their scores by forming high-value words.

### Game Concept

- Players draw letter tiles from a tile bag
- Form words using the available tiles
- Score points based on letter values and word complexity
- Validate words against a dictionary
- Strategic tile management and word formation

## Technology Stack

- **Language:** Java
- **Build Tool:** Maven
- **IDE:** Eclipse/IntelliJ compatible
- **Dependencies:** Managed via Maven (see pom.xml)

## Project Structure

```
babbel-java/
├── src/                    # Source code
│   ├── main/
│   │   └── java/          # Java source files
│   └── test/              # Test files
├── .settings/             # IDE settings
├── .classpath             # Eclipse classpath
├── .project               # Eclipse project file
├── pom.xml               # Maven configuration
└── .gitignore            # Git ignore rules
```

## Setup Instructions

### Prerequisites
- JDK 8 or higher
- Maven 3.6 or higher
- Eclipse IDE or IntelliJ IDEA (optional)

### Building with Maven

```bash
# Navigate to the project directory
cd babbel-java

# Clean and compile
mvn clean compile

# Run tests
mvn test

# Package the application
mvn package

# Run the application
mvn exec:java
```

### Running in Eclipse

1. **Import the Maven Project:**
   ```
   File → Import → Maven → Existing Maven Projects
   Select: game-projects/babbel-java
   ```

2. **Maven Configuration:**
   - Eclipse will automatically download dependencies
   - Wait for Maven to finish resolving dependencies

3. **Run the Application:**
   - Right-click on the main class
   - Select "Run As → Java Application"

### Running in IntelliJ IDEA

1. **Open Project:**
   ```
   File → Open → Select babbel-java directory
   ```

2. **IntelliJ automatically recognizes Maven projects**

3. **Run Configuration:**
   - Create new Java application run configuration
   - Set main class and run

## Game Features

### Tile System
- **Tile Bag:** Central collection of all available letter tiles
- **Letter Values:** Each letter has a point value based on rarity
- **Tile Distribution:** Similar to Scrabble's letter frequency

### Word Formation
- Create words from your available tiles
- Words must be valid dictionary entries
- Score calculation based on letter values

### Scoring System
- Base points for each letter
- Bonus points for longer words
- Special multipliers (if implemented)

## Maven Dependencies

Check `pom.xml` for the complete list of dependencies. Common dependencies might include:
- JUnit for testing
- Dictionary/word validation libraries
- Logging frameworks

## Development Notes

This project demonstrates:
- Object-oriented design in Java
- Maven project structure
- Unit testing with JUnit
- Game logic implementation
- Data structure usage (collections, sets, maps)

### Key Classes (Likely)
- `TileBag` - Manages the collection of tiles
- `Tile` - Represents individual letter tiles
- `Word` - Represents formed words
- `Player` - Player state and score
- `Game` - Main game controller

## Testing

```bash
# Run all tests
mvn test

# Run specific test class
mvn test -Dtest=TestClassName

# Run with coverage
mvn test jacoco:report
```

## Building for Distribution

```bash
# Create executable JAR
mvn clean package

# The JAR will be in target/ directory
java -jar target/babbel-java-1.0-SNAPSHOT.jar
```

## Original Repository

This project was originally hosted at:
- [babbel-java](https://github.com/BitsAndAtoms/babbel-java)
- **Created:** February 2020
- **Migrated:** December 2025

## License

See parent repository for license information.

## Contributing

This is an archived/portfolio project, but feel free to fork and create your own version!

## Future Enhancements

Potential improvements could include:
- [ ] Multiplayer support
- [ ] GUI interface
- [ ] Online dictionary integration
- [ ] Save/load game state
- [ ] Different game modes
- [ ] Hint system
- [ ] Tile swap feature

---

**Status:** Archived  
**Last Updated:** February 2020 (original), December 2025 (migration)
