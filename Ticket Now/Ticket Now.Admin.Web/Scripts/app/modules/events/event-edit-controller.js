eventModule.controller("eventEditController", ["$scope", "$stateParams", "$http", "$location", "eventService", "scheduleService", "ngAdminSettings",
function ($scope, $stateParams, $http, $location, eventService, scheduleService, ngAdminSettings)
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

    $scope.scheduleList = scheduleService.scheduleList;
    $scope.moduleName = "Schedules";
    $scope.tableTemplate = ngAdminSettings.contentTemplateBaseUri + "schedule-table.htm";

    $scope.deleteSchedule = function (schedule, $schedule) {
        $schedule.stopPropagation();
        scheduleService.deleteSchedule(schedule);
    };

    $scope.editSchedule = function (schedule) {
        $location.path("/Schedules/" + schedule.Id);
    };

    $scope.createSchedule = function () {
        $location.path("/Events/" + $stateParams.id + "/Schedules/Create");
    };
}]);