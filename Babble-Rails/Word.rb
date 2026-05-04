##
# Word is the child class of the TileGroup class
# via inheritance

require_relative "tile_group.rb"
require_relative "tile_bag.rb"
class Word < TileGroup

  ## subclass constructor
  def initialize
    super
  end

  ##
  # this class returns the score for the Word object
  # the TileBag class is used to call the points_for method
  # the 0  is injected so that null is not case in case of empty word
  def score
    self.tiles.inject(0){|sum,num| sum+=TileBag.points_for(num)}
  end

end


