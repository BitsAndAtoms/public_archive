# filename: test_remove.rb
require "minitest/autorun"
require_relative "../../tile_group.rb"

##
# tests the remove method
class TestRemove  < Minitest::Test
    # instantiating a new tile group
    # like an @Before in JUnit4
    def setup
        @newTileGroup = TileGroup.new
    end

    # unit tests for the TileGroup:: remove method
    def test_remove_only_tile
      assert true,@newTileGroup.tiles.empty?
      @newTileGroup.append(:A)
      assert_equal([:A],@newTileGroup.tiles)
      @newTileGroup.remove(:A)
      assert true,@newTileGroup.tiles.empty?
    end

    # unit tests for the TileGroup:: remove  method
    def test_remove_first_tile_from_many
      assert true,@newTileGroup.tiles.empty?
      [:A,:B,:A,:Z,:A].each{|num| @newTileGroup.append(num)}
      assert_equal([:A,:B,:A,:Z,:A],@newTileGroup.tiles)
      @newTileGroup.remove(:A)
      assert_equal([:B,:A,:Z,:A],@newTileGroup.tiles)
    end
    
    # unit tests for the TileGroup:: remove method
    def test_remove_last_tile_from_many
      assert true,@newTileGroup.tiles.empty?
      [:A,:A,:Z].each{|num| @newTileGroup.append(num)}
      assert_equal( [:A,:A,:Z],@newTileGroup.tiles)
      @newTileGroup.remove(:Z)
      assert_equal([:A,:A],@newTileGroup.tiles)
    end
    
    # unit tests for the TileGroup:: remove method
    def test_remove_middle_tile_from_many
      assert true,@newTileGroup.tiles.empty?
      [:A,:A,:Z,:A,:B].each{|num| @newTileGroup.append(num)}
      assert_equal([:A,:A,:Z,:A,:B],@newTileGroup.tiles)
      @newTileGroup.remove(:Z)
      assert_equal([:A,:A,:A,:B],@newTileGroup.tiles)
    end
    
    # unit tests for the TileGroup:: remove method
    def test_remove_multiple_tiles
      assert true,@newTileGroup.tiles.empty?
      10.times{|num| @newTileGroup.append(:A)}
      4.times{|num| @newTileGroup.remove(:A)}
      assert_equal(Array.new(6,:A),@newTileGroup.tiles)
    end

    # unit tests for the TileGroup:: remove method
    def test_make_sure_duplicates_are_not_removed
      assert true,@newTileGroup.tiles.empty?
      [:A,:A,:B,:B,:Z,:Z,:Z,:F].each{|num| @newTileGroup.append(num)}
      [:A,:B,:Z].each{|num| @newTileGroup.remove(num.to_sym)}
      assert_equal([:A,:B,:Z,:Z,:F],@newTileGroup.tiles)
    end



end
