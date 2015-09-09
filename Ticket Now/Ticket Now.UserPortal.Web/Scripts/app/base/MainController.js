app.controller("MainController", ["$http", "authService", function ($http, authService)
{
    var self = this;
    this.currentUser = authService.authentication;

    this.loggedIn = function()
    {
        return this.currentUser.isAuth;
    };

    this.logOff = function ()
    {
        authService.logOut();
        this.currentUser = authService.authentication;
        window.location.href = "Account/Login";
    };
}]);