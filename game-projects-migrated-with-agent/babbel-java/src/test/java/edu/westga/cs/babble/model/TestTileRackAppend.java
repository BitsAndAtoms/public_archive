package edu.westga.cs.babble.model;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

class TestTileRackAppend {
	private TileRack newTileRack;

	/**
	 * sets up a new tile rack
	 * 
	 * @throws Exception
	 *             if tile rack
	 */
	@BeforeEach
	public void setUp() throws Exception {
		this.newTileRack = new TileRack();
	}

	@Test
	public void shouldNotAppendToFullRack() {
		int tilesNeeded = this.newTileRack.getNumberOfTilesNeeded();
		for (int count = 1; count <= tilesNeeded; count++) {
			this.newTileRack.append(new Tile('a'));
		}
		assertEquals(this.newTileRack.getNumberOfTilesNeeded(), 0);
		assertThrows(TileRackFullException.class, () -> this.newTileRack.append(new Tile('a')));
	}

}
