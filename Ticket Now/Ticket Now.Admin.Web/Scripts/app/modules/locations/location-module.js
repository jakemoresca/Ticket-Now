"use strict";
var locationModule = angular.module("LocationModule", [
    // Angular modules 
    "ngRoute",
    "ngResource"

    // Custom modules 

    // 3rd Party Modules
]);

var adminContentBase = "http://localhost/TicketNow-Admin/";
locationModule.constant("ngAdminSettings", {
    adminContentBaseUri: adminContentBase,
    contentTemplateBaseUri: "Content/templates/"
});

locationModule.config(["$routeProvider", "$locationProvider", "ngAdminSettings", function ($routeProvider, $locationProvider, ngAdminSettings) {
    $routeProvider
        .when("/Locations/Create",
        {
            templateUrl: ngAdminSettings.contentTemplateBaseUri + "location-create.htm",
            controller: "locationCreateController",
            controllerAs: "locationCtrl"
        })
        .when("/Locations/:id", {
            templateUrl: ngAdminSettings.contentTemplateBaseUri + "location-edit.htm",
            controller: "locationEditController",
            controllerAs: "locationCtrl"
        })
        .when("/Locations",
        {
            templateUrl: ngAdminSettings.contentTemplateBaseUri + "list-form.htm",
            controller: "locationController",
            controllerAs: "locationCtrl"
        });
    // configure html5 to get links working on jsfiddle
    //$locationProvider.html5Mode(true);
}]);