package edu.westga.cs6910.pig.testing.advancedStrategy;

import static org.junit.Assert.assertEquals;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import edu.westga.cs6910.pig.model.strategies.AdvancedStrategy;

/**
 * Test cases for advanced strategy's rollAgain method
 * 
 * @author Siddhartha Gupta
 * @version 7/10/2018
 */
class AdvancedStrategyRollAgain {
	private AdvancedStrategy playAdvancedStrategy;

	/**
	 * @throws java.lang.Exception
	 */
	@BeforeEach
	void setUp() throws Exception {
		this.playAdvancedStrategy = new AdvancedStrategy();
	}

	/**
	 * Test for the first roll of the game by the computer
	 */
	@Test
	void testShouldReturnTrueAtStartOfGame() {
		boolean result = this.playAdvancedStrategy.rollAgain(0, 0, 100, 100);
		assertEquals(true, result);
	}

	/**
	 * Test for the computer player's roll after human player goes first with no
	 * points and computer player hasn't gone yet
	 */
	@Test
	void testShouldReturnTrueAtStartOfGameAfterHumanPlayerHasGoneWithNoPoints() {
		boolean result = this.playAdvancedStrategy.rollAgain(0, 0, 100, 100);
		assertEquals(true, result);
	}

	/**
	 * Test for the computer player's roll after human player goes first with 7
	 * points and computer player hasn't gone yet
	 */
	@Test
	void testShouldReturnTrueAtStartOfGameAfterHumanPlayerHasGoneWithSomePoints() {
		boolean result = this.playAdvancedStrategy.rollAgain(0, 0, 100, 93);
		assertEquals(true, result);
	}

	/**
	 * Test for the computer player's roll when it reaches exactly 100 points before
	 * human player
	 */
	@Test
	void testShouldReturnFalseAtEndOfGameWhenComputerPlayerReaches100Points() {
		boolean result = this.playAdvancedStrategy.rollAgain(1, 7, 0, 10);
		assertEquals(false, result);
	}

	/**
	 * Test for the computer player's roll when it exceeds 100 points before human
	 * player reaches/exceeds the goal
	 */
	@Test
	void testShouldReturnFalseAtEndOfGameWhenComputerPlayerReaches106Points() {
		boolean result = this.playAdvancedStrategy.rollAgain(1, 7, -6, 1);
		assertEquals(false, result);
	}

	/**
	 * Test for the computer player's roll when human player reaches 100 points
	 * first
	 */
	@Test
	void testShouldReturnFalseAtEndOfGameWhenHumanPlayerReaches100Points() {
		boolean result = this.playAdvancedStrategy.rollAgain(0, 0, 2, 0);
		assertEquals(false, result);
	}

	/**
	 * Test for the computer player's roll when human player exceeds 100 points
	 * first
	 */
	@Test
	void testShouldReturnFalseAtEndOfGameWhenHumanPlayerReaches106Points() {
		boolean result = this.playAdvancedStrategy.rollAgain(0, 0, 12, -6);
		assertEquals(false, result);
	}

	/**
	 * Test for ComputerPlayer's roll when human player needs 7 points to win
	 */
	@Test
	void testShouldReturnTrueWhenHumanPlayerNeeds7PointsToWin() {
		boolean result = this.playAdvancedStrategy.rollAgain(1, 5, 40, 7);
		assertEquals(true, result);
	}

	/**
	 * Test for ComputerPlayer's roll when human player needs less than 7 points to
	 * win
	 */
	@Test
	void testShouldReturnTrueWhenHumanPlayerNeeds3PointsToWin() {
		boolean result = this.playAdvancedStrategy.rollAgain(1, 5, 30, 3);
		assertEquals(true, result);
	}

	/**
	 * Test for ComputerPlayer's roll when computer player is behind human player
	 */
	@Test
	void testShouldReturnTrueWhenComputerPlayerIsBehindInTheGame() {
		boolean result = this.playAdvancedStrategy.rollAgain(1, 5, 30, 3);
		assertEquals(true, result);
	}

	/**
	 * Test for ComputerPlayer's roll when computer player is ahead of human player
	 */
	@Test
	void testShouldReturnFalseWhenComputerPlayerIsAheadInTheGame() {
		boolean result = this.playAdvancedStrategy.rollAgain(1, 5, 3, 30);
		assertEquals(false, result);
	}

	/**
	 * Test for ComputerPlayer's roll when computer player has equal rolls compared
	 * to human player but mean score for the turn is less than 7
	 */
	@Test
	void testShouldReturnTrueWhenPlayerHasEqualRollsLeftComparedToHumanPlayerAndPointsPerRollIsLessThan7() {
		boolean result = this.playAdvancedStrategy.rollAgain(1, 5, 19, 21);
		assertEquals(true, result);
	}

	/**
	 * Test for ComputerPlayer's roll when computer player has equal rolls compared
	 * to human player but mean score for the turn is more than 7
	 */
	@Test
	void testShouldReturnFalseWhenPlayerHasEqualRollsLeftComparedToHumanPlayerAndPointsPerRollIsMoreThan7() {
		boolean result = this.playAdvancedStrategy.rollAgain(1, 9, 19, 21);
		assertEquals(false, result);
	}

}
