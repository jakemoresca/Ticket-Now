scheduleModule.controller("scheduleCreateController", ["$scope", "$stateParams", "$location", "scheduleService", "eventService", "locationService",
function ($scope, $stateParams, $location, scheduleService, eventService, locationService)
{
    var self = this;

    $scope.isStartDateOpen = false;
    $scope.isEndDateOpen = false;

    $scope.schedule = { Event: eventService.getEvent($stateParams.eventId) };
    $scope.locationList = locationService.locationList;

    $scope.minStartDate = moment();
    $scope.minEndDate = moment($scope.schedule.Start);

    $scope.openStartDate = function()
    {
        $scope.isStartDateOpen = true;
    }

    $scope.openEndDate = function()
    {
        $scope.isEndDateOpen = true;
    }

    $scope.submit = function ()
    {
        var newschedule = {
            Name: $scope.schedule.Name, Start: $scope.schedule.Start, End: $scope.schedule.End,
            Event: $scope.schedule.Event, Location: $scope.schedule.Location
        };
        scheduleService.createSchedule(newschedule);
        self.gotoSchedulesList();
    };
    
    $scope.cancel = function()
    {
        self.gotoSchedulesList();
    }

    this.gotoSchedulesList = function()
    {
        $location.path("/Events/" + $stateParams.eventId + "/Schedules");
    }
}]);