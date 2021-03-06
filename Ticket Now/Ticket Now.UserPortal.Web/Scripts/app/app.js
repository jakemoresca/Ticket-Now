﻿var app = angular.module("TicketNow", [
    "ui.router", "restangular", "angular-loading-bar", "ngAnimate",
    "AuthModule",
    "LocalStorageModule", "ngSanitize"
]);

//var serviceBase = 'http://localhost:26264/';
var serviceBase = 'http://localhost/TicketNowAuth/';
app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);