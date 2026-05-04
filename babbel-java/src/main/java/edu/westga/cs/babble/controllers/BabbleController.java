package edu.westga.cs.babble.controllers;

import javafx.scene.control.Alert;
import javafx.scene.control.ListCell;
import javafx.scene.control.ListView;
import javafx.scene.control.SelectionMode;
import edu.westga.cs.babble.model.EmptyTileBagException;
import edu.westga.cs.babble.model.PlayedWord;
import edu.westga.cs.babble.model.Tile;
import edu.westga.cs.babble.model.TileBag;
import edu.westga.cs.babble.model.TileNotInGroupException;
import edu.westga.cs.babble.model.TileRack;
import javafx.beans.property.IntegerProperty;
import javafx.beans.property.SimpleIntegerProperty;
import javafx.collections.FXCollections;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.TextField;
import javafx.scene.input.MouseEvent;
import javafx.util.Callback;

/**
 * This is the GUI controller for the babble application
 * 
 * @author Siddhartha Gupta
 * @version 8/30/2018
 *
 */
public class BabbleController {

	private TileBag tileBagNew;
	private TileRack optionsTileRack;
	private TileRack selectedTileRack;
	private WordDictionary newWord;
	private PlayedWord newPlayedWord;
	private IntegerProperty score;

	@FXML
	private TextField result;

	@FXML
	private ListView<Tile> listView1 = new ListView<Tile>(FXCollections.observableArrayList());

	@FXML
	private ListView<Tile> listView2 = new ListView<Tile>(FXCollections.observableArrayList());

	/**
	 * Method to initalize the FXML based GUI
	 */
	@FXML
	public void initialize() {
		this.tileBagNew = new TileBag();
		this.optionsTileRack = new TileRack();
		this.selectedTileRack = new TileRack();
		this.newWord = new WordDictionary();
		this.newPlayedWord = new PlayedWord();
		this.score = new SimpleIntegerProperty(0);
		this.result.textProperty().bind(this.score.asString());
		this.populateOptionsList();
		this.setUpListView(this.listView1);
		this.setUpListView(this.listView2);
		this.listView1.setItems(this.optionsTileRack.tiles());
		this.listView1.getSelectionModel().setSelectionMode(SelectionMode.SINGLE);
		this.listView2.getSelectionModel().setSelectionMode(SelectionMode.SINGLE);
	}

	/**
	 * Method to play a word and update the score along with refreshing the tiles
	 * for selection
	 * 
	 * @param event
	 *            mouse click
	 */
	@FXML
	public void playWord(ActionEvent event) {
		if (this.newWord.isValidWord(this.selectedTileRack.getHand())) {
			for (Object tile : this.listView2.getItems()) {
				this.newPlayedWord.append((Tile) tile);
			}
		} else {
			this.displayInvaliWordPrompt("Not a valid word");
		}
		if (this.newPlayedWord.matches(this.selectedTileRack.getHand())) {
			this.score.set(this.newPlayedWord.getScore() + this.score.get());
			this.selectedTileRack.tiles().clear();
			this.listView2.setItems(this.selectedTileRack.tiles());

			for (int count = 0; count < this.optionsTileRack.getNumberOfTilesNeeded(); count++) {
				try {
					this.optionsTileRack.append(this.tileBagNew.drawTile());
				} catch (EmptyTileBagException ex) {
					this.displayInvaliWordPrompt(
							"Tile bag is empty. Continue playing with remaining tiles or exit with final score.");
				}
			}
			this.listView1.setItems(this.optionsTileRack.tiles());
		}
		this.newPlayedWord.clear();
	}

	/**
	 * The "Reset" button moves all tiles from the "Your Word" area back to the
	 * "Tiles" area.
	 * 
	 * @param event
	 *            on mouse click
	 */
	@FXML
	void reset(ActionEvent event) {
		this.optionsTileRack.tiles().addAll(this.listView2.getItems());
		this.selectedTileRack.tiles().clear();
		this.listView1.setItems(this.optionsTileRack.tiles());
		this.listView2.setItems(this.selectedTileRack.tiles());
	}

	/**
	 * on click, the tile is moved from the clicked list to the other list
	 * 
	 * @param event
	 *            on mouse click
	 * @throws TileNotInGroupException
	 *             if no tiles are left then tiles can not be removed
	 */
	@FXML
	public void list1click(MouseEvent event) throws TileNotInGroupException {
		if (this.listView1.getSelectionModel().getSelectedItem() != null) {
			this.selectedTileRack.append(((Tile) (this.listView1.getSelectionModel().getSelectedItem())));
			this.optionsTileRack.remove(((Tile) (this.listView1.getSelectionModel().getSelectedItem())));
			this.listView1.setItems(this.optionsTileRack.tiles());
			this.listView2.setItems(this.selectedTileRack.tiles());
		}
	}

	/**
	 * on click, the tile is moved from the clicked list to the other list
	 * 
	 * @param event
	 *            on mouse click
	 * @throws TileNotInGroupException
	 *             if no tiles are left then tiles can not be removed
	 */
	@FXML
	public void list2click(MouseEvent event) throws TileNotInGroupException {
		if (this.listView2.getSelectionModel().getSelectedItem() != null) {
			this.optionsTileRack.append(((Tile) (this.listView2.getSelectionModel().getSelectedItem())));
			this.selectedTileRack.remove(((Tile) (this.listView2.getSelectionModel().getSelectedItem())));
			this.listView2.setItems(this.selectedTileRack.tiles());
			this.listView1.setItems(this.optionsTileRack.tiles());
		}
	}

	/**
	 * populates options list
	 */
	private void populateOptionsList() {
		for (int count = 0; count < TileRack.MAX_SIZE; count++) {
			try {
				this.optionsTileRack.append(this.tileBagNew.drawTile());
			} catch (EmptyTileBagException ex) {
			}
		}
	}

	/**
	 * method to display invalid word
	 */
	private void displayInvaliWordPrompt(String string) {
		Alert alert = new Alert(Alert.AlertType.INFORMATION);
		alert.setTitle("Messsage");
		alert.setHeaderText("Message");
		alert.setContentText(string);
		alert.showAndWait();
	}

	/**
	 * sets up list view to accept objects instead of strings
	 */
	private void setUpListView(ListView<Tile> listView) {
		listView.setCellFactory(new Callback<ListView<Tile>, ListCell<Tile>>() {
			@Override
			public ListCell<Tile> call(ListView<Tile> param) {
				ListCell<Tile> cell = new ListCell<Tile>() {
					@Override
					protected void updateItem(Tile tile, boolean bln) {
						super.updateItem(tile, bln);
						if (bln || tile == null) {
							setText("");
						} else {
							setText(tile.getLetter() + "");
						}
					}
				};
				return cell;
			}
		});
	}
}