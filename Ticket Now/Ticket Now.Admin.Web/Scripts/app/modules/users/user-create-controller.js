userModule.controller('userCreateController', ["$scope", "$http", "$location", "userService", function ($scope, $http, $location, userService)
{
    $scope.submit = function ()
    {
        var newUser = {UserName: $scope.UserName, Password: $scope.Password, HomeTown: $scope.HomeTown, ZipCode: $scope.ZipCode};
        userService.createUser(newUser);
        gotoUsersList();
    };

    $scope.cancel = function()
    {
        gotoUsersList();
    }

    gotoUsersList = function()
    {
        $location.path("/Users");
    }
}]);