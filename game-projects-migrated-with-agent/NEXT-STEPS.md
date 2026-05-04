# Next Steps - Game Projects Migration

This document outlines the steps needed to complete the migration of the three game repositories.

## ✅ Completed Steps

1. **Created new repository:** `game-projects`
2. **Added comprehensive README.md** with overview of all three games
3. **Created MIGRATION.md** with detailed migration instructions
4. **Added .gitignore** for Java and Ruby projects
5. **Created individual READMEs** for each subdirectory:
   - `pig-java-game/README.md`
   - `babbel-java/README.md`
   - `babble-rails/README.md`

## 📋 TODO: Complete the Migration

### Step 1: Clone and Migrate Code

You have two options to migrate the actual code:

#### Option A: Using Git Subtree (Preserves History) - RECOMMENDED

```bash
# Clone the new repository
git clone https://github.com/BitsAndAtoms/game-projects.git
cd game-projects

# Add each original repository as a subtree
git subtree add --prefix=pig-java-game https://github.com/BitsAndAtoms/Pig-Java-Game.git master --squash
git subtree add --prefix=babbel-java https://github.com/BitsAndAtoms/babbel-java.git master --squash
git subtree add --prefix=babble-rails https://github.com/BitsAndAtoms/Babble-Rails.git master --squash

# Push all changes
git push origin main
```

#### Option B: Manual Copy (Simpler)

```bash
# Clone the new repository
git clone https://github.com/BitsAndAtoms/game-projects.git
cd game-projects

# Clone each original repository
cd ..
git clone https://github.com/BitsAndAtoms/Pig-Java-Game.git temp-pig
git clone https://github.com/BitsAndAtoms/babbel-java.git temp-babbel
git clone https://github.com/BitsAndAtoms/Babble-Rails.git temp-babble

# Copy files (excluding .git directories)
cd game-projects
rsync -av --exclude='.git' --exclude='README.md' ../temp-pig/ pig-java-game/
rsync -av --exclude='.git' --exclude='README.md' ../temp-babbel/ babbel-java/
rsync -av --exclude='.git' --exclude='README.md' ../temp-babble/ babble-rails/

# Clean up
cd ..
rm -rf temp-pig temp-babbel temp-babble

# Commit and push
cd game-projects
git add .
git commit -m "Migrate all three game projects into subdirectories"
git push origin main
```

### Step 2: Verify Migration

After migrating, verify each project:

```bash
# Test Pig Java Game
cd pig-java-game
# Open in Eclipse and verify it builds

# Test Babbel Java
cd ../babbel-java
mvn clean install
# Verify build succeeds

# Test Babble Rails
cd ../babble-rails
bundle install
ruby babble.rb
# Verify it runs
```

### Step 3: Update Original Repositories

Add deprecation notices to the original repositories:

#### For Pig-Java-Game

Create/update `README.md`:
```markdown
# ⚠️ DEPRECATED - This repository has been archived

This project has been consolidated into the **game-projects** repository:

🔗 **New Location:** https://github.com/BitsAndAtoms/game-projects/tree/main/pig-java-game

Please use the new repository for:
- Latest updates
- Issues and discussions
- Contributing

This repository will remain available for historical reference but will not receive updates.

**Migration Date:** December 17, 2025
```

#### For babbel-java

Similar deprecation notice:
```markdown
# ⚠️ DEPRECATED - This repository has been archived

This project has been consolidated into the **game-projects** repository:

🔗 **New Location:** https://github.com/BitsAndAtoms/game-projects/tree/main/babbel-java

Please use the new repository for:
- Latest updates
- Issues and discussions
- Contributing

This repository will remain available for historical reference but will not receive updates.

**Migration Date:** December 17, 2025
```

#### For Babble-Rails

Similar deprecation notice:
```markdown
# ⚠️ DEPRECATED - This repository has been archived

This project has been consolidated into the **game-projects** repository:

🔗 **New Location:** https://github.com/BitsAndAtoms/game-projects/tree/main/babble-rails

Please use the new repository for:
- Latest updates
- Issues and discussions
- Contributing

This repository will remain available for historical reference but will not receive updates.

**Migration Date:** December 17, 2025
```

### Step 4: Archive Original Repositories

On GitHub, for each original repository:

1. Go to repository **Settings**
2. Scroll to the bottom
3. Click **"Archive this repository"**
4. Confirm the action

This will:
- Make the repository read-only
- Add an "Archived" badge
- Preserve all content and history
- Prevent new issues/PRs

### Step 5: Update Any External Links

If you have links to these repositories in:
- Personal website
- LinkedIn
- Resume
- Blog posts
- Other projects

Update them to point to:
- Main: `https://github.com/BitsAndAtoms/game-projects`
- Specific: `https://github.com/BitsAndAtoms/game-projects/tree/main/[project-name]`

## 🎯 Migration Checklist

- [ ] Clone new game-projects repository
- [ ] Migrate Pig-Java-Game code to `pig-java-game/`
- [ ] Migrate babbel-java code to `babbel-java/`
- [ ] Migrate Babble-Rails code to `babble-rails/`
- [ ] Test Pig Java Game builds and runs
- [ ] Test Babbel Java builds and runs
- [ ] Test Babble Rails runs
- [ ] Add deprecation notice to Pig-Java-Game
- [ ] Add deprecation notice to babbel-java
- [ ] Add deprecation notice to Babble-Rails
- [ ] Archive Pig-Java-Game repository
- [ ] Archive babbel-java repository
- [ ] Archive Babble-Rails repository
- [ ] Update external links (if any)
- [ ] Add topics/tags to game-projects repository

## 📊 Repository Statistics

### Before Migration
- **3 separate repositories**
- Scattered across your profile
- Duplicate documentation
- Harder to maintain

### After Migration
- **1 unified repository**
- Organized structure
- Comprehensive documentation
- Easier to showcase and maintain

## 🏷️ Suggested GitHub Topics

Add these topics to the game-projects repository for better discoverability:

```
java
javafx
ruby
rails
games
word-game
dice-game
scrabble
portfolio
archived-project
maven
eclipse
tile-game
```

To add topics:
1. Go to the repository on GitHub
2. Click the gear icon ⚙️ next to "About"
3. Add topics in the "Topics" field
4. Click "Save changes"

## 📝 Optional: GitHub Release

Consider creating a release for the migration:

```bash
git tag -a v1.0.0 -m "Initial consolidated release - Migration of three game projects"
git push origin v1.0.0
```

Then create a GitHub Release:
1. Go to repository → Releases → Create new release
2. Choose tag: v1.0.0
3. Title: "Game Projects Collection v1.0.0"
4. Description: "Consolidated release combining Pig Java Game, Babbel Java, and Babble Rails"

## 🎉 Benefits of Consolidation

1. **Single point of reference** for all game projects
2. **Easier maintenance** - update in one place
3. **Better organization** - clear structure
4. **Professional presentation** - showcases your work better
5. **Simplified navigation** - users can find all games easily

## 🤔 Questions?

If you encounter issues during migration:
1. Check MIGRATION.md for detailed instructions
2. Verify Git configurations
3. Ensure all dependencies are installed
4. Review error messages carefully

---

**Created:** December 17, 2025  
**Status:** Ready for migration  
**Estimated Time:** 30-60 minutes
