locationModule.controller("locationController", ["$scope", "$location", "locationService", "ngAdminSettings",
function ($scope, $location, locationService, ngAdminSettings)
{
    $scope.locationList = locationService.locationList;
    $scope.moduleName = "Locations";
    $scope.tableTemplate = ngAdminSettings.contentTemplateBaseUri + "location-table.htm";
    
    $scope.deleteLocations = function ()
    {
        var forDeletionLocations = _.where($scope.locationList, { forDeletion: true });
        _.each(forDeletionLocations, function (location)
        {
            locationService.deleteLocation(location);
        });
    };

    $scope.editLocation = function (location)
    {
        $location.path("/Locations/" + location.Id);
    }
}]);