"use strict";
userModule.factory("userService", ["$http", "$q", "localStorageService", "ngAdminApiSettings", "Restangular",
function ($http, $q, localStorageService, ngAdminApiSettings, Restangular) {

    var serviceBase = ngAdminApiSettings.apiServiceBaseUri;
    Restangular.setBaseUrl(serviceBase);
    Restangular.setRestangularFields({ "id": "UserName" });

    //Restangular.withConfig(function (config) {
    //    config.setRestangularFields({ "id": "UserName" });
    //});

    var baseUsers = Restangular.all('User');

    var userServiceFactory = {};

    var userList = {};

    var getUsers = function ()
    {
        userServiceFactory.userList = Restangular.all('User').getList().$object;
    }

    var getUser = function (userName)
    {
        return _.findWhere(userServiceFactory.userList, { "UserName": userName })
    }

    var deleteUser = function (user)
    {
        //Restangular.one("User", user.UserName).remove()
        user.remove().then(function () {
            var index = userServiceFactory.userList.indexOf(user);
            if (index > -1) userServiceFactory.userList.splice(index, 1);
        });
    }

    var createUser = function (newUser)
    {
        baseUsers.post(newUser).then(function (result) {
            userServiceFactory.userList.push(result);
        })
    }

    var editUser = function(user)
    {
        user.put();
    }

    userServiceFactory.getUsers = getUsers;
    userServiceFactory.getUser = getUser;
    userServiceFactory.userList = userList;
    userServiceFactory.deleteUser = deleteUser;
    userServiceFactory.createUser = createUser;
    userServiceFactory.editUser = editUser;

    return userServiceFactory;
}]);