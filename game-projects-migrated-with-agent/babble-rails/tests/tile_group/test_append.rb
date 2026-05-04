# filename: test_append.rb
require "minitest/autorun"
require_relative "../../tile_group.rb"

##
# tests the append method
class TestAppend  < Minitest::Test

    # instantiating a new tile group
    # like an @Before in JUnit4
    def setup
        @newTileGroup = TileGroup.new
    end

    # unit tests for the TileGroup:: append method
    def test_append_one_tile
      assert true,@newTileGroup.tiles.empty?
      @newTileGroup.append(:A)
      
      assert_equal([:A],@newTileGroup.tiles)
    end


    # unit tests for the TileGroup:: append method
    def test_append_many_tiles
      assert true,@newTileGroup.tiles.empty?
      [:A,:B,:Z].each{|num| @newTileGroup.append(num.to_sym)}
      assert_equal([:A,:B,:Z],@newTileGroup.tiles)
    end

    # unit tests for the TileGroup:: append metho
    def test_append_duplicate_tiles
      assert true,@newTileGroup.tiles.empty?
      10.times{|num| @newTileGroup.append(:A)}
      assert_equal(Array.new(10,:A),@newTileGroup.tiles)
    end

end
