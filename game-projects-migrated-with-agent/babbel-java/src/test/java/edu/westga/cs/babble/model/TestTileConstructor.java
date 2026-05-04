package edu.westga.cs.babble.model;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

/**
 * @author Siddhartha Gupa
 * @date 08/29/2018
 *
 */
class TestTileConstructor {
	/**
	 * @throws java.lang.Exception
	 */
	@BeforeEach
	public void setUp() throws Exception {

	}

	@Test
	public void shouldNotAllowNonLetters() {
		assertThrows(IllegalArgumentException.class, () -> new Tile('1'));
		assertThrows(IllegalArgumentException.class, () -> new Tile('!'));
		assertThrows(IllegalArgumentException.class, () -> new Tile(' '));
	}

	@Test
	public void shouldCreateOnePointTiles() {
		String onePointLetters = "EAIONRTLSU";
		char newChar;
		for (int count = 0; count < onePointLetters.length(); count++) {
			newChar = onePointLetters.charAt(count);
			assertEquals(newChar, (new Tile(newChar).getLetter()));
			assertEquals(newChar, (new Tile(Character.toLowerCase(newChar)).getLetter()));
			assertEquals(1, (new Tile(Character.toLowerCase(newChar)).getPointValue()));
		}
	}

	@Test
	public void shouldCreateTwoPointTiles() {
		String onePointLetters = "DG";
		char newChar;
		for (int count = 0; count < onePointLetters.length(); count++) {
			newChar = onePointLetters.charAt(count);
			assertEquals(newChar, (new Tile(newChar).getLetter()));
			assertEquals(newChar, (new Tile(Character.toLowerCase(newChar)).getLetter()));
			assertEquals(2, (new Tile(Character.toLowerCase(newChar)).getPointValue()));
		}
	}

	@Test
	public void shouldCreateThreePointTiles() {
		String onePointLetters = "BCMP";
		char newChar;
		for (int count = 0; count < onePointLetters.length(); count++) {
			newChar = onePointLetters.charAt(count);
			assertEquals(newChar, (new Tile(newChar).getLetter()));
			assertEquals(newChar, (new Tile(Character.toLowerCase(newChar)).getLetter()));
			assertEquals(3, (new Tile(Character.toLowerCase(newChar)).getPointValue()));
		}
	}

	@Test
	public void shouldCreateFourPointTiles() {
		String onePointLetters = "FHVWY";
		char newChar;
		for (int count = 0; count < onePointLetters.length(); count++) {
			newChar = onePointLetters.charAt(count);
			assertEquals(newChar, (new Tile(newChar).getLetter()));
			assertEquals(newChar, (new Tile(Character.toLowerCase(newChar)).getLetter()));
			assertEquals(4, (new Tile(Character.toLowerCase(newChar)).getPointValue()));
		}
	}

	@Test
	public void shouldCreateFivePointTiles() {
		String onePointLetters = "K";
		char newChar;
		for (int count = 0; count < onePointLetters.length(); count++) {
			newChar = onePointLetters.charAt(count);
			assertEquals(newChar, (new Tile(newChar).getLetter()));
			assertEquals(newChar, (new Tile(Character.toLowerCase(newChar)).getLetter()));
			assertEquals(5, (new Tile(Character.toLowerCase(newChar)).getPointValue()));
		}
	}

	@Test
	public void shouldCreateEightPointTiles() {
		String onePointLetters = "JX";
		char newChar;
		for (int count = 0; count < onePointLetters.length(); count++) {
			newChar = onePointLetters.charAt(count);
			assertEquals(newChar, (new Tile(newChar).getLetter()));
			assertEquals(newChar, (new Tile(Character.toLowerCase(newChar)).getLetter()));
			assertEquals(8, (new Tile(Character.toLowerCase(newChar)).getPointValue()));
		}
	}

	@Test
	public void shouldCreateTenPointTiles() {
		String onePointLetters = "QZ";
		char newChar;
		for (int count = 0; count < onePointLetters.length(); count++) {
			newChar = onePointLetters.charAt(count);
			assertEquals(newChar, (new Tile(newChar).getLetter()));
			assertEquals(newChar, (new Tile(Character.toLowerCase(newChar)).getLetter()));
			assertEquals(10, (new Tile(Character.toLowerCase(newChar)).getPointValue()));
		}
	}

}
