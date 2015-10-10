locationModule.controller("locationController", ["$scope", "$location", "locationService", "ngAdminSettings",
function ($scope, $location, locationService, ngAdminSettings)
{
    $scope.locationList = locationService.locationList;
    $scope.moduleName = "Locations";
    $scope.tableTemplate = ngAdminSettings.contentTemplateBaseUri + "location-table.htm";

    $scope.deleteLocation = function (location, $event)
    {
        $event.stopPropagation();
        locationService.deleteLocation(location);
    };

    $scope.editLocation = function (location)
    {
        $location.path("/Locations/" + location.Id);
    };

    $scope.createLocation = function ()
    {
        $location.path("/Locations/Create");
    };
}]);