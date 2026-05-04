# filename: test_has_tiles_for.rb
require "minitest/autorun"
require_relative "../../tile_rack.rb"

##
# tests has_tiles_for? method
class TestTestHasTilesFor  < Minitest::Test

    # instantiating a new tile rack
    # like an @Before in JUnit4
    def setup
        @newTileRack = TileRack.new
    end
    
    # unit tests for the TileRack:: has_tiles_for? method
    def test_rack_has_needed_letters_when_letters_are_in_order_no_duplicates
      [:A,:B,:C,:D].each{|x| @newTileRack.append(x)}
      assert_equal(true,@newTileRack.has_tiles_for?('ABD'))
    end

     # unit tests for the TileRack:: has_tiles_for? method
    def test_rack_has_needed_letters_when_letters_are_not_in_order_no_duplicates
        [:A,:B,:C,:D].each{|x| @newTileRack.append(x)}
      assert_equal(true,@newTileRack.has_tiles_for?('DAC'))
    end

  # unit tests for the TileRack:: has_tiles_for? method
    def test_rack_doesnt_contain_any_needed_letters
        [:A,:B,:C,:D].each{|x| @newTileRack.append(x)}
      assert_equal(false,@newTileRack.has_tiles_for?('IKL'))
    end
    
    # unit tests for the TileRack:: has_tiles_for? method
    def test_rack_contains_some_but_not_all_needed_letters
        [:A,:B,:C,:D].each{|x| @newTileRack.append(x)}
      assert_equal(false,@newTileRack.has_tiles_for?('IABJ'))
    end

      # unit tests for the TileRack:: has_tiles_for? method
    def test_rack_contains_a_word_with_duplicate_letters
       [:A,:B,:A,:C].each{|x| @newTileRack.append(x)}
      assert_equal(true,@newTileRack.has_tiles_for?('AAB'))
    end

    # unit tests for the TileRack:: has_tiles_for? method
    def test_rack_doesnt_contain_enough_duplicate_letters
      [:A,:B,:A,:C].each{|x| @newTileRack.append(x)}
      assert_equal(false,@newTileRack.has_tiles_for?('AAAA'))
    end
    
end

