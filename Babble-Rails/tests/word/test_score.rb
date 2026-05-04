# filename: test_score.rb
require "minitest/autorun"
require_relative "../../Word.rb"

##
# tests the initialize method
class TestScore  < Minitest::Test
    # instantiating a new tile group
    # like an @Before in JUnit4
    def setup
        @newTileGroup = Word.new
    end

    # unit tests for the TileGroup : score method
    def test_empty_word_should_have_score_of_zero
      assert_equal(0,@newTileGroup.score)
    end

    # unit tests for the TileGroup : score method
    def test_score_a_one_tile_word
      @newTileGroup.append(:D)
      assert_equal(2,@newTileGroup.score)
    end

    # unit tests for the TileGroup : score method
    def test_score_a_word_with_multiple_different_tiles
      [:A,:A,:Z].each{|num| @newTileGroup.append(num)}
      assert_equal(12,@newTileGroup.score)
    end

    # unit tests for the TileGroup : score method
    def test_score_a_word_with_recurring_tiles
      10.times{|num| @newTileGroup.append(:A)}
      assert_equal(10,@newTileGroup.score)
    end


end
