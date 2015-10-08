"use strict";
var locationModule = angular.module("LocationModule", [
    // Angular modules 
    "ui.router",
    "ngResource"

    // Custom modules 

    // 3rd Party Modules
]);

var adminContentBase = "http://localhost/TicketNow-Admin/";
locationModule.constant("ngAdminSettings", {
    adminContentBaseUri: adminContentBase,
    contentTemplateBaseUri: "Content/templates/"
});

locationModule.config(["$stateProvider", "$urlRouterProvider", "ngAdminSettings",
function ($stateProvider, $urlRouterProvider, ngAdminSettings)
{
    $stateProvider
      .state('Locations.Create',
      {
          url: "/Create",
          templateUrl: ngAdminSettings.contentTemplateBaseUri + "location-create.htm",
          controller: "locationCreateController",
          controllerAs: "locationCtrl"
      })
      .state('Locations.Edit',
      {
          url: "/:id",
          templateUrl: ngAdminSettings.contentTemplateBaseUri + "location-edit.htm",
          controller: "locationEditController",
          controllerAs: "locationCtrl"
      })
      .state('Locations',
      {
          url: "/Locations",
          templateUrl: ngAdminSettings.contentTemplateBaseUri + "list-form.htm",
          controller: "locationController",
          controllerAs: "locationCtrl"
      });
}]);