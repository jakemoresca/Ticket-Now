scheduleModule.controller("scheduleEditController", ["$scope", "$stateParams", "$http", "$location", "scheduleService",
function ($scope, $stateParams, $http, $location, scheduleService)
{
    var self = this;
    $scope.schedule = scheduleService.getSchedule($stateParams.id);

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
        $location.path("/Schedules");
    }
}]);