app.controller("MainController", ["$http", "$location", "authService", "$scope", function ($http, $location, authService, $scope)
{
    var self = this;
    $scope.currentUser = authService.authentication;

    this.gotoHome = function ()
    {
        $location.path("");
    };

    this.logOff = function ()
    {
        authService.logOut();
        $scope.currentUser = authService.authentication;
        $location.path("");
    };
}]);