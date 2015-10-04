locationModule.controller("locationEditController", ["$scope", "$routeParams", "$http", "$location", "locationService",
function ($scope, $routeParams, $http, $location, locationService)
{
    var self = this;
    $scope.location = locationService.getLocation($routeParams.id);

    $scope.submit = function ()
    {
        locationService.editLocation($scope.location);
        self.gotoLocationsList();
    };

    $scope.cancel = function ()
    {
        self.gotoLocationsList();
    }

    this.gotoLocationsList = function ()
    {
        $location.path("/Locations");
    }
}]);