package edu.westga.cs.babble.model;

import static org.junit.Assert.assertTrue;
import static org.junit.Assert.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

/**
 * Test to check append for tile group
 * 
 * @author Siddhartha Gupa
 * @version 08/29/2018
 */
public class TestTileGroupAppend extends TileGroup {

	private TileGroup newTileGroup;

	/**
	 * method to set up tile group
	 */
	@BeforeEach
	public void setUp() {
		this.newTileGroup = new TileGroup() {

		};
	}

	/**
	 * can not allow null to be added to tile group
	 */
	@Test
	public void shouldNotAllowNull() {
		assertThrows(IllegalArgumentException.class, () -> this.newTileGroup.append(null));
	}

	/**
	 * empty group is empty
	 */
	@Test
	public void emptyGroupShouldBeEmpty() {
		String emptyString = this.newTileGroup.getHand();
		assertEquals(this.newTileGroup.getHand(), "");
		assertTrue(emptyString.equals(""));
	}

	/**
	 * has single tile in the group
	 */
	@Test
	public void shouldHaveOneTileInTileGroup() {
		this.newTileGroup.append(new Tile('C'));
		assertEquals("C", this.newTileGroup.getHand());
	}

	/**
	 * has many tiles in the group
	 */
	@Test
	public void shouldHaveManyTileInTileGroup() {
		this.newTileGroup.append(new Tile('C'));
		this.newTileGroup.append(new Tile('D'));
		this.newTileGroup.append(new Tile('D'));
		this.newTileGroup.append(new Tile('a'));
		this.newTileGroup.append(new Tile('f'));
		this.newTileGroup.append(new Tile('Z'));
		assertEquals(this.newTileGroup.getHand(), "CDDAFZ");

	}

	/**
	 * has many tiles in the group including duplicates
	 */
	@Test
	public void shouldHaveManyTilesIncludingDuplicatesInTileGroup() {
		this.newTileGroup.append(new Tile('C'));
		this.newTileGroup.append(new Tile('D'));
		this.newTileGroup.append(new Tile('D'));
		this.newTileGroup.append(new Tile('a'));
		this.newTileGroup.append(new Tile('f'));
		this.newTileGroup.append(new Tile('Z'));
		this.newTileGroup.append(new Tile('C'));
		this.newTileGroup.append(new Tile('D'));
		this.newTileGroup.append(new Tile('D'));
		this.newTileGroup.append(new Tile('a'));
		this.newTileGroup.append(new Tile('f'));
		this.newTileGroup.append(new Tile('Z'));
		this.newTileGroup.append(new Tile('C'));
		this.newTileGroup.append(new Tile('D'));
		this.newTileGroup.append(new Tile('D'));
		this.newTileGroup.append(new Tile('a'));
		this.newTileGroup.append(new Tile('f'));
		this.newTileGroup.append(new Tile('Z'));
		assertEquals(this.newTileGroup.getHand(), "CDDAFZCDDAFZCDDAFZ");
	}

	/**
	 * can not add same tile twice
	 */
	@Test
	public void canNotAddSameTileTwice() {
		Tile newTile = new Tile('C');
		this.newTileGroup.append(newTile);
		assertEquals(this.newTileGroup.getHand(), "C");
		assertThrows(IllegalArgumentException.class, () -> this.newTileGroup.append(newTile));
	}

}
