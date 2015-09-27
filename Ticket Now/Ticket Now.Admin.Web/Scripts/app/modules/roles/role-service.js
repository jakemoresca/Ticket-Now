"use strict";
roleModule.factory("roleService", ["$http", "$q", "localStorageService", "ngAdminApiSettings", "Restangular",
function ($http, $q, localStorageService, ngAdminApiSettings, Restangular) {

    var serviceBase = ngAdminApiSettings.apiServiceBaseUri;
    Restangular.setBaseUrl(serviceBase);
    Restangular.setRestangularFields({ "id": "Id" });

    var baseRoles = Restangular.all("Role");
    var roleServiceFactory = {};
    var roleList = {};

    var clearRolesList = function()
    {
        roleServiceFactory.roleList = {};
    }

    var getRoles = function ()
    {
        roleServiceFactory.roleList = Restangular.all("Role").getList().$object;
    }

    var getRole = function (id)
    {
        return _.findWhere(roleServiceFactory.roleList, { "Id": id });
    }

    var deleteRole = function (role)
    {
        role.remove().then(function ()
        {
            var index = roleServiceFactory.roleList.indexOf(role);
            if (index > -1) roleServiceFactory.roleList.splice(index, 1);
        });
    }

    var createRole = function (newRole)
    {
        baseRoles.post(newRole).then(function (result)
        {
            roleServiceFactory.roleList.push(result);
        });
    }

    var editRole = function(role)
    {
        role.put();
    }

    roleServiceFactory.getRoles = getRoles;
    roleServiceFactory.getRole = getRole;
    roleServiceFactory.roleList = roleList;
    roleServiceFactory.deleteRole = deleteRole;
    roleServiceFactory.createRole = createRole;
    roleServiceFactory.editRole = editRole;
    roleServiceFactory.clearRolesList = clearRolesList;

    return roleServiceFactory;
}]);