package edu.westga.cs.babble.model;

import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

class TestPlayedWordGetScore {
	private PlayedWord newWord;

	/**
	 * sets up the newWord object for use
	 */
	@BeforeEach
	public void setUp() throws Exception {
		this.newWord = new PlayedWord();
	}

	@Test
	public void emptyWordShouldHaveScoreOfZero() {
		assertEquals(this.newWord.getScore(), 0);
	}

	@Test
	public void scoreAOneTileWord() {
		this.newWord.append(new Tile('A'));
		assertEquals(this.newWord.getScore(), 1);
	}

	@Test
	public void scoreAWordWithMultipleDifferingTiles() {
		this.newWord.append(new Tile('E'));
		this.newWord.append(new Tile('I'));
		this.newWord.append(new Tile('A'));
		this.newWord.append(new Tile('O'));
		this.newWord.append(new Tile('P'));
		assertEquals(this.newWord.getScore(), 7);
	}

	@Test
	public void scoreAWordContainingDuplicateTiles() {
		this.newWord.append(new Tile('E'));
		this.newWord.append(new Tile('E'));
		this.newWord.append(new Tile('E'));
		this.newWord.append(new Tile('E'));
		this.newWord.append(new Tile('P'));
		assertEquals(this.newWord.getScore(), 7);
	}

}
