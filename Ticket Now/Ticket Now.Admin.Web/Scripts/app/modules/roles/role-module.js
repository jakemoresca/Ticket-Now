"use strict";
var roleModule = angular.module("RoleModule", [
    // Angular modules 
    "ui.router",
    "ngResource"

    // Custom modules 

    // 3rd Party Modules
]);

var adminContentBase = "http://localhost/TicketNow-Admin/";
roleModule.constant("ngAdminSettings", {
    adminContentBaseUri: adminContentBase,
    contentTemplateBaseUri: "Content/templates/"
});

roleModule.config(["$stateProvider", "$urlRouterProvider", "ngAdminSettings", 
function ($stateProvider, $urlRouterProvider, ngAdminSettings)
{
    $stateProvider
      .state('Roles.Create',
      {
          url: "/Create",
          templateUrl: ngAdminSettings.contentTemplateBaseUri + "role-create.htm",
          controller: "roleCreateController",
          controllerAs: "roleCtrl"
      })
      .state('Roles.Edit',
      {
          url: "/:id",
          templateUrl: ngAdminSettings.contentTemplateBaseUri + "role-edit.htm",
          controller: "roleEditController",
          controllerAs: "roleCtrl"
      })
      .state('Roles',
      {
          url: "/Roles",
          templateUrl: ngAdminSettings.contentTemplateBaseUri + "list-form.htm",
          controller: "roleController",
          controllerAs: "roleCtrl"
      });
}]);