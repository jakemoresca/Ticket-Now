eventModule.controller("eventController", ["$scope", "$location", "eventService", "ngAdminSettings",
function ($scope, $location, eventService, ngAdminSettings)
{
    $scope.eventList = eventService.eventList;
    $scope.moduleName = "Events";
    $scope.tableTemplate = ngAdminSettings.contentTemplateBaseUri + "event-table.htm";
    
    $scope.deleteEvents = function ()
    {
        var forDeletionEvents = _.where($scope.eventList, { forDeletion: true });
        _.each(forDeletionEvents, function (event)
        {
            eventService.deleteEvent(event);
        });
    };

    $scope.editEvent = function (event)
    {
        $location.path("/Events/" + event.Id);
    }
}]);