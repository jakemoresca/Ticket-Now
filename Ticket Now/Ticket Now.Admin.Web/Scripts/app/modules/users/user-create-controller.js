userModule.controller('userCreateController', ["$scope", "$http", "$location", "userService", function ($scope, $http, $location, userService)
{
    var self = this;
    $scope.user = {Claims: []};

    $scope.submit = function ()
    {
        var newUser = {
            UserName: $scope.user.UserName, Password: $scope.user.Password,
            HomeTown: $scope.user.HomeTown, ZipCode: $scope.user.ZipCode, Claims: $scope.user.Claims
        };
        userService.createUser(newUser);
        self.gotoUsersList();
    };

    $scope.addClaim = function ()
    {
        $scope.user.Claims.push({ Id: 0, Type: "", Value: "" });
    }

    $scope.removeClaims = function ()
    {
        var updatedClaims = _.filter($scope.user.Claims, function (claim) { return (claim.forDeletion == null || claim.forDeletion === false) });
        $scope.user.Claims = updatedClaims;
    }

    $scope.hasUniqueClaims = function ()
    {
        var uniqueClaimTypes = _.uniq($scope.user.Claims, function (claim) { return claim.Type; });
        return (uniqueClaimTypes.length == $scope.user.Claims.length);
    }

    $scope.cancel = function()
    {
        self.gotoUsersList();
    }

    this.gotoUsersList = function()
    {
        $location.path("/Users");
    }
}]);