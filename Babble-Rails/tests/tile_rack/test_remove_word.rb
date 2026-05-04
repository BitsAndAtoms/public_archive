# filename: test_remove_word.rb
require "minitest/autorun"
require_relative "../../tile_rack.rb"


##
# tests remove_word  method
class TestTestHasTilesFor  < Minitest::Test

    # instantiating a new tile rack
    # like an @Before in JUnit4
    def setup
        @newTileRack = TileRack.new
    end
    
    # unit tests for the TileRack:: remove_word  method
    def test_can_remove_a_word_whose_letters_are_in_order_on_the_rack
      [:A,:B,:C,:D].each{|x| @newTileRack.append(x)}
      assert_equal([:A,:B,:D],@newTileRack.remove_word('ABD').tiles)
      assert_equal([:C],@newTileRack.tiles)
    end

     # unit tests for the TileRack:: remove_word  method
    def test_can_remove_a_word_whose_letters_are_not_in_order_on_the_rack
       [:A,:B,:C,:D].each{|x| @newTileRack.append(x)}
      assert_equal([:D,:A,:C],@newTileRack.remove_word('DAC').tiles)
      assert_equal([:B],@newTileRack.tiles)
    end

    # unit tests for the TileRack:: remove_word  method
    def test_can_remove_word_with_duplicate_letters
      [:A,:A,:A,:B,:B,:C].each{|x| @newTileRack.append(x)}
      assert_equal([:A,:A,:B,:B],@newTileRack.remove_word('AABB').tiles)
      assert_equal([:A,:C],@newTileRack.tiles)
    end
    
    # unit tests for the TileRack:: remove_word  method
    def test_can_remove_word_without_removing_unneeded_duplicate_letters
        [:A,:A,:A,:D,:D].each{|x| @newTileRack.append(x)}
      assert_equal([:A,:D],@newTileRack.remove_word('AD').tiles)
      assert_equal([:A,:A,:D],@newTileRack.tiles)
    end
    
end

