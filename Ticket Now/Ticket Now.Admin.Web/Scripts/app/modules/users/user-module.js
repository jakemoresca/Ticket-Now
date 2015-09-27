"use strict";
var userModule = angular.module("UserModule", [
    // Angular modules 
    "ngRoute",
    "ngResource",
    // Custom modules 
    "RoleModule"
    // 3rd Party Modules
]);

var adminContentBase = "http://localhost/TicketNow-Admin/";
userModule.constant("ngAdminSettings", {
    adminContentBaseUri: adminContentBase,
    contentTemplateBaseUri: "Content/templates/"
});

userModule.config(["$routeProvider", "$locationProvider", "ngAdminSettings", function ($routeProvider, $locationProvider, ngAdminSettings) {
    $routeProvider
        .when("/Users/Create",
        {
            templateUrl: ngAdminSettings.contentTemplateBaseUri + "user-create.htm",
            controller: "userCreateController",
            controllerAs: "userCtrl"
        })
        .when("/Users/:userName", {
            templateUrl: ngAdminSettings.contentTemplateBaseUri + "user-edit.htm",
            controller: "userEditController",
            controllerAs: "userCtrl"
        })
        .when("/Users",
        {
            templateUrl: ngAdminSettings.contentTemplateBaseUri + "list-form.htm",
            controller: "userController",
            controllerAs: "userCtrl"
        });
    // configure html5 to get links working on jsfiddle
    //$locationProvider.html5Mode(true);
}]);