scheduleModule.controller("scheduleEditController", ["$scope", "$stateParams", "$http", "$location", "scheduleService", "eventService", "locationService",
function ($scope, $stateParams, $http, $location, scheduleService, eventService, locationService)
{
    var self = this;

    $scope.isStartDateOpen = false;
    $scope.isEndDateOpen = false;

    $scope.schedule = scheduleService.getSchedule($stateParams.id);
    $scope.locationList = locationService.locationList;
    $scope.event = eventService.getEvent($stateParams.eventId);

    $scope.minStartDate = moment();
    $scope.minEndDate = moment($scope.schedule.Start);

    $scope.openStartDate = function () {
        $scope.isStartDateOpen = true;
    }

    $scope.openEndDate = function () {
        $scope.isEndDateOpen = true;
    }

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