scheduleModule.controller("scheduleCreateController", ["$scope", "$stateParams", "$location", "scheduleService", "eventService", "locationService",
function ($scope, $stateParams, $location, scheduleService, eventService, locationService)
{
    var self = this;
    $scope.schedule = { Event: eventService.getEvent($stateParams.eventId) };
    $scope.locationList = locationService.locationList;
    
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