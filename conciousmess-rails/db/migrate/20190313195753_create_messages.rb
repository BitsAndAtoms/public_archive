class CreateMessages < ActiveRecord::Migration[5.2]
  def change
    create_table :messages do |t|
      t.string :name
      t.text :description
      t.string :web_url

      t.timestamps
    end
  end
end
