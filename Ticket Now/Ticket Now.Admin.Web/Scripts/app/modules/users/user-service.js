"use strict";
userModule.factory("userService", ["$http", "$q", "localStorageService", "ngAdminApiSettings", "Restangular",
function ($http, $q, localStorageService, ngAdminApiSettings, Restangular) {

    var serviceBase = ngAdminApiSettings.apiServiceBaseUri;
    Restangular.setBaseUrl(ngAdminApiSettings.apiServiceBaseUri);
    var baseUsers = Restangular.all('User');

    var authServiceFactory = {};

    var userList = {};

    var getUsers = function () {
        authServiceFactory.userList = Restangular.all('User').getList().$object;
    }

    authServiceFactory.getUsers = getUsers;
    authServiceFactory.userList = userList;

    return authServiceFactory;
}]);