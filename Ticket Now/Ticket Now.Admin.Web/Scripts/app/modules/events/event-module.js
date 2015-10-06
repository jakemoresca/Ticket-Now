"use strict";
var eventModule = angular.module("EventModule", [
    // Angular modules 
    "ngRoute",
    "ngResource"

    // Custom modules 

    // 3rd Party Modules
]);

var adminContentBase = "http://localhost/TicketNow-Admin/";
eventModule.constant("ngAdminSettings", {
    adminContentBaseUri: adminContentBase,
    contentTemplateBaseUri: "Content/templates/"
});

eventModule.config(["$routeProvider", "$locationProvider", "ngAdminSettings", function ($routeProvider, $locationProvider, ngAdminSettings) {
    $routeProvider
        .when("/Events/Create",
        {
            templateUrl: ngAdminSettings.contentTemplateBaseUri + "event-create.htm",
            controller: "eventCreateController",
            controllerAs: "eventCtrl"
        })
        .when("/Events/:id", {
            templateUrl: ngAdminSettings.contentTemplateBaseUri + "event-edit.htm",
            controller: "eventEditController",
            controllerAs: "eventCtrl"
        })
        .when("/Events",
        {
            templateUrl: ngAdminSettings.contentTemplateBaseUri + "list-form.htm",
            controller: "eventController",
            controllerAs: "eventCtrl"
        });
    // configure html5 to get links working on jsfiddle
    //$locationProvider.html5Mode(true);
}]);