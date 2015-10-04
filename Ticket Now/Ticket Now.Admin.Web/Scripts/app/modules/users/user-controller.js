userModule.controller("userController", ["$scope", "$location", "roleService", "userService", "ngAdminSettings",
function ($scope, $location, roleService, userService, ngAdminSettings)
{
    $scope.roleList = roleService.roleList;
    $scope.userList = userService.userList;
    $scope.moduleName = "Users";
    $scope.tableTemplate = ngAdminSettings.contentTemplateBaseUri + "user-table.htm";

    $scope.mapRole = function (user)
    {
        user.Role.Name = _.findWhere($scope.roleList, { Id: user.Role.Id });
    }

    $scope.deleteUsers = function ()
    {
        var forDeletionUsers = _.where($scope.userList, { forDeletion: true });
        _.each(forDeletionUsers, function (user)
        {
            userService.deleteUser(user);
        });
    };

    $scope.editUser = function (user)
    {
        $location.path("/Users/" + user.UserName);
    }
}]);