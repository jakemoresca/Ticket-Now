eventModule.controller("eventEditController", ["$scope", "$stateParams", "$http", "$location", "eventService",
function ($scope, $stateParams, $http, $location, eventService)
{
    var self = this;
    $scope.event = eventService.getEvent($stateParams.id);

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