var authModule = angular.module("AuthModule", ["ngRoute", "ngResource"]);

authModule.config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {
    $routeProvider
        .when("/login",
        {
            templateUrl: "Content/templates/login.htm",
            controller: "authController",
            controllerAs: "authCtrl"
        });
    // configure html5 to get links working on jsfiddle
    //$locationProvider.html5Mode(true);
}]);