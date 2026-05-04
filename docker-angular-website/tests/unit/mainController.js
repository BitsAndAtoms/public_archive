describe('Controller: MainController', function() {
  beforeEach(module('brackets'));

  var ctrl, scope;
  beforeEach(inject(function($controller, $rootScope) {
  scope = $rootScope.$new();
    ctrl = $controller('MainController', {
      $scope: scope
    });

  }));


  it('should have message variable msg available', function() {
    expect(scope.msg).toEqual('Resistor Color Code Calculator');
  });



});
