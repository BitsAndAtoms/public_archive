# Babble Rails

A Ruby implementation of the Babble word game with HTML interface, inspired by Scrabble-style gameplay.

## About the Game

**Babble** is a word formation game where players create words from letter tiles drawn from a bag. This Ruby implementation includes the core game logic, tile management system, and a basic HTML interface for playing.

## Technology Stack

- **Language:** Ruby
- **Framework:** Rails (lightweight implementation)
- **Frontend:** HTML/CSS
- **Testing:** Ruby test suite

## Project Structure

```
babble-rails/
├── babble.rb           # Main game logic
├── Word.rb             # Word class and validation
├── tile_bag.rb         # Tile bag management
├── tile_rack.rb        # Player's tile rack
├── tile_group.rb       # Tile grouping logic
├── html/               # HTML interface files
├── tests/              # Test suite
├── Gemfile             # Ruby dependencies
├── Gemfile.lock        # Locked dependencies
└── Rakefile           # Rake tasks
```

## Core Components

### Game Classes

1. **`babble.rb`** - Main Game Controller
   - Orchestrates gameplay
   - Manages game state
   - Handles turn logic

2. **`Word.rb`** - Word Validation
   - Validates word formation
   - Checks dictionary
   - Calculates word scores

3. **`tile_bag.rb`** - Tile Management
   - Maintains available tiles
   - Handles tile distribution
   - Implements Scrabble-like tile frequencies

4. **`tile_rack.rb`** - Player Tiles
   - Manages player's current tiles
   - Tile selection and placement
   - Rack refilling logic

5. **`tile_group.rb`** - Tile Organization
   - Groups tiles for word formation
   - Tile arrangement utilities

## Setup Instructions

### Prerequisites
- Ruby 2.5 or higher
- Bundler gem
- Basic knowledge of Ruby/Rails

### Installation

```bash
# Navigate to the project directory
cd babble-rails

# Install dependencies
bundle install

# Verify installation
ruby --version
bundle --version
```

### Running the Game

```bash
# Run the main game script
ruby babble.rb

# Run with specific options (if available)
ruby babble.rb --mode=interactive
```

### Running Tests

```bash
# Run all tests
ruby tests/test_*.rb

# Run specific test file
ruby tests/test_word.rb

# With Rake (if configured)
rake test
```

## Game Rules

### Tile System
- Each letter has a point value
- Tiles are drawn randomly from the bag
- Limited tile supply (like Scrabble)

### Word Formation
1. Draw tiles to fill your rack
2. Form valid words using your tiles
3. Submit word for validation
4. Score points based on letter values
5. Draw new tiles to replace used ones

### Scoring
- Base points for each letter
- Bonus points for longer words
- Special multipliers (if implemented)

## HTML Interface

The `html/` directory contains:
- Game board interface
- Tile display
- Score tracking
- User interaction forms

To run the HTML interface:
```bash
# If using Rails server
rails server

# Or open the HTML file directly in a browser
open html/index.html
```

## Development

### Key Methods (Likely)

**TileBag:**
```ruby
- draw_tiles(count)      # Draw random tiles
- remaining_tiles        # Get count of remaining tiles
- return_tiles(tiles)    # Return tiles to bag
```

**Word:**
```ruby
- valid?                 # Check if word is valid
- score                  # Calculate word score
- letters                # Get word letters
```

**TileRack:**
```ruby
- add_tile(tile)         # Add tile to rack
- remove_tiles(tiles)    # Remove tiles from rack
- refill(bag)           # Refill from tile bag
```

### Adding Features

To extend the game:

1. **Add new tile types:**
   - Edit `tile_bag.rb`
   - Update tile distribution

2. **Enhance word validation:**
   - Modify `Word.rb`
   - Add custom dictionaries

3. **Improve UI:**
   - Update HTML files
   - Add CSS styling

## Testing

Test files are located in `tests/` directory:

```bash
# Example test structure
tests/
├── test_word.rb
├── test_tile_bag.rb
├── test_tile_rack.rb
└── test_game.rb
```

Run tests to verify functionality after changes.

## Dependencies

Check `Gemfile` for full dependency list. Common gems might include:
- Rails (lightweight features)
- Testing frameworks
- Utility libraries

## File Overview

| File | Purpose |
|------|---------|
| `babble.rb` | Main game engine |
| `Word.rb` | Word validation and scoring |
| `tile_bag.rb` | Tile inventory management |
| `tile_rack.rb` | Player's tile collection |
| `tile_group.rb` | Tile organization utilities |
| `Gemfile` | Ruby dependencies |
| `Rakefile` | Build and task automation |

## Playing the Game

### Basic Gameplay Loop

1. **Setup:**
   ```ruby
   game = Babble.new
   game.start
   ```

2. **Take Turn:**
   - View your tiles
   - Form a word
   - Submit for validation
   - Score points

3. **Continue:**
   - Refill tiles
   - Next player's turn

## Troubleshooting

### Common Issues

**Missing Dependencies:**
```bash
bundle install
```

**Ruby Version Mismatch:**
```bash
rbenv install 2.7.0  # or rvm install 2.7.0
rbenv local 2.7.0
```

**Test Failures:**
- Check Ruby version compatibility
- Ensure all dependencies are installed
- Review test output for specific errors

## Original Repository

This project was originally hosted at:
- [Babble-Rails](https://github.com/BitsAndAtoms/Babble-Rails)
- **Created:** February 2020
- **Migrated:** December 2025

## License

See parent repository for license information.

## Contributing

This is an archived/portfolio project, but feel free to fork and create your own version!

## Future Enhancements

Potential improvements:
- [ ] Multiplayer support
- [ ] Enhanced web interface
- [ ] Mobile-responsive design
- [ ] Real-time gameplay
- [ ] User accounts and saved games
- [ ] Achievement system
- [ ] Tournament mode

---

**Status:** Archived  
**Last Updated:** February 2020 (original), December 2025 (migration)
