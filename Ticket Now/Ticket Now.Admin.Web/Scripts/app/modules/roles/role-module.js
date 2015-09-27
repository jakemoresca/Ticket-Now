"use strict";
var roleModule = angular.module("RoleModule", [
    // Angular modules 
    "ngRoute",
    "ngResource"

    // Custom modules 

    // 3rd Party Modules
]);

var adminContentBase = "http://localhost/TicketNow-Admin/";
roleModule.constant("ngAdminSettings", {
    adminContentBaseUri: adminContentBase,
    contentTemplateBaseUri: "Content/templates/"
});

roleModule.config(["$routeProvider", "$locationProvider", "ngAdminSettings", function ($routeProvider, $locationProvider, ngAdminSettings) {
    $routeProvider
        .when("/Roles/Create",
        {
            templateUrl: ngAdminSettings.contentTemplateBaseUri + "role-create.htm",
            controller: "roleCreateController",
            controllerAs: "roleCtrl"
        })
        .when("/Roles/:id", {
            templateUrl: ngAdminSettings.contentTemplateBaseUri + "role-edit.htm",
            controller: "roleEditController",
            controllerAs: "roleCtrl"
        })
        .when("/Roles",
        {
            templateUrl: ngAdminSettings.contentTemplateBaseUri + "list-form.htm",
            controller: "roleController",
            controllerAs: "roleCtrl"
        });
    // configure html5 to get links working on jsfiddle
    //$locationProvider.html5Mode(true);
}]);