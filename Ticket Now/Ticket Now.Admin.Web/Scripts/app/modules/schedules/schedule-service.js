"use strict";
scheduleModule.factory("scheduleService", ["$http", "$q", "localStorageService", "ngAdminApiSettings", "Restangular",
function ($http, $q, localStorageService, ngAdminApiSettings, Restangular) {

    var serviceBase = ngAdminApiSettings.apiServiceBaseUri;
    Restangular.setBaseUrl(serviceBase);
    Restangular.setRestangularFields({ "id": "Id" });

    var baseSchedules = Restangular.all("Schedule");
    var scheduleServiceFactory = {};
    var scheduleList = {};

    var clearScheduleList = function()
    {
        scheduleServiceFactory.scheduleList = {};
    }

    var getSchedules = function ()
    {
        scheduleServiceFactory.scheduleList = Restangular.all("Schedule").getList().$object;
    }

    var getSchedule = function (id)
    {
        return _.findWhere(scheduleServiceFactory.scheduleList, { "Id": id });
    }

    var deleteSchedule = function (schedule)
    {
        schedule.remove().then(function ()
        {
            var index = scheduleServiceFactory.scheduleList.indexOf(schedule);
            if (index > -1) scheduleServiceFactory.scheduleList.splice(index, 1);
        });
    }

    var createSchedule = function (newSchedule)
    {
        baseSchedules.post(newSchedule).then(function (result)
        {
            scheduleServiceFactory.scheduleList.push(result);
        });
    }

    var editSchedule = function(schedule)
    {
        schedule.put();
    }

    scheduleServiceFactory.getSchedules = getSchedules;
    scheduleServiceFactory.getSchedule = getSchedule;
    scheduleServiceFactory.scheduleList = scheduleList;
    scheduleServiceFactory.deleteSchedule = deleteSchedule;
    scheduleServiceFactory.createSchedule = createSchedule;
    scheduleServiceFactory.editSchedule = editSchedule;
    scheduleServiceFactory.clearSchedulesList = clearScheduleList;

    return scheduleServiceFactory;
}]);