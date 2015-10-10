scheduleModule.controller("scheduleController", ["$scope", "$stateParams", "$location", "scheduleService", "ngAdminSettings",
function ($scope, $stateParams, $location, scheduleService, ngAdminSettings)
{
    $scope.scheduleList = scheduleService.scheduleList;
    $scope.moduleName = "Schedules";
    $scope.tableTemplate = ngAdminSettings.contentTemplateBaseUri + "schedule-table.htm";

    $scope.deleteSchedule = function (schedule, $schedule)
    {
        $schedule.stopPropagation();
        scheduleService.deleteSchedule(schedule);
    };

    $scope.editSchedule = function (schedule)
    {
        $location.path("Events/" + $stateParams.eventId + "/Schedules/" + schedule.Id);
    };

    $scope.createSchedule = function ()
    {
        $location.path("Events/" + $stateParams.eventId + "/Schedules/Create");
    };
}]);