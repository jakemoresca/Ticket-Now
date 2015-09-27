roleModule.controller("roleCreateController", ["$scope", "$http", "$location", "roleService", function ($scope, $http, $location, roleService)
{
    var self = this;
    $scope.role = {};

    $scope.submit = function ()
    {
        var newRole = { Name: $scope.role.Name };
        roleService.createRole(newRole);
        self.gotoRolesList();
    };

    $scope.cancel = function()
    {
        self.gotoRolesList();
    }

    this.gotoRolesList = function()
    {
        $location.path("/Roles");
    }
}]);