roleModule.controller("roleEditController", ["$scope", "$routeParams", "$http", "$location", "roleService",
function ($scope, $routeParams, $http, $location, roleService)
{
    var self = this;
    $scope.role = roleService.getRole($routeParams.id);

    $scope.submit = function ()
    {
        roleService.editRole($scope.role);
        self.gotoRolesList();
    };

    $scope.cancel = function ()
    {
        self.gotoRolesList();
    }

    this.gotoRolesList = function ()
    {
        $location.path("/Roles");
    }
}]);