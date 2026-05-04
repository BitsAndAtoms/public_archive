var helper = require("./helper.js");


describe('Error on registration page', function() {
  it('Throw error when 7 players are submitted', function() { // Open the list of teams page browser . get ( '/' );
    helper.openMainPage();
    helper.clickLinkById('registrationLink');
    contestants = ['Beethoven', 'Mozart', 'Tchaikovsky', 'Kalidas', 'Shelly', 'Rachmanioff'];
    for (i = 0; i < 6; i++) {
      var index = i + 1;
      helper.populateFieldById(contestants[i], 'Contestant_' + "" + index);
    }
    helper.clickLinkById('submitRosterButton');
    expect(element(by.id('error')).getText()).toEqual('Must seed bracket with either 2, 4, or 8 players');
  });
});
