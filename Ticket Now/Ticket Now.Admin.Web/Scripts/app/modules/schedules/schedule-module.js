"use strict";
var scheduleModule = angular.module("ScheduleModule", [
    // Angular modules 
    "ui.router",
    "ngResource",

    // Custom modules 
    "EventModule",
    "LocationModule"
    // 3rd Party Modules
    //'ui.bootstrap'
]);

var adminContentBase = "http://localhost/TicketNow-Admin/";
scheduleModule.constant("ngAdminSettings", {
    adminContentBaseUri: adminContentBase,
    contentTemplateBaseUri: "Content/templates/"
});

scheduleModule.config(["$stateProvider", "$urlRouterProvider", "ngAdminSettings",
function ($stateProvider, $urlRouterProvider, ngAdminSettings)
{
    $stateProvider
      .state('Schedules.Create',
      {
          url: "/Create",
          templateUrl: ngAdminSettings.contentTemplateBaseUri + "schedule-create.htm",
          controller: "scheduleCreateController",
          controllerAs: "scheduleCtrl"
      })
      .state('Schedules.Edit',
      {
          url: "/:id",
          templateUrl: ngAdminSettings.contentTemplateBaseUri + "schedule-edit.htm",
          controller: "scheduleEditController",
          controllerAs: "scheduleCtrl"
      })
      .state('Schedules',
      {
          url: "/Events/:eventId/Schedules",
          templateUrl: ngAdminSettings.contentTemplateBaseUri + "list-form.htm",
          controller: "scheduleController",
          controllerAs: "scheduleCtrl"
      });
}]);