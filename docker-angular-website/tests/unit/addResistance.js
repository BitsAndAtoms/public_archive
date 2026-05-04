describe('Service: resistanceCalculator#addResistance', function() {
  beforeEach(module('brackets'));


  var service;

  beforeEach(inject(function(_resistanceCalculator_) {
    service = _resistanceCalculator_;
  }));

  // your tests will go here



  describe("Test addResistance with different colored bands", function() {
    it("should add resistances and provide net result", function() {
      expect(service.addResistance(["Black", "Brown", "Red", "Orange", "Yellow"])).toEqual("Result: 012K-ohm +/-5%");
    });
  });

  describe("Test addResistance with repeating colored bands", function() {
    it("should add resistances and provide net result", function() {
      expect(service.addResistance(["Red", "Red", "Red", "Orange", "Orange"])).toEqual("Result: 222K-ohm ");
    });
  });

});
