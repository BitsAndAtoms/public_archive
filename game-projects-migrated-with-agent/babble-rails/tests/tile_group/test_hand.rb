# filename: test_remove.rb
require "minitest/autorun"
require_relative "../../tile_group.rb"

##
# tests the hand method
class TestHand  < Minitest::Test

    # instantiating a new tile group
    # like an @Before in JUnit4
    def setup
        @newTileGroup = TileGroup.new
    end

    # unit tests for the TileGroup:: hand method
    def test_convert_empty_group_to_string
      assert_equal('',@newTileGroup.hand)
    end

    def test_convert_single_tile_group_to_string
      assert true,@newTileGroup.tiles.empty?
      @newTileGroup.append(:A)
      assert_equal('A',@newTileGroup.hand)

    end

    def test_convert_multi_tile_group_to_string
      assert true,@newTileGroup.tiles.empty?
      [:A,:A,:Z].each{|num| @newTileGroup.append(num)}
      assert_equal("AAZ",@newTileGroup.hand)
    end

    def test_convert_multi_tile_group_with_duplicates_to_string
      assert true,@newTileGroup.tiles.empty?
      10.times{|num| @newTileGroup.append(:A)}
      assert_equal(Array.new(10,'A').join(),@newTileGroup.hand)
    end


end
