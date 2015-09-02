app.controller("AdminController", ["$http", function ($http) {
    var self = this;
    this.currentUser = null;

    $http.get("/api/Me").then(function (result) {
        self.currentUser = result.data;
    });

    this.loggedIn = function () {
        return this.currentUser != null;
    };
}]);