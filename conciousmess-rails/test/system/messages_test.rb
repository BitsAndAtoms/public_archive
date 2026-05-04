require "application_system_test_case"

class MessagesTest < ApplicationSystemTestCase
  setup do
    @message = messages(:one)
  end

  test "visiting the index" do
  sleep 1
    visit messages_url
   
  end

  test "creating a Message" do
  sleep 2
    visit messages_url
    click_on "New Ripple"
    sleep 1
    fill_in "name", with: @message.name
    fill_in "description", with: @message.description
    fill_in "Web url", with: @message.web_url
    click_on "Create Ripple"

    assert_text "Message was successfully created"
    click_on "Back"
  end
  
    test "moves forward and then to newest" do

    visit messages_url
    click_on "Next 10 Ripples"
    click_on "Next 10 Ripples"
    click_on "Next 10 Ripples"
     click_on "Newest"
      visit messages_url
    fill_in "name", with: @message.name
    fill_in "description", with: @message.description
    fill_in "Web url", with: @message.web_url
    click_on "Create Ripple"
  end
  
  

 

end
