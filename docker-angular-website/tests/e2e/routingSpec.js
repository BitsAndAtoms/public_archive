var helper = require("./helper.js");

describe('Routing Test to navigate to welcome.html', function() {
  it('should take user to welcome page after loading main.html', function() { // Open the list of teams page browser . get ( '/' );
    helper.openMainPage();
    expect((element(by.id('welcome'))).getText()).toEqual('Resistor Color Code Calculator');
  });
});
