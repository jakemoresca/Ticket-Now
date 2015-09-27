﻿var app = angular.module("TicketNowAdmin",
    ["ngRoute", "ngMessages", "restangular", "angular-loading-bar", "ngAnimate",
        "AuthModule", "UserModule", "RoleModule", "LocalStorageModule", "ngSanitize"]);

var serviceBase = "http://localhost/TicketNowAuth/";
app.constant("ngAuthSettings", {
    apiServiceBaseUri: serviceBase,
    clientId: "ngAuthApp"
});

var adminServiceBase = "http://localhost/TicketNow-Admin-Api/";
app.constant("ngAdminApiSettings", {
    apiServiceBaseUri: adminServiceBase
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push("authInterceptorService");
});

app.run(["authService", function (authService) {
    authService.fillAuthData();
}]);

app.run(["userService", function (userService) {
    userService.getUsers();
}]);

app.run(["roleService", function (roleService) {
    roleService.getRoles();
}]);