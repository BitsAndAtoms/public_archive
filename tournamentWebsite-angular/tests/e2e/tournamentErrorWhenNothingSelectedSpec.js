var helper = require("./helper.js");


describe('Error on registration page when submitted without selecting form each match', function() {
  it('should select a winner for each match', function() { // Open the list of teams page browser . get ( '/' );
    helper.openMainPage();
    helper.clickLinkById('registrationLink');
    contestants = ['Hercules', 'Troy', 'Hector', 'Janus'];
    for (i = 0; i < 4; i++) {
      var index = i + 1;
      helper.populateFieldById(contestants[i], 'Contestant_' + "" + index);
    }
    helper.clickLinkById('submitRosterButton');
    helper.clickLinkById('tournamentLink');
    helper.clickLinkById('completeThisRoundButton');
    expect(element(by.id('error')).getText()).toEqual('Please select a winner for every match.');
  });
});
