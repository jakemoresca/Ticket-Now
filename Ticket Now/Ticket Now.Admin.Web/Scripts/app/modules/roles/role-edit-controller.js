roleModule.controller("roleEditController", ["$scope", "$stateParams", "$http", "$location", "roleService",
function ($scope, $stateParams, $http, $location, roleService)
{
    var self = this;
    $scope.role = roleService.getRole($stateParams.id);

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