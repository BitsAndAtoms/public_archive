var helper = require("./helper.js");



describe('Succeess scenario from loading to tournament complete', function() {
  it('should complete a tournament successfully with 2 players', function() { // Open the list of teams page browser . get ( '/' );
    helper.openMainPage();
    expect((element(by.id('welcome'))).getText()).toEqual('Welcome');
    helper.clickLinkById('registrationLink');
    expect((element(by.id('registrationHeading'))).getText()).toEqual('Register Players');
    contestants = ['Jobs', 'Gates'];
    for (i = 0; i < 2; i++) {
      var index = i + 1;
      helper.populateFieldById(contestants[i], 'Contestant_' + "" + index);
    }
    helper.clickLinkById('submitRosterButton');
    expect(element.all(by.tagName('input')).getAttribute('value')).toEqual(['Jobs', 'Gates', '', '', '', '', '', '']);
    helper.clickLinkById('tournamentLink');
    expect((element(by.id('tournamentHeading'))).getText()).toEqual('Tournament');
    expect(element.all(by.tagName('input')).getAttribute('value')).toEqual(['Jobs', 'Gates']);
    expect((element(by.id('round'))).getText()).toEqual('Round 1');
    helper.clickLinkById('player0_0');
    helper.clickLinkById('completeThisRoundButton');
    expect(element(by.id('winner')).getText()).toEqual('Winner: Jobs');

  });
});
