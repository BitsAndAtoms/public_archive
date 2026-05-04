class MessagesController < ApplicationController
 before_action :redirect_user, only: [:edit,:destroy]
  before_action :set_message, only: [:show, :edit, :update, :destroy]
 
  
  # GET /messages
  # GET /messages.json
  def index
   # @messages = Message.all #removed this one to return ordered messages1
   if (session[:current_list_page_number] == nil)
   session[:current_list_page_number] = 0
   end
   if (session[:current_list_page_number] > Message.order("created_at DESC").all.length-1)
   session[:current_list_page_number] =  session[:current_list_page_number]-10
   end
   if (session[:current_list_page_number] < 0)
   session[:current_list_page_number] = 0
   end
   #@messages = Message.order("created_at DESC").all # new one
   @messages = Message.order("created_at DESC")[session[:current_list_page_number]...session[:current_list_page_number]+10]
  end

def redirect_user
  redirect_to messages_url
end

  # GET /messages/1
  # GET /messages/1.json
  def show
  end

  # GET /messages/new
  def new
    @message = Message.new
  end

  # GET /messages/1/edit
  def edit
  end

  # POST /messages
  # POST /messages.json
  def create
    @message = Message.new(message_params)

    respond_to do |format|
      if @message.save
        # commented out since we directly want to go to main page
        #format.html { redirect_to @message, notice: 'Message was successfully created.' }
        #format.json { render :show, status: :created, location: @message }
        session[:current_list_page_number] = 0
        format.html { redirect_to messages_url, notice: 'Message was successfully created.' }
        format.json { head :no_content }
      else
        format.html { render :new }
        format.json { render json: @message.errors, status: :unprocessable_entity }
      end
    end
  end

  # PATCH/PUT /messages/1
  # PATCH/PUT /messages/1.json
  def update
    respond_to do |format|
      if @message.update(message_params)
        format.html { redirect_to @message, notice: 'Message was successfully updated.' }
        format.json { render :show, status: :ok, location: @message }
      else
        format.html { render :edit }
        format.json { render json: @message.errors, status: :unprocessable_entity }
      end
    end
  end

  # DELETE /messages/1
  # DELETE /messages/1.json
  def destroy
    @message.destroy
    respond_to do |format|
      format.html { redirect_to messages_url, notice: 'Message was successfully destroyed.' }
      format.json { head :no_content }
    end
  end
  
  # GET /messages/1
  # GET /messages/1.json
  def next_set
      session[:current_list_page_number] += 10
      respond_to do |format|
      format.html { redirect_to messages_url}
      format.json { head :no_content }
      end
 end
 
   # GET /messages/1
  # GET /messages/1.json
  def newest
      session[:current_list_page_number] = 0
      respond_to do |format|
      format.html { redirect_to messages_url}
      format.json { head :no_content }
      end
 end
 
   # GET /messages/1
  # GET /messages/1.json
  def oldest
      session[:current_list_page_number] = 10*((Message.order("created_at DESC").all.length-1)/10)
      respond_to do |format|
      format.html { redirect_to messages_url}
      format.json { head :no_content }
      end
 end
  
   # go to previous 10 messages
  def previous_set
      session[:current_list_page_number] -= 10
      respond_to do |format|
      format.html { redirect_to messages_url}
      format.json { head :no_content }
      end
    end
  

  private
    # Use callbacks to share common setup or constraints between actions.
    def set_message
      @message = Message.find(params[:id])
    end

    # Never trust parameters from the scary internet, only allow the white list through.
    def message_params
      params.require(:message).permit(:name, :description, :web_url)
    end
end
