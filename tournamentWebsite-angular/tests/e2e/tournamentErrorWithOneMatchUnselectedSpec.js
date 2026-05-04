var helper = require("./helper.js");

describe('Error is displayed on tournament page', function() {
  it('should complete a tournament successfully', function() { // Open the list of teams page browser . get ( '/' );
    helper.openMainPage();
    helper.clickLinkById('registrationLink');
    contestants = ['Hercules', 'Troy', 'Hector', 'Janus'];
    for (i = 0; i < 4; i++) {
      var index = i + 1;
      helper.populateFieldById(contestants[i], 'Contestant_' + "" + index);
    }
    helper.clickLinkById('submitRosterButton');
    helper.clickLinkById('tournamentLink');
    helper.clickLinkById('player0_1');
    helper.clickLinkById('completeThisRoundButton');
    expect(element(by.id('error')).getText()).toEqual('Please select a winner for every match.');
  });
});
