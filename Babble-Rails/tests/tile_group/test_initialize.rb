# filename: test_initialize.rb

require "minitest/autorun"
require_relative "../../tile_group.rb"

##
# tests the initialize method
class TestInitialize  < Minitest::Test

  # instantiating a new tile group
  # like an @Before in JUnit4
  def setup
    @newTileGroup = TileGroup.new
  end

  # unit tests for the TileGroup:: initialize method
  def test_create_empty_tile_group1
    assert true,@newTileGroup.tiles.empty?
  end
    
end
