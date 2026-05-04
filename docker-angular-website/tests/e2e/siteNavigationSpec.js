var helper = require("./helper.js");


describe('Succeess scenario from selecting bands to calculating resistance', function() {
  it('should calculate resistance successfully from submitted options', function() { // Open the list of teams page browser . get ( '/' );
    helper.openMainPage();
    expect((element(by.id('welcome'))).getText()).toEqual('Resistor Color Code Calculator');
    element.all(by.tagName('select')).get(0).sendKeys('Red');
    element.all(by.tagName('select')).get(1).sendKeys('Blue');
    element.all(by.tagName('select')).get(2).sendKeys('Yellow');
    element.all(by.tagName('select')).get(3).sendKeys('Orange');
    element.all(by.tagName('select')).get(4).sendKeys('Violet');
    helper.clickLinkById('submitNow');
    expect((element(by.id('finalResult'))).getText()).toEqual("Result: 264K-ohm +/-0.1%");


  });
});

describe('Succeess scenario from submitting default options', function() {
  it('should calcuate resistance from default options shown', function() { // Open the list of teams page browser . get ( '/' );
    helper.openMainPage();
    expect((element(by.id('welcome'))).getText()).toEqual('Resistor Color Code Calculator');
    helper.clickLinkById('submitNow');
    expect((element(by.id('finalResult'))).getText()).toEqual("Result: 012K-ohm +/-5%");


  });
});
