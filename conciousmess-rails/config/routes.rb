Rails.application.routes.draw do
  resources :messages
  post 'messages/next_set'
  post 'messages/previous_set'
  post 'messages/newest'
  post 'messages/oldest'
  # For details on the DSL available within this file, see http://guides.rubyonrails.org/routing.html 
end
