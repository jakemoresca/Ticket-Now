eventModule.controller("eventCreateController", ["$scope", "$http", "$location", "eventService", function ($scope, $http, $location, eventService)
{
    var self = this;
    $scope.event = {};

    $scope.submit = function ()
    {
        var newevent = { Name: $scope.event.Name, Description: $scope.event.Description, Duration: $scope.event.Duration };
        eventService.createEvent(newevent);
        self.gotoEventsList();
    };

    $scope.cancel = function()
    {
        self.gotoEventsList();
    }

    this.gotoEventsList = function()
    {
        $event.path("/Events");
    }
}]);