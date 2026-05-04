package edu.westga.cs.babble.model;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

/**
 * class to test tile rack class methods
 * 
 * @author Siddhartha Gupta
 * @version 8/31/2018
 *
 */
public class TestTileRackGetNumberOfTilesNeeded {
	private TileRack newTileRack;

	/**
	 * sets up a new tile rack
	 * 
	 * @throws Exception
	 *             if size of rack is full
	 */
	@BeforeEach
	public void setUp() throws Exception {
		this.newTileRack = new TileRack();
	}

	/**
	 * empty tile rack must need 7 tiles
	 */
	@Test
	public void emptyTileRackShouldNeedMaxSizeNumberOfTiles() {
		assertEquals(this.newTileRack.getHand(), "");
		assertEquals(this.newTileRack.getNumberOfTilesNeeded(), TileRack.MAX_SIZE);
	}

	/**
	 * Rack with one tile needs 6 more tiles
	 */
	@Test
	public void tileRackWithOneTileShouldNeedMaxSizeMinusOneTiles() {
		this.newTileRack.append(new Tile('a'));
		assertEquals(this.newTileRack.getHand(), "A");
		assertEquals(this.newTileRack.getNumberOfTilesNeeded(), TileRack.MAX_SIZE - 1);
	}

	/**
	 * Rack with several tiles needs few tiles
	 */
	@Test
	public void tileRackWithSeveralTilesShouldNeedSomeTiles() {
		this.newTileRack.append(new Tile('a'));
		this.newTileRack.append(new Tile('V'));
		this.newTileRack.append(new Tile('L'));
		this.newTileRack.append(new Tile('X'));
		assertEquals(this.newTileRack.getHand(), "AVLX");
		assertEquals(this.newTileRack.getNumberOfTilesNeeded(), TileRack.MAX_SIZE - 4);
	}

	/**
	 * Full Rack needs 0 tiles
	 */
	@Test
	void fullRackNeedsZeroTiles() {
		for (int count = 1; count <= TileRack.MAX_SIZE; count++) {
			this.newTileRack.append(new Tile('a'));
		}
		assertEquals(this.newTileRack.getNumberOfTilesNeeded(), 0);
		assertThrows(TileRackFullException.class, () -> this.newTileRack.append(new Tile('a')));
	}

}
