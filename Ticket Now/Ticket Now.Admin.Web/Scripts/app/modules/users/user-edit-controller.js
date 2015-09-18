userModule.controller('userEditController', ["$scope", "$routeParams", "$http", "$location", "userService",
function ($scope, $routeParams, $http, $location, userService)
{
    $scope.user = userService.getUser($routeParams.userName);

    $scope.submit = function () {
        userService.editUser($scope.user);
        gotoUsersList();
    };

    $scope.cancel = function () {
        gotoUsersList();
    }

    gotoUsersList = function () {
        $location.path("/Users");
    }
}]);