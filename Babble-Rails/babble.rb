require_relative "tile_group.rb"
require_relative "tile_bag.rb"
require_relative "tile_rack.rb"
require_relative "Word.rb"
require 'spellchecker'
require 'tempfile'

##
# babble is the driver class for the babble program
class Babble 

  ##
  #subclass constructor
  def initialize
    @tileBag = TileBag.new
    @tileRack = TileRack.new
    @tileRack.number_of_tiles_needed.times{@tileRack.append(@tileBag.draw_tile())}
    @word = Word.new
    @score = 0
 end
 
      ##
      # The run method for
      # the scrabble application
      # has to run till the rack is empty and not the bag!
      # Game can end with :quit or it can end with empty bag and empty rack!
      def run
        until @tileRack.tiles.length == 0
          
          puts "The letters in the tile rack are: " + @tileRack.hand + "\n\n";
          print "Please guess a word and enter it here: "
          input = gets.chomp
          puts "\n"

          if(input.eql? ":quit")
            puts "Thanks for playing, total score: " + @score.to_s + "\n\n";
            break
          elsif(input.strip.empty? or !Spellchecker::check(input)[0][:correct])
            puts "Not a valid word"
          elsif (!@tileRack.has_tiles_for?(input))
            puts "Not enought tiles"
          else
            @word = @tileRack.remove_word(input)
            puts "You made " + @word.hand + " for " + @word.score.to_s + " points"
            @score = @score + @word.score
            @tileRack.number_of_tiles_needed.times{@tileRack.append(@tileBag.draw_tile) if !@tileBag.empty?}
          end
          puts "The current total score is " + @score.to_s + "\n\n"
        end
        
        if(@tileRack.tiles.length == 0)
          puts "Thanks for playing, total score: " + @score.to_s + "\n\n";
        end

      end

 end

Babble.new.run
