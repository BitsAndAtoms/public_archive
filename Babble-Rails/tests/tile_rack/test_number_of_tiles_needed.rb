# filename: test_number_of_tiles_needed.rb
require "minitest/autorun"
require_relative "../../tile_rack.rb"

##
# tests the number_of_tiles_needed method
class TestNumberOfTilesNeeded  < Minitest::Test

    # instantiating a new tile rack
    # like an @Before in JUnit4
    def setup
        @newTileRack = TileRack.new
    end

    # unit tests for the TileRack:: number_of_tiles_needed method
    def test_empty_tile_rack_should_need_max_tiles
        assert_equal(7,@newTileRack.number_of_tiles_needed)
    end


    # unit tests for the TileRack:: number_of_tiles_needed method
    def test_tile_rack_with_one_tile_should_need_max_minus_one_tiles
       @newTileRack.append(:A)
      assert_equal(6,@newTileRack.number_of_tiles_needed)
    end
    
     # unit tests for the TileRack:: number_of_tiles_needed method
    def test_tile_rack_with_several_tiles_should_need_some_tiles
       [:A,:B,:C].each{|x| @newTileRack.append(x)}
      assert_equal(4,@newTileRack.number_of_tiles_needed)
    end

    # unit tests for the TileRack:: number_of_tiles_needed method
    def test_that_full_tile_rack_doesnt_need_any_tiles
      7.times{|num| @newTileRack.append(:A)}
      assert_equal(0,@newTileRack.number_of_tiles_needed)
    end
    

end

