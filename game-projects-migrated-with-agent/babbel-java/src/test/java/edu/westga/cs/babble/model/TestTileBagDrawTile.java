package edu.westga.cs.babble.model;

import static org.junit.Assert.assertNotNull;
import static org.junit.Assert.assertTrue;
import static org.junit.jupiter.api.Assertions.assertThrows;
import java.util.Arrays;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

class TestTileBagDrawTile {
	private String templateString;
	private TileBag newTileBag;

	@BeforeEach
	public void setUp() throws Exception {
		this.newTileBag = new TileBag();
		this.templateString = "";
		// 1-pt tiles: E, A, I, O, N, R, T, L, S, U
		for (int index = 0; index < 12; index++) {
			this.templateString = this.templateString + 'E';
		}
		for (int index = 0; index < 9; index++) {
			this.templateString = this.templateString + 'A';
		}
		for (int index = 0; index < 9; index++) {
			this.templateString = this.templateString + 'I';
		}
		for (int index = 0; index < 8; index++) {
			this.templateString = this.templateString + 'O';
		}
		for (int index = 0; index < 6; index++) {

			this.templateString = this.templateString + 'N';

		}
		for (int index = 0; index < 6; index++) {
			this.templateString = this.templateString + 'R';
		}
		for (int index = 0; index < 6; index++) {
			this.templateString = this.templateString + 'T';
		}
		for (int index = 0; index < 4; index++) {
			this.templateString = this.templateString + 'L';
		}
		for (int index = 0; index < 4; index++) {
			this.templateString = this.templateString + 'S';
		}
		for (int index = 0; index < 4; index++) {
			this.templateString = this.templateString + 'U';
		}

		// 2-pt tiles: D, G
		for (int index = 0; index < 4; index++) {
			this.templateString = this.templateString + 'D';
		}
		for (int index = 0; index < 3; index++) {
			this.templateString = this.templateString + 'G';
		}

		// 3 pt tiles: B, C, M, P
		for (int index = 0; index < 2; index++) {
			this.templateString = this.templateString + 'B';
		}
		for (int index = 0; index < 2; index++) {
			this.templateString = this.templateString + 'C';
		}
		for (int index = 0; index < 2; index++) {
			this.templateString = this.templateString + 'M';
		}
		for (int index = 0; index < 2; index++) {
			this.templateString = this.templateString + 'P';
		}

		// 4 pt tiles: F, H, V, W, Y
		for (int index = 0; index < 2; index++) {
			this.templateString = this.templateString + 'F';
		}
		for (int index = 0; index < 2; index++) {
			this.templateString = this.templateString + 'H';
		}
		for (int index = 0; index < 2; index++) {
			this.templateString = this.templateString + 'V';
		}
		for (int index = 0; index < 2; index++) {
			this.templateString = this.templateString + 'W';
		}
		for (int index = 0; index < 2; index++) {
			this.templateString = this.templateString + 'Y';
		}

		// 5-pt tiles: K
		this.templateString = this.templateString + 'K';

		// 8-pt tiles: J, X
		this.templateString = this.templateString + 'J';
		this.templateString = this.templateString + 'X';

		// 10-pt tiles: Q, Z
		this.templateString = this.templateString + 'Q';
		this.templateString = this.templateString + 'Z';

	}

	@Test
	public void canDrawAllTiles() throws EmptyTileBagException {
		String newString = "";
		for (int count = 0; count < 98; count++) {
			Tile newTile = this.newTileBag.drawTile();
			assertNotNull("Verify that drawn tile is NOT null", newTile);
			newString = newString + newTile.getLetter();
		}
		char[] chars1 = newString.toCharArray();
		char[] chars2 = this.templateString.toCharArray();
		Arrays.sort(chars1);
		Arrays.sort(chars2);
		assertTrue("The two strings contain the specific number of each alphabet type", Arrays.equals(chars1, chars2));
	}

	@Test
	public void canNotDrawTooManyTiles() throws EmptyTileBagException {
		TileBag newTileBag = new TileBag();
		for (int count = 0; count < 98; count++) {
			Tile newTile = newTileBag.drawTile();
			assertNotNull("Verify that drawn tile is NOT null", newTile);
		}
		assertThrows(EmptyTileBagException.class, () -> newTileBag.drawTile(), "More than 98 tiles can not be drawn");
	}

	@Test
	public void hasProperTileDistribution() throws EmptyTileBagException {

		String newString = "";
		for (int count = 0; count < 98; count++) {
			Tile newTile = this.newTileBag.drawTile();
			newString = newString + newTile.getLetter();
		}
		char[] chars1 = newString.toCharArray();
		char[] chars2 = this.templateString.toCharArray();
		Arrays.sort(chars1);
		Arrays.sort(chars2);
		assertTrue("The two strings contain the specific distribution of each alphabet type",
				Arrays.equals(chars1, chars2));
	}

}
