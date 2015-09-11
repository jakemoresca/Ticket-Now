authModule.controller("authController", ["$http", "$location", "authService", "ngAuthSettings", function ($http, $location, authService, ngAuthSettings) {
    var self = this;
    this.loginInfo = {};

    this.loggedIn = function () {
        alert(self.currentUser.length);
        return self.currentUser.length > 0;
    };

    this.logIn = function ()
    {
        authService.login(this.loginInfo).then(function ()
        {
            $location.path("");
        });
    };
}]);