eventModule.controller("eventController", ["$scope", "$location", "eventService", "ngAdminSettings",
function ($scope, $location, eventService, ngAdminSettings)
{
    $scope.eventList = eventService.eventList;
    $scope.moduleName = "Events";
    $scope.tableTemplate = ngAdminSettings.contentTemplateBaseUri + "event-table.htm";

    $scope.deleteEvent = function (event, $event)
    {
        $event.stopPropagation();
        eventService.deleteEvent(event);
    };

    $scope.editEvent = function (event)
    {
        $location.path("/Events/" + event.Id);
    };

    $scope.createEvent = function ()
    {
        $location.path("/Events/Create");
    };
}]);