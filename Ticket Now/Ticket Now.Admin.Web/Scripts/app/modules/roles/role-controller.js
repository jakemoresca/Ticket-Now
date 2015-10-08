roleModule.controller("roleController", ["$scope", "$location", "roleService", "ngAdminSettings", function ($scope, $location, roleService, ngAdminSettings)
{
    $scope.roleList = roleService.roleList;
    $scope.moduleName = "Roles";
    $scope.tableTemplate = ngAdminSettings.contentTemplateBaseUri + "role-table.htm";
    
    $scope.deleteRole = function (role, $event)
    {
        $event.stopPropagation();
        roleService.deleteRole(role);
    };

    $scope.editRole = function (role)
    {
        $location.path("/Roles/" + role.Id);
    };

    $scope.createRoles = function ()
    {
        $location.path("/Roles/Create");
    };
}]);