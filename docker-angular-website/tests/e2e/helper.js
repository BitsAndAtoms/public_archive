var exports = module.exports = {};

exports.openMainPage = function() {
  browser.get('/main.html');
}


exports.dumpHtml = function() {
  browser.getPageSource().then(function(source) {
    console.log(source);
  });
}


exports.clickLinkById = function(idName) {
  element(by.id(idName)).click();
}
