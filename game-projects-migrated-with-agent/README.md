# Game Projects Collection

A collection of classic games implemented in Java and Ruby/Rails. This repository consolidates three separate game projects into one organized structure.

## 📁 Projects

### 1. Pig Java Game (`/pig-java-game`)
A JavaFX implementation of the classic dice game "Pig" where players race to reach 100 points by rolling dice.

**Tech Stack:**
- Java
- JavaFX
- Eclipse Project

**How to Play:**
- Players take turns rolling a die
- Each roll adds to their turn total
- Players can "hold" to bank their points
- Rolling a 1 loses all points for that turn
- First to 100 points wins!

**Setup:**
```bash
cd pig-java-game
# Open in Eclipse or your favorite Java IDE
# Build and run the project
```

---

### 2. Babbel Java (`/babbel-java`)
A Java implementation of a word game similar to Scrabble/Boggle, where players form words from letter tiles.

**Tech Stack:**
- Java
- Maven
- Eclipse Project

**Features:**
- Tile-based word formation
- Score calculation
- Dictionary validation

**Setup:**
```bash
cd babbel-java
mvn clean install
mvn exec:java
```

---

### 3. Babble Rails (`/babble-rails`)
A Ruby/Rails version of the Babble word game with HTML interface.

**Tech Stack:**
- Ruby
- Rails
- HTML/CSS

**Components:**
- Word validation system
- Tile bag management
- Tile rack system
- Test suite

**Setup:**
```bash
cd babble-rails
bundle install
# Run the Ruby scripts
ruby babble.rb
```

---

## 🎮 Game Descriptions

### Pig (Dice Game)
Pig is a simple dice game where the objective is to be the first player to reach 100 points. On each turn, a player rolls a die repeatedly until either:
- They choose to "hold" and add their turn total to their score
- They roll a 1, which ends their turn with 0 points

### Babble/Babbel (Word Game)
A word formation game where players create words from a set of letter tiles. Features include:
- Letter tiles with point values
- Word validation against dictionary
- Score tracking
- Strategic tile management

---

## 📂 Repository Structure

```
game-projects/
├── README.md
├── pig-java-game/          # JavaFX dice game
│   ├── src/
│   ├── lib/
│   └── build.fxbuild
├── babbel-java/            # Java word game
│   ├── src/
│   ├── pom.xml
│   └── .classpath
└── babble-rails/           # Ruby/Rails word game
    ├── babble.rb
    ├── Word.rb
    ├── tile_bag.rb
    ├── tile_rack.rb
    ├── tile_group.rb
    ├── html/
    └── tests/
```

---

## 🚀 Getting Started

### Prerequisites

**For Java Projects (Pig & Babbel):**
- JDK 8 or higher
- Maven (for babbel-java)
- Eclipse IDE (recommended) or any Java IDE

**For Ruby Project (Babble):**
- Ruby 2.5 or higher
- Rails
- Bundler

### Quick Start

1. Clone the repository:
```bash
git clone https://github.com/BitsAndAtoms/game-projects.git
cd game-projects
```

2. Navigate to the game you want to play:
```bash
# For Pig Java Game
cd pig-java-game

# For Babbel Java
cd babbel-java

# For Babble Rails
cd babble-rails
```

3. Follow the specific setup instructions in each project's section above.

---

## 🧪 Testing

### Babble Rails
```bash
cd babble-rails
ruby tests/test_*.rb
```

---

## 📝 Notes

- These projects were created as learning exercises and game implementations
- Each project maintains its original structure and dependencies
- Projects are independent and can be run separately

---

## 📜 License

See individual project directories for specific license information.

---

## 🤝 Contributing

These are archive/portfolio projects, but feel free to fork and create your own versions!

---

## 📧 Contact

For questions or feedback, please open an issue in this repository.

---

**Original Repositories:**
- [Pig-Java-Game](https://github.com/BitsAndAtoms/Pig-Java-Game) (2020)
- [babbel-java](https://github.com/BitsAndAtoms/babbel-java) (2020)
- [Babble-Rails](https://github.com/BitsAndAtoms/Babble-Rails) (2020)

**Consolidated:** December 2025
