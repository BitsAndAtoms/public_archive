# filename: test_point_for.rb
require "minitest/autorun"

require_relative "../../tile_bag.rb"
class TestPointsForInitialize < Minitest::Test
    # instantiating a new tile bag
    # like an @Before in JUnit4
    def setup
        @newTileBag = TileBag.new
    end

    # unit tests for the TileBag:: points_for method
    def test_confirm_point_values
[:A,:E,:I,:O,:N,:R,:T,:L,:S,:U].each{|num| assert_equal 1, TileBag.points_for(num.to_sym)}

[:D,:G].each{|num| assert_equal 2, TileBag.points_for(num.to_sym)}
[:B,:C,:M,:P].each{|num| assert_equal 3, TileBag.points_for(num.to_sym)}
[:F,:H,:V,:W,:Y].each{|num| assert_equal 4, TileBag.points_for(num.to_sym)}
[:K].each{|num| assert_equal 5, TileBag.points_for(num.to_sym)}   
[:J,:X].each{|num| assert_equal 8, TileBag.points_for(num.to_sym)}   
[:Q,:Z].each{|num| assert_equal 10, TileBag.points_for(num.to_sym)}   
    end
end

