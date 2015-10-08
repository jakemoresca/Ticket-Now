"use strict";
var userModule = angular.module("UserModule", [
    // Angular modules 
    "ui.router",
    "ngResource",
    // Custom modules 
    "RoleModule"
    // 3rd Party Modules
]);

var adminContentBase = "http://localhost/TicketNow-Admin/";
userModule.constant("ngAdminSettings",
    {
    adminContentBaseUri: adminContentBase,
    contentTemplateBaseUri: "Content/templates/"
});

userModule.config(["$stateProvider", "$urlRouterProvider", "ngAdminSettings",
function ($stateProvider, $urlRouterProvider, ngAdminSettings)
{
    // Now set up the states
    $stateProvider
      .state('Users.Create',
      {
          url: "/Create",
          templateUrl: ngAdminSettings.contentTemplateBaseUri + "user-create.htm",
          controller: "userCreateController",
          controllerAs: "userCtrl"
      })
      .state('Users.Edit',
      {
          url: "/:userName",
          templateUrl: ngAdminSettings.contentTemplateBaseUri + "user-edit.htm",
          controller: "userEditController",
          controllerAs: "userCtrl"
      })
      .state('Users',
      {
          url: "/Users",
          templateUrl: ngAdminSettings.contentTemplateBaseUri + "list-form.htm",
          controller: "userController",
          controllerAs: "userCtrl"
      });
}]);