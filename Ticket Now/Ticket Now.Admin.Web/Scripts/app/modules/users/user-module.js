"use strict";
var userModule = angular.module("UserModule", [
    // Angular modules 
    "ngRoute",
    "ngResource"

    // Custom modules 

    // 3rd Party Modules
]);

userModule.config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {
    $routeProvider
        .when("/Users",
        {
            templateUrl: "Content/templates/users-list.htm",
            controller: "userController",
            controllerAs: "userCtrl"
        });
    // configure html5 to get links working on jsfiddle
    //$locationProvider.html5Mode(true);
}]);