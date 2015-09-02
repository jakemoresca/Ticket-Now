app.controller("MeController", ["$http", function ($http)
{
    var self = this;
    this.currentUser = {};

    $http.get("api/Me").
        then(function (result)
        {
            self.currentUser = result.data;
        });
}]);