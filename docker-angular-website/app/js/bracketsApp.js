var brackets = angular.module('brackets', ['ngRoute']);

/**
 * routing
 */
brackets.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/', {
      templateUrl: 'hello.html',
      controller: 'MainController',
      controllerAs: 'mctrl'
    })
    .otherwise({
      redirectTo: '/'
    });
}]);


brackets.controller('MainController', function($scope, resistanceCalculator) {
  $scope.msg = 'Resistor Color Code Calculator';
  var self = this;

  self.staticOp = ["Black", "Orange", "White", "Brown", "Red", "Yellow",
    "Green", "Blue", "Violet", "Gray"
  ];

  self.resistor = ["Black", "Brown", "Red", "Orange", "Yellow"];
  resistor = {
    "Black": [0, "-ohm", ""],
    "Brown": [1, "0-ohm", "+/-1%"],
    "Red": [2, "00-ohm", "+/-2%"],
    "Orange": [3,"K-ohm", ""],
    "Yellow": [4, "0K-ohm", "+/-5%"],
    "Green": [5, "00K-ohm", "+/-0.5%"],
    "Blue": [6, "M-ohm", "+/-0.25%"],
    "Violet": [7, "0M-ohm", "+/-0.1%"],
    "Gray": [8, "00M-ohm", "+/-0.05%"],
    "White": [9, "G-ohm", ""]
  }

  self.submit = function() {
    console.log(self.resistor);
    self.message = resistanceCalculator.addResistance(self.resistor);
  };
});

/**
 * service to calculate resistance
 */
brackets.service('resistanceCalculator', function() {
  this.addResistance = function(name) {
    band = [];
    band[0] = resistor[name[0]][0];
    band[1] = resistor[name[1]][0];
    band[2] = resistor[name[2]][0];
    band[3] = resistor[name[3]][1];
    band[4] = resistor[name[4]][2];
    return "Result: " + band[0] + "" + band[1] + "" + band[2] + "" + band[3] + " " + band[4];
  }
})
