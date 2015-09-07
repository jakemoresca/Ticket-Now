app.controller("LoginController", ["$http", "$location", function ($http, $location) {
    var self = this;
    this.loginInfo = {};

    this.loggedIn = function () {
        alert(self.currentUser.length);
        return self.currentUser.length > 0;
    };

    this.signIn = function ()
    {
        $http.post("/Ticket Now Auth/api/Account/Login", this.loginInfo).then(function ()
        {
            window.location.href = "../Home";
        });
    };
}]);