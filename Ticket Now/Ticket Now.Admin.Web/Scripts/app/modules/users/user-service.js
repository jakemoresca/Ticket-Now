"use strict";
userModule.factory("userService", ["$http", "$q", "localStorageService", "ngAdminApiSettings", "Restangular",
function ($http, $q, localStorageService, ngAdminApiSettings, Restangular) {

    var serviceBase = ngAdminApiSettings.apiServiceBaseUri;
    Restangular.setBaseUrl(ngAdminApiSettings.apiServiceBaseUri);
    var baseUsers = Restangular.all('User');

    var userServiceFactory = {};

    var userList = {};

    var getUsers = function ()
    {
        userServiceFactory.userList = Restangular.all('User').getList().$object;
    }

    var deleteUser = function (user)
    {
        Restangular.one("User", user.UserName).remove().then(function () {
            var index = userServiceFactory.userList.indexOf(product);
            if (index > -1) userServiceFactory.userList.splice(index, 1);
        });
    }

    userServiceFactory.getUsers = getUsers;
    userServiceFactory.userList = userList;
    userServiceFactory.deleteUser = deleteUser;

    return userServiceFactory;
}]);