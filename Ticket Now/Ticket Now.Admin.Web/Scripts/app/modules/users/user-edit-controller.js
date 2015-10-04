userModule.controller("userEditController", ["$scope", "$routeParams", "$http", "$location", "userService", "roleService",
function ($scope, $routeParams, $http, $location, userService, roleService)
{
    var self = this;
    $scope.user = userService.getUser($routeParams.userName);
    $scope.roleList = roleService.roleList;

    $scope.addClaim = function ()
    {
        $scope.user.Claims.push({ Id: 0, Type: "", Value: "" });
    }

    $scope.removeClaims = function ()
    {
        var updatedClaims = _.filter($scope.user.Claims, function (claim) { return (claim.forDeletion == null || claim.forDeletion === false) });
        $scope.user.Claims = updatedClaims;
    }

    $scope.hasUniqueClaims = function()
    {
        var uniqueClaimTypes = _.uniq($scope.user.Claims, function (claim) { return claim.Type; });
        return (uniqueClaimTypes.length === $scope.user.Claims.length);
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