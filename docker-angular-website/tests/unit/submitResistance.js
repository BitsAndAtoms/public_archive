describe('MainController#submitResistance', function() {
  beforeEach(module('brackets'));

  var ctrl, scope, service;
  beforeEach(inject(function($controller, $rootScope, _resistanceCalculator_) {
    service = _resistanceCalculator_;
    scope = $rootScope.$new();
    mctrl = $controller('MainController', {
      $scope: scope
    });
  }));

  it('should submit five resistance bands', function() {
    mctrl.resistor = ["Black", "Brown", "Red", "Orange", "Yellow"];
    mctrl.submit();
    expect(mctrl.message).toEqual("Result: 012K-ohm +/-5%");
  });




});
