locationModule.controller("locationEditController", ["$scope", "$stateParams", "$http", "$location", "locationService",
function ($scope, $stateParams, $http, $location, locationService)
{
    var self = this;
    $scope.location = locationService.getLocation($stateParams.id);

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