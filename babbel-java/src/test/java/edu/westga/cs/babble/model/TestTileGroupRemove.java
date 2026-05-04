package edu.westga.cs.babble.model;

import static org.junit.Assert.assertEquals;
import static org.junit.jupiter.api.Assertions.assertAll;
import static org.junit.jupiter.api.Assertions.assertThrows;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

class TestTileGroupRemove {

	private TileGroup newTileGroup;

	@BeforeEach
	public void setUp() {
		this.newTileGroup = new TileGroup() {
		};
	}

	@Test
	public void shouldNotAllowNull() {
		assertThrows(IllegalArgumentException.class, () -> this.newTileGroup.remove(null));
	}

	@Test
	public void canNotRemoveFromEmptyTileGroup() {
		assertEquals(this.newTileGroup.getHand(), "");
		assertThrows(TileNotInGroupException.class, () -> this.newTileGroup.remove(new Tile('a')));
	}

	@Test
	public void canNotRemoveTileNotInTileGroup() {
		this.newTileGroup.append(new Tile('C'));
		this.newTileGroup.append(new Tile('D'));
		this.newTileGroup.append(new Tile('D'));
		this.newTileGroup.append(new Tile('a'));
		this.newTileGroup.append(new Tile('f'));
		this.newTileGroup.append(new Tile('Z'));
		this.newTileGroup.append(new Tile('C'));
		Tile newTile = new Tile('D');
		this.newTileGroup.append(newTile);
		assertEquals(this.newTileGroup.getHand(), "CDDAFZCD");
		assertThrows(TileNotInGroupException.class, () -> this.newTileGroup.remove(new Tile('C')));
		assertThrows(TileNotInGroupException.class, () -> this.newTileGroup.remove(new Tile('D')));
	}

	@Test
	public void canRemoveOnlyTileInTileGroup() {
		Tile newTile1 = new Tile('A');
		Tile newTile2 = new Tile('b');
		Tile newTile3 = new Tile('e');
		Tile newTile4 = new Tile('G');
		this.newTileGroup.append(newTile1);
		this.newTileGroup.append(newTile2);
		this.newTileGroup.append(newTile3);
		this.newTileGroup.append(newTile4);
		assertEquals(this.newTileGroup.getHand(), "ABEG");
		assertThrows(TileNotInGroupException.class, () -> this.newTileGroup.remove(new Tile('A')));
		assertThrows(TileNotInGroupException.class, () -> this.newTileGroup.remove(new Tile('b')));
		assertThrows(TileNotInGroupException.class, () -> this.newTileGroup.remove(new Tile('e')));
		assertThrows(TileNotInGroupException.class, () -> this.newTileGroup.remove(new Tile('G')));
		assertAll(() -> this.newTileGroup.remove(newTile1));
		assertAll(() -> this.newTileGroup.remove(newTile2));
		assertAll(() -> this.newTileGroup.remove(newTile3));
		assertEquals(this.newTileGroup.getHand(), "G");
		assertAll(() -> this.newTileGroup.remove(newTile4));
	}

	@Test
	public void canRemoveFirstOfManyTilesFromTileGroup() {
		Tile newTile1 = new Tile('A');
		Tile newTile2 = new Tile('b');
		Tile newTile3 = new Tile('e');
		Tile newTile4 = new Tile('G');
		this.newTileGroup.append(newTile1);
		this.newTileGroup.append(newTile2);
		this.newTileGroup.append(newTile3);
		this.newTileGroup.append(newTile4);
		assertEquals(this.newTileGroup.getHand(), "ABEG");
		assertAll(() -> this.newTileGroup.remove(newTile1));
		assertEquals(this.newTileGroup.getHand(), "BEG");
	}

	@Test
	public void canRemoveLastOfManyTilesFromTileGroup() {
		Tile newTile1 = new Tile('A');
		Tile newTile2 = new Tile('b');
		Tile newTile3 = new Tile('e');
		Tile newTile4 = new Tile('G');
		this.newTileGroup.append(newTile1);
		this.newTileGroup.append(newTile2);
		this.newTileGroup.append(newTile3);
		this.newTileGroup.append(newTile4);
		assertEquals(this.newTileGroup.getHand(), "ABEG");
		assertAll(() -> this.newTileGroup.remove(newTile4));
		assertEquals(this.newTileGroup.getHand(), "ABE");
	}

	@Test
	public void canRemoveMiddleOfManyTilesFromTileGroup() {
		Tile newTile1 = new Tile('A');
		Tile newTile2 = new Tile('b');
		Tile newTile3 = new Tile('e');
		Tile newTile4 = new Tile('G');
		Tile newTile5 = new Tile('X');
		this.newTileGroup.append(newTile1);
		this.newTileGroup.append(newTile2);
		this.newTileGroup.append(newTile3);
		this.newTileGroup.append(newTile4);
		this.newTileGroup.append(newTile5);
		assertEquals(this.newTileGroup.getHand(), "ABEGX");
		assertAll(() -> this.newTileGroup.remove(newTile3));
		assertEquals(this.newTileGroup.getHand(), "ABGX");
	}

	@Test
	public void canRemoveMultipleTilesFromTileGroup() {
		Tile newTile1 = new Tile('A');
		Tile newTile2 = new Tile('b');
		Tile newTile3 = new Tile('e');
		Tile newTile4 = new Tile('G');
		Tile newTile5 = new Tile('X');
		this.newTileGroup.append(newTile1);
		this.newTileGroup.append(newTile2);
		this.newTileGroup.append(newTile3);
		this.newTileGroup.append(newTile4);
		this.newTileGroup.append(newTile5);
		assertEquals(this.newTileGroup.getHand(), "ABEGX");
		assertAll(() -> this.newTileGroup.remove(newTile1));
		assertEquals(this.newTileGroup.getHand(), "BEGX");
		assertAll(() -> this.newTileGroup.remove(newTile2));
		assertEquals(this.newTileGroup.getHand(), "EGX");
		assertAll(() -> this.newTileGroup.remove(newTile3));
		assertEquals(this.newTileGroup.getHand(), "GX");
		assertAll(() -> this.newTileGroup.remove(newTile4));
		assertEquals(this.newTileGroup.getHand(), "X");
	}

	@Test
	public void doesNotRemoveDuplicateTilesFromTileGroup() {
		Tile newTile1 = new Tile('A');
		Tile newTile2 = new Tile('O');
		Tile newTile3 = new Tile('A');
		Tile newTile4 = new Tile('B');
		Tile newTile5 = new Tile('X');
		Tile newTile6 = new Tile('O');
		Tile newTile7 = new Tile('X');
		this.newTileGroup.append(newTile1);
		this.newTileGroup.append(newTile2);
		this.newTileGroup.append(newTile3);
		this.newTileGroup.append(newTile4);
		this.newTileGroup.append(newTile5);
		this.newTileGroup.append(newTile6);
		this.newTileGroup.append(newTile7);
		assertEquals(this.newTileGroup.getHand(), "AOABXOX");
		assertAll(() -> this.newTileGroup.remove(newTile1));
		assertEquals(this.newTileGroup.getHand(), "OABXOX");
		assertAll(() -> this.newTileGroup.remove(newTile5));
		assertEquals(this.newTileGroup.getHand(), "OABOX");
	}

}
