##
# TileRack is the child class of the TileGroup class
# via inheritance

require_relative "tile_group.rb"
require_relative "tile_bag.rb"
require_relative "Word.rb"
class TileRack < TileGroup

## subclass constructor
 def initialize
    super
 end

##
  # this method returns the number of tiles needed to fill the 
  # rack to upto 7 tiles
  def number_of_tiles_needed
    return 7-self.tiles.length
  end
  
  ##
  # this method returns true if rack has enough
  #letters to make the input text parameter 
  # since only 7 letters are stored at a time this may be acceptable
  # if -loop provides speed improvement for rogue(long) inputs
  def has_tiles_for?(text)
    array = text.upcase.split("")
    if(array.length<=self.hand.length)
      self.hand.split("").each{|x| i =array.index(x); array.delete_at(i) if i}
       array.empty?
    else 
      return false
    end 
  end

  ##
  # method to remove text from tile rack and making a Word
  # Word is returned
  def remove_word(text)
    wordObject = Word.new
    if(self.has_tiles_for?(text))
      text.upcase.split("").each{|x| i =@arrayOfTiles.index(x.to_sym);
        @arrayOfTiles.delete_at(i);wordObject.append(x.to_sym) }
    end
    wordObject
  end
  
end

