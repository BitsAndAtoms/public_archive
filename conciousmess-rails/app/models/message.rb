class Message < ApplicationRecord
validates :name, :description, presence:true
validates :web_url, allow_blank: true,
            length: { maximum: 245 },
            format: { with: URI.regexp(%w(http https)), message: :'must be a valid url with http or https'}
end
