userModule.controller('userEditController', ["$scope", "$routeParams", "$http", "$location", "userService",
function ($scope, $routeParams, $http, $location, userService)
{
    var self = this;
    $scope.user = userService.getUser($routeParams.userName);

    $scope.addClaim = function ()
    {
        $scope.user.Claims.push({ Id: 0, Type: "", Value: "" });
    }

    $scope.removeClaims = function ()
    {
        var updatedClaims = _.filter($scope.user.Claims, function (claim) { return (claim.forDeletion == null || claim.forDeletion === false) });
        $scope.user.Claims = updatedClaims;
    }

    $scope.submit = function ()
    {
        userService.editUser($scope.user);
        self.gotoUsersList();
    };

    $scope.cancel = function ()
    {
        self.gotoUsersList();
    }

    this.gotoUsersList = function ()
    {
        $location.path("/Users");
    }
}]);