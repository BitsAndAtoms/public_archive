# filename: test_draw_tile.rb
require "minitest/autorun"

require_relative "../../tile_bag.rb"
class TestDrawTile < Minitest::Test
    # instantiating a new tile bag
    # like an @Before in JUnit4
    def setup
        @newTileBag = TileBag.new
    end

    # unit tests for the TileBag:: draw_tile method is tested
    # 97 times and returns empty as false
    # after the 98th time it returns empty as true
    def test_has_proper_number_of_tiles
97.times {|num| @newTileBag.draw_tile}
assert_equal false, @newTileBag.empty?
@newTileBag.draw_tile
assert_equal true, @newTileBag.empty?
    end

    # unit tests for the TileBag:: draw_tile method is tested
    # the various tiles drawn from the tile bag are checked
    # for standard distribution
    def test_has_proper_tile_distribution
    counts = Hash.new 0
    98.times{|num| counts[@newTileBag.draw_tile] += 1}
    [:K,:J,:X,:Q,:Z].each{|num| assert_equal 1, counts[num.to_sym]}
    [:B,:C,:M,:P,:F,:H,:V,:W,:Y].each{|num| assert_equal 2, counts[num.to_sym]}
    [:G].each{|num| assert_equal 3, counts[num.to_sym]}
    [:L,:S,:U,:D].each{|num| assert_equal 4, counts[num.to_sym]}
    [:N,:R,:T].each{|num| assert_equal 6, counts[num.to_sym]}
    [:O].each{|num| assert_equal 8, counts[num.to_sym]}
    [:A,:I].each{|num| assert_equal 9, counts[num.to_sym]}
    [:E].each{|num| assert_equal 12, counts[num.to_sym]}
    end
end

