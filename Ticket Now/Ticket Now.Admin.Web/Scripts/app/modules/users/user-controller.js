userModule.controller("userController", ["$scope", "$location", "roleService", "userService", "ngAdminSettings",
function ($scope, $location, roleService, userService, ngAdminSettings)
{
    $scope.roleList = roleService.roleList;
    $scope.userList = userService.userList;
    $scope.moduleName = "Users";
    $scope.tableTemplate = ngAdminSettings.contentTemplateBaseUri + "user-table.htm";

    $scope.deleteUser = function (user, $event)
    {
        $event.stopPropagation();
        userService.deleteUser(user);
    }

    $scope.editUser = function (user)
    {
        $location.path("/Users/" + user.UserName);
    }

    $scope.createUser = function()
    {
        $location.path("/Users/Create");
    }
}]);