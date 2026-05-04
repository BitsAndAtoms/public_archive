package edu.westga.cs.babble.model;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

class TestPlayedWordMatches {

	private PlayedWord newWord;

	@BeforeEach
	public void setUp() throws Exception {
		this.newWord = new PlayedWord();
	}

	@Test
	public void hasTilesForAMultipleLetterWord() {
		this.newWord.append(new Tile('A'));
		this.newWord.append(new Tile('R'));
		this.newWord.append(new Tile('C'));
		this.newWord.append(new Tile('A'));
		this.newWord.append(new Tile('D'));
		this.newWord.append(new Tile('E'));
		assertEquals(this.newWord.matches("ARCADE"), true);
	}

	@Test
	public void hasTilesForASingleLetterWord() {
		this.newWord.append(new Tile('A'));
		assertEquals(this.newWord.matches("A"), true);
	}

	@Test
	public void cannotMatchWordWhenTilesAreScrambled() {
		this.newWord.append(new Tile('A'));
		this.newWord.append(new Tile('C'));
		this.newWord.append(new Tile('R'));
		this.newWord.append(new Tile('D'));
		this.newWord.append(new Tile('A'));
		this.newWord.append(new Tile('E'));
		assertEquals(this.newWord.matches("ARCADE"), false);
	}

	@Test
	public void cannotMatchWordIfInsufficientTiles() {
		this.newWord.append(new Tile('A'));
		this.newWord.append(new Tile('C'));
		this.newWord.append(new Tile('R'));
		this.newWord.append(new Tile('D'));
		assertEquals(this.newWord.matches("ARCADE"), false);
	}

	@Test
	public void canMatchWordWithDuplicateLetters() {
		this.newWord.append(new Tile('A'));
		this.newWord.append(new Tile('A'));
		this.newWord.append(new Tile('R'));
		this.newWord.append(new Tile('A'));
		assertEquals(this.newWord.matches("AARA"), true);
	}

	@Test
	void nonEmptyWordShouldNotMatchEmptyText() {
		this.newWord.append(new Tile('A'));
		this.newWord.append(new Tile('A'));
		this.newWord.append(new Tile('R'));
		this.newWord.append(new Tile('A'));
		assertEquals(this.newWord.matches(""), false);
	}

	@Test
	public void emptyWordShouldNotMatchEmptyText() {
		assertEquals(this.newWord.matches(""), false);
	}

	@Test
	public void shouldNotAllowNull() {
		assertThrows(IllegalArgumentException.class, () -> this.newWord.matches(null));

	}

}
