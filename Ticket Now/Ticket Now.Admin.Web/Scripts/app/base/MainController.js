app.controller("MainController", ["$http", "$location", "authService", "userService", "$scope",
function ($http, $location, authService, userService, $scope)
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
        userService.userList.clearUsersList();
        $location.path("");
    };
}]);