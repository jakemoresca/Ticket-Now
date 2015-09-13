"use strict";
userModule.factory("userService", ["$http", "$q", "localStorageService", "ngAdminApiSettings", function ($http, $q, localStorageService, ngAdminApiSettings) {

    var serviceBase = ngAdminApiSettings.apiServiceBaseUri;
    var authServiceFactory = {};

    var userList = {};

    var getUsers = function ()
    {
        var deferred = $q.defer();

        $http.get(serviceBase + "User/Get").then(function (response)
        {
            debugger;
            authServiceFactory.userList = response;
        });

        return deferred.promise;
    }

    //var _login = function (loginData) {

    //    var data = "client_id=099153c2625149bc8ecb3e85e03f0022&grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;

    //    if (loginData.useRefreshTokens) {
    //        data = data + "&client_id=" + ngAuthSettings.clientId;
    //    }

    //    var deferred = $q.defer();

    //    $http.post(serviceBase + 'oauth2/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

    //        if (loginData.useRefreshTokens) {
    //            localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, refreshToken: response.refresh_token, useRefreshTokens: true });
    //        }
    //        else {
    //            localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, refreshToken: "", useRefreshTokens: false });
    //        }
    //        _authentication.isAuth = true;
    //        _authentication.userName = loginData.userName;
    //        _authentication.useRefreshTokens = loginData.useRefreshTokens;

    //        deferred.resolve(response);

    //    }).error(function (err, status) {
    //        _logOut();
    //        deferred.reject(err);
    //    });

    //    return deferred.promise;

    //};

    //var _logOut = function () {

    //    localStorageService.remove('authorizationData');

    //    _authentication.isAuth = false;
    //    _authentication.userName = "";
    //    _authentication.useRefreshTokens = false;

    //};

    //var _fillAuthData = function () {

    //    var authData = localStorageService.get('authorizationData');
    //    if (authData) {
    //        _authentication.isAuth = true;
    //        _authentication.userName = authData.userName;
    //        _authentication.useRefreshTokens = authData.useRefreshTokens;
    //    }

    //};

    //var _refreshToken = function () {
    //    var deferred = $q.defer();

    //    var authData = localStorageService.get('authorizationData');

    //    if (authData) {

    //        if (authData.useRefreshTokens) {

    //            var data = "grant_type=refresh_token&refresh_token=" + authData.refreshToken + "&client_id=" + ngAuthSettings.clientId;

    //            localStorageService.remove('authorizationData');

    //            $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

    //                localStorageService.set('authorizationData', { token: response.access_token, userName: response.userName, refreshToken: response.refresh_token, useRefreshTokens: true });

    //                deferred.resolve(response);

    //            }).error(function (err, status) {
    //                _logOut();
    //                deferred.reject(err);
    //            });
    //        }
    //    }

    //    return deferred.promise;
    //};

    authServiceFactory.getUsers = getUsers;
    //authServiceFactory.login = _login;
    //authServiceFactory.logOut = _logOut;
    //authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.userList = userList;
    //authServiceFactory.refreshToken = _refreshToken;

    //authServiceFactory.obtainAccessToken = _obtainAccessToken;
    //authServiceFactory.externalAuthData = _externalAuthData;
    //authServiceFactory.registerExternal = _registerExternal;

    return authServiceFactory;
}]);