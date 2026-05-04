##
# This is the parent class TileGroup of the TileRack and Word Classes
# It embodies group of tiles

class TileGroup

  
  ## attr accessor to return the tiles
  #
  def tiles
    return @arrayOfTiles
  end

  ##
  # Array used to store tiles
  def initialize
    @arrayOfTiles = Array.new
  end

  ##
  # append method adds a tile as symbol to the group
  def append(tile)
    @arrayOfTiles.push(tile)
  end

  ##
  # remvoes a single tile from the TileGroup
  # checks if the array contains the tile
  def remove(tile)
    if(@arrayOfTiles.find_index(tile) != nil)
      @arrayOfTiles.delete_at(@arrayOfTiles.find_index(tile))
    end
  end

  ##
  # returns a string representation of the tile group array
  def hand
    return @arrayOfTiles.join
  end


end



