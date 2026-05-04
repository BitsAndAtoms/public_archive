describe('Testing Routes', function() {
  // load the controller's module
  beforeEach(module('brackets'));
  it('should test routes',
    inject(function($route) {
      expect($route.routes['/'].controller).toBe('MainController');
      expect($route.routes['/'].templateUrl).toEqual('hello.html');
    }));
});
