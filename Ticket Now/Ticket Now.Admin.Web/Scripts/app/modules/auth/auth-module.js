var authModule = angular.module("AuthModule", ["ui.router", "ngResource"]);

authModule.config(["$stateProvider", "$urlRouterProvider",
function ($stateProvider, $urlRouterProvider) {

    $stateProvider
      .state('Login',
      {
          url: "/login",
          template: "<login-form></login-form>",
          controller: "authController",
          controllerAs: "authCtrl"
      });

    //$routeProvider
    //    .when("/login",
    //    {
    //        templateUrl: "Content/templates/login.htm",
    //        controller: "authController",
    //        controllerAs: "authCtrl"
    //    });
    // configure html5 to get links working on jsfiddle
    //$locationProvider.html5Mode(true);
}]);