var helper = require("./helper.js");

describe('Succeess scenario from loading to tournament complete', function() {
  it('should complete a tournament successfully with 8 players', function() { // Open the list of teams page browser . get ( '/' );
    helper.openMainPage();
    expect((element(by.id('welcome'))).getText()).toEqual('Welcome');
    helper.clickLinkById('registrationLink');
    expect((element(by.id('registrationHeading'))).getText()).toEqual('Register Players');
    contestants = ['Beethoven', 'Mozart', 'Tchaikovsky', 'Kalidas', 'Frost', 'Shelly', 'Yeats', 'Rachmanioff'];

    for (i = 0; i < 8; i++) {
      var index = i + 1;
      helper.populateFieldById(contestants[i], 'Contestant_' + "" + index);
    }
    helper.clickLinkById('submitRosterButton');

    expect(element.all(by.tagName('input')).getAttribute('value')).toEqual(['Beethoven', 'Mozart', 'Tchaikovsky', 'Kalidas', 'Frost', 'Shelly', 'Yeats', 'Rachmanioff']);
    //  element.all(by.tagName('input')).getAttribute('value').then(function(text) {
    //  console.log(text);
    //});
    helper.clickLinkById('tournamentLink');
    expect((element(by.id('tournamentHeading'))).getText()).toEqual('Tournament');

    expect((element(by.id('round'))).getText()).toEqual('Round 1');
    helper.clickLinkById('player0_0');
    helper.clickLinkById('player1_1');
    helper.clickLinkById('player1_2');
    helper.clickLinkById('player0_3');
    helper.clickLinkById('completeThisRoundButton');

    expect((element(by.id('round'))).getText()).toEqual('Round 2');
    expect(element.all(by.tagName('input')).getAttribute('value')).toEqual(['Beethoven', 'Kalidas', 'Shelly', 'Yeats']);
    helper.clickLinkById('player0_0');
    helper.clickLinkById('player0_1');
    helper.clickLinkById('completeThisRoundButton');

    expect((element(by.id('round'))).getText()).toEqual('Round 3');
    expect(element.all(by.tagName('input')).getAttribute('value')).toEqual(['Beethoven', 'Shelly']);
    helper.clickLinkById('player0_0');
    helper.clickLinkById('completeThisRoundButton');
    expect(element(by.id('winner')).getText()).toEqual('Winner: Beethoven');

  });
});
