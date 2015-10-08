"use strict";
var eventModule = angular.module("EventModule", [
    // Angular modules 
    "ui.router",
    "ngResource"

    // Custom modules 

    // 3rd Party Modules
]);

var adminContentBase = "http://localhost/TicketNow-Admin/";
eventModule.constant("ngAdminSettings", {
    adminContentBaseUri: adminContentBase,
    contentTemplateBaseUri: "Content/templates/"
});

eventModule.config(["$stateProvider", "$urlRouterProvider", "ngAdminSettings",
function ($stateProvider, $urlRouterProvider, ngAdminSettings)
{
    $stateProvider
      .state('Events.Create',
      {
          url: "/Create",
          templateUrl: ngAdminSettings.contentTemplateBaseUri + "event-create.htm",
          controller: "eventCreateController",
          controllerAs: "eventCtrl"
      })
      .state('Events.Edit',
      {
          url: "/:id",
          templateUrl: ngAdminSettings.contentTemplateBaseUri + "event-edit.htm",
          controller: "eventEditController",
          controllerAs: "eventCtrl"
      })
      .state('Events',
      {
          url: "/Events",
          templateUrl: ngAdminSettings.contentTemplateBaseUri + "list-form.htm",
          controller: "eventController",
          controllerAs: "eventCtrl"
      });
}]);