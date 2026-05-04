# Migration Guide

This document provides instructions for migrating code from the original three repositories into this consolidated repository.

## Background

This repository consolidates three separate game projects:
- **Pig-Java-Game** - A JavaFX dice game
- **babbel-java** - A Maven-based word game
- **Babble-Rails** - A Ruby/Rails word game

## Repository Structure

Each game maintains its own directory with its original structure intact:

```
game-projects/
├── pig-java-game/      # From: BitsAndAtoms/Pig-Java-Game
├── babbel-java/        # From: BitsAndAtoms/babbel-java
└── babble-rails/       # From: BitsAndAtoms/Babble-Rails
```

## Migration Steps

### Step 1: Clone this repository
```bash
git clone https://github.com/BitsAndAtoms/game-projects.git
cd game-projects
```

### Step 2: Add original repositories as remotes

```bash
# Add remote for Pig Java Game
git remote add pig-origin https://github.com/BitsAndAtoms/Pig-Java-Game.git

# Add remote for babbel-java
git remote add babbel-origin https://github.com/BitsAndAtoms/babbel-java.git

# Add remote for Babble-Rails
git remote add babble-rails-origin https://github.com/BitsAndAtoms/Babble-Rails.git

# Fetch all
git fetch --all
```

### Step 3: Merge each project (Advanced Git)

**Option A: Using Subtree Merge (Preserves History)**

```bash
# Merge Pig Java Game
git merge -s ours --no-commit --allow-unrelated-histories pig-origin/master
git read-tree --prefix=pig-java-game/ -u pig-origin/master
git commit -m "Merge Pig-Java-Game into pig-java-game/ subdirectory"

# Merge babbel-java
git merge -s ours --no-commit --allow-unrelated-histories babbel-origin/master
git read-tree --prefix=babbel-java/ -u babbel-origin/master
git commit -m "Merge babbel-java into babbel-java/ subdirectory"

# Merge Babble-Rails
git merge -s ours --no-commit --allow-unrelated-histories babble-rails-origin/master
git read-tree --prefix=babble-rails/ -u babble-rails-origin/master
git commit -m "Merge Babble-Rails into babble-rails/ subdirectory"
```

**Option B: Manual Copy (Simpler, No History)**

```bash
# Create directories
mkdir -p pig-java-game babbel-java babble-rails

# Clone and copy Pig Java Game
git clone https://github.com/BitsAndAtoms/Pig-Java-Game.git temp-pig
cp -r temp-pig/* pig-java-game/
rm -rf temp-pig

# Clone and copy babbel-java
git clone https://github.com/BitsAndAtoms/babbel-java.git temp-babbel
cp -r temp-babbel/* babbel-java/
rm -rf temp-babbel

# Clone and copy Babble-Rails
git clone https://github.com/BitsAndAtoms/Babble-Rails.git temp-babble-rails
cp -r temp-babble-rails/* babble-rails/
rm -rf temp-babble-rails

# Commit the changes
git add .
git commit -m "Add all three game projects"
git push origin main
```

## Post-Migration Checklist

- [ ] Verify all source files are present in each subdirectory
- [ ] Test build/run for each project independently
- [ ] Update any absolute paths in configuration files
- [ ] Add individual README.md files in each subdirectory if needed
- [ ] Archive or mark original repositories as deprecated
- [ ] Update any external links pointing to old repositories

## IDE Setup

### For Eclipse Projects (Pig & Babbel)
1. Open Eclipse
2. File → Import → Existing Projects into Workspace
3. Select the specific subdirectory (e.g., `game-projects/pig-java-game`)
4. Import as existing project

### For Maven Project (Babbel)
1. Navigate to `babbel-java/`
2. Run `mvn clean install`
3. Import into IDE as Maven project

### For Ruby Project (Babble)
1. Navigate to `babble-rails/`
2. Run `bundle install`
3. Open in your preferred Ruby IDE or text editor

## Maintaining Separate Git Histories (Optional)

If you want to preserve the full git history of each project:

```bash
# Use git subtree for each project
git subtree add --prefix=pig-java-game https://github.com/BitsAndAtoms/Pig-Java-Game.git master
git subtree add --prefix=babbel-java https://github.com/BitsAndAtoms/babbel-java.git master
git subtree add --prefix=babble-rails https://github.com/BitsAndAtoms/Babble-Rails.git master
```

## Original Repository Status

After successful migration, the original repositories can be:
1. **Archived** - Mark as read-only with a notice pointing to this repo
2. **Deprecated** - Add deprecation notice to README
3. **Deleted** - Only after confirming all content is migrated

## Support

If you encounter issues during migration:
1. Check that all remotes are correctly configured
2. Ensure you have the latest commits from all original repos
3. Verify directory permissions
4. Open an issue in this repository for assistance

---

**Migration Date:** December 17, 2025  
**Migrated By:** BitsAndAtoms
