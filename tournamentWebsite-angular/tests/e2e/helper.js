var exports = module.exports = {};

exports.openMainPage = function() {
  browser.get('/main.html');
}

exports.populateFieldById = function(text, idName) {
  element.all(by.id(idName)).clear().sendKeys(text);
}

exports.clickLinkById = function(idName) {
  element(by.id(idName)).click();
}

exports.dumpHtml = function() {
  browser.getPageSource().then(function(source) {
    console.log(source);
  });
}
