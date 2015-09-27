roleModule.controller("roleController", ["$scope", "$location", "roleService", "ngAdminSettings", function ($scope, $location, roleService, ngAdminSettings)
{
    $scope.roleList = roleService.roleList;
    $scope.moduleName = "Roles";
    $scope.tableTemplate = ngAdminSettings.contentTemplateBaseUri + "role-table.htm";
    
    $scope.deleteRoles = function ()
    {
        var forDeletionRoles = _.where($scope.roleList, { forDeletion: true });
        _.each(forDeletionRoles, function (role)
        {
            roleService.deleteRole(role);
        });
    };

    $scope.editRole = function (role)
    {
        $location.path("/Roles/" + role.Id);
    }
}]);