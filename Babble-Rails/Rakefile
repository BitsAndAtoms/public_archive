require 'rake/testtask'

Rake::TestTask.new do |t|
    t.pattern = "tests/*/test_*.rb"
end

require 'rdoc/task'
RDoc::Task.new do |rdoc|
rdoc.rdoc_files.include("*.rb")
end

task :babble do |t|
  ruby "babble.rb"
end


