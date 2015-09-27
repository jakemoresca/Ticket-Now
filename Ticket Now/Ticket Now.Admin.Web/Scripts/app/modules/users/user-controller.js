userModule.controller("userController", ["$scope", "$location", "userService", "roleService", "ngAdminSettings",
function ($scope, $location, userService, roleService, ngAdminSettings)
{
    $scope.userList = userService.userList;
    $scope.roleList = roleService.roleList;
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