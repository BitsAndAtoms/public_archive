json.extract! message, :id, :name, :description, :web_url, :created_at, :updated_at
json.url message_url(message, format: :json)
