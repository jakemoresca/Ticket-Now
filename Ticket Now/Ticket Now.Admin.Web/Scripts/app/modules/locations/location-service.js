"use strict";
locationModule.factory("locationService", ["$http", "$q", "localStorageService", "ngAdminApiSettings", "Restangular",
function ($http, $q, localStorageService, ngAdminApiSettings, Restangular) {

    var serviceBase = ngAdminApiSettings.apiServiceBaseUri;
    Restangular.setBaseUrl(serviceBase);
    Restangular.setRestangularFields({ "id": "Id" });

    var baseLocations = Restangular.all("Location");
    var locationServiceFactory = {};
    var locationList = {};

    var clearLocationList = function()
    {
        locationServiceFactory.locationList = {};
    }

    var getLocations = function ()
    {
        locationServiceFactory.locationList = Restangular.all("Location").getList().$object;
    }

    var getLocation = function (id)
    {
        return _.findWhere(locationServiceFactory.locationList, { "Id": id });
    }

    var deleteLocation = function (location)
    {
        location.remove().then(function ()
        {
            var index = locationServiceFactory.locationList.indexOf(location);
            if (index > -1) locationServiceFactory.locationList.splice(index, 1);
        });
    }

    var createLocation = function (newLocation)
    {
        baseLocations.post(newLocation).then(function (result)
        {
            locationServiceFactory.locationList.push(result);
        });
    }

    var editLocation = function(location)
    {
        location.put();
    }

    locationServiceFactory.getLocations = getLocations;
    locationServiceFactory.getLocation = getLocation;
    locationServiceFactory.locationList = locationList;
    locationServiceFactory.deleteLocation = deleteLocation;
    locationServiceFactory.createLocation = createLocation;
    locationServiceFactory.editLocation = editLocation;
    locationServiceFactory.clearLocationsList = clearLocationList;

    return locationServiceFactory;
}]);