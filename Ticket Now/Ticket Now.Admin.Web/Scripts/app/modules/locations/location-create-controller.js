locationModule.controller("locationCreateController", ["$scope", "$http", "$location", "locationService", function ($scope, $http, $location, locationService)
{
    var self = this;
    $scope.location = {};

    $scope.submit = function ()
    {
        var newlocation = { Name: $scope.location.Name, Description: $scope.location.Description };
        locationService.createLocation(newlocation);
        self.gotoLocationsList();
    };

    $scope.cancel = function()
    {
        self.gotoLocationsList();
    }

    this.gotoLocationsList = function()
    {
        $location.path("/Locations");
    }
}]);