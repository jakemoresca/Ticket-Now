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
}]);