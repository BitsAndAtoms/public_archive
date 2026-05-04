var helper = require("./helper.js");



describe('Error on registration page', function() {
  it('displays error when duplicate players are submitted', function() { // Open the list of teams page browser . get ( '/' );
    helper.openMainPage();
    helper.clickLinkById('registrationLink');
    contestants = ['Beethoven', 'Mozart', 'Shelly', 'Shelly'];
    for (i = 0; i < 4; i++) {
      var index = i + 1;
      helper.populateFieldById(contestants[i], 'Contestant_' + "" + index);
    }
    helper.clickLinkById('submitRosterButton');
    expect(element(by.id('error')).getText()).toEqual('Duplicate name(s) not allowed');
  });
});
