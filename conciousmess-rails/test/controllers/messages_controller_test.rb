require 'test_helper'

class MessagesControllerTest < ActionDispatch::IntegrationTest
  setup do
    @message = messages(:one)
  end

  test "should get index" do
    get messages_url
    assert_response :success
  end

  test "should get new" do
    get new_message_url
    assert_response :success
  end

  test "should create message" do
    assert_difference('Message.count') do
      post messages_url, params: { message: { description: @message.description, name: @message.name, web_url: @message.web_url } }
    end

    assert_redirected_to messages_url
  end

  test "should show message" do
    get message_url(@message)
    assert_response :success
  end

  

  test "should update message" do
    patch message_url(@message), params: { message: { description: @message.description, name: @message.name, web_url: @message.web_url } }
    assert_redirected_to message_url(@message)
  end

  

   
end
