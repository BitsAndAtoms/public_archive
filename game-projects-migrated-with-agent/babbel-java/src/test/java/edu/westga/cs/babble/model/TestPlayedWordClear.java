package edu.westga.cs.babble.model;



import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

class TestPlayedWordClear {

	private PlayedWord newWord;

	/**
	 * sets up the newWord object for use
	 */
	@BeforeEach
	public void setUp() throws Exception {
		this.newWord = new PlayedWord();
	}

	@Test
	public void shouldClearEmptyWord() {
		this.newWord.clear();
		assertEquals(this.newWord.getHand(), "");
	}

	@Test
	public void shouldClearWordWithOneTile() {
		this.newWord.append(new Tile('A'));
		assertEquals(this.newWord.matches("A"), true);
		this.newWord.clear();
		assertEquals(this.newWord.getHand(), "");
	}

	@Test
	public void shouldClearWordWithManyTiles() {
		this.newWord.append(new Tile('A'));
		this.newWord.append(new Tile('R'));
		this.newWord.append(new Tile('C'));
		this.newWord.append(new Tile('A'));
		this.newWord.append(new Tile('D'));
		this.newWord.append(new Tile('E'));
		assertEquals(this.newWord.matches("ARCADE"), true);
		this.newWord.clear();
		assertEquals(this.newWord.getHand(), "");
	}

}
