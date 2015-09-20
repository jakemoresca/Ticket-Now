userModule.controller('userCreateController', ["$scope", "$http", "$location", "userService", function ($scope, $http, $location, userService)
{
    var self = this;
    $scope.submit = function ()
    {
        var newUser = {UserName: $scope.UserName, Password: $scope.Password, HomeTown: $scope.HomeTown, ZipCode: $scope.ZipCode};
        userService.createUser(newUser);
        self.gotoUsersList();
    };

    $scope.cancel = function()
    {
        self.gotoUsersList();
    }

    var gotoUsersList = function()
    {
        $location.path("/Users");
    }
}]);