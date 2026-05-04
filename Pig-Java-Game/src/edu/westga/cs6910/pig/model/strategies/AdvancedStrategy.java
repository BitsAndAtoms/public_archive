package edu.westga.cs6910.pig.model.strategies;

/**
 * Creates an advanced play strategy for the game Pig that implements PigStrategy
 * 
 * @author Siddhartha Gupta
 * @version 7/10/2018
 *
 */
public class AdvancedStrategy implements PigStrategy {

	/**
	 * Method to decide whether to roll again based on advanced strategy
	 */
	@Override
	public boolean rollAgain(int numberOfRollsSoFar, int pointsSoFarThisTurn, int pointsToGoal,
			int opponentPointsToGoal) {
		if (pointsToGoal <= 0 || opponentPointsToGoal <= 0) {
			return false;
		} else if (opponentPointsToGoal <= 7) {
			return true;
		} else if (Math.ceil(opponentPointsToGoal / 7.0) > Math.ceil(pointsToGoal / 7.0)) {
			return false;
		} else if (Math.ceil(opponentPointsToGoal / 7.0) < Math.ceil(pointsToGoal / 7.0)) {
			return true;
		} else if (Math.ceil(opponentPointsToGoal / 7.0) == Math.ceil(pointsToGoal / 7.0) && numberOfRollsSoFar != 0) {
			return ((double) pointsSoFarThisTurn / numberOfRollsSoFar < 7);
		}
		return true;
	}

}
