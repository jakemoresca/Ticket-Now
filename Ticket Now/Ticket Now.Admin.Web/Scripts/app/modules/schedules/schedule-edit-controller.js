scheduleModule.controller("scheduleEditController", ["$scope", "$stateParams", "$http", "$location", "scheduleService", "eventService", "locationService",
function ($scope, $stateParams, $http, $location, scheduleService, eventService, locationService)
{
    var self = this;
    $scope.schedule = scheduleService.getSchedule($stateParams.id);
    $scope.locationList = locationService.locationList;
    $scope.event = eventService.getEvent($stateParams.eventId);

    $scope.submit = function ()
    {
        scheduleService.editSchedule($scope.schedule);
        self.gotoSchedulesList();
    };

    $scope.cancel = function ()
    {
        self.gotoSchedulesList();
    }

    this.gotoSchedulesList = function ()
    {
        $location.path("/Events/" + $stateParams.eventId + "/Schedules");
    }
}]);