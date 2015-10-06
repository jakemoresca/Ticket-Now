eventModule.controller("eventEditController", ["$scope", "$routeParams", "$http", "$location", "eventService",
function ($scope, $routeParams, $http, $location, eventService)
{
    var self = this;
    $scope.event = eventService.getEvent($routeParams.id);

    $scope.submit = function ()
    {
        eventService.editEvent($scope.event);
        self.gotoEventsList();
    };

    $scope.cancel = function ()
    {
        self.gotoEventsList();
    }

    this.gotoEventsList = function ()
    {
        $location.path("/Events");
    }
}]);