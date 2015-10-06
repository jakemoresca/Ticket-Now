"use strict";
eventModule.factory("eventService", ["$http", "$q", "localStorageService", "ngAdminApiSettings", "Restangular",
function ($http, $q, localStorageService, ngAdminApiSettings, Restangular) {

    var serviceBase = ngAdminApiSettings.apiServiceBaseUri;
    Restangular.setBaseUrl(serviceBase);
    Restangular.setRestangularFields({ "id": "Id" });

    var baseEvents = Restangular.all("Event");
    var eventServiceFactory = {};
    var eventList = {};

    var clearEventList = function()
    {
        eventServiceFactory.eventList = {};
    }

    var getEvents = function ()
    {
        eventServiceFactory.eventList = Restangular.all("Event").getList().$object;
    }

    var getEvent = function (id)
    {
        return _.findWhere(eventServiceFactory.eventList, { "Id": id });
    }

    var deleteEvent = function (event)
    {
        event.remove().then(function ()
        {
            var index = eventServiceFactory.eventList.indexOf(event);
            if (index > -1) eventServiceFactory.eventList.splice(index, 1);
        });
    }

    var createEvent = function (newEvent)
    {
        baseEvents.post(newEvent).then(function (result)
        {
            eventServiceFactory.eventList.push(result);
        });
    }

    var editEvent = function(event)
    {
        event.put();
    }

    eventServiceFactory.getEvents = getEvents;
    eventServiceFactory.getEvent = getEvent;
    eventServiceFactory.eventList = eventList;
    eventServiceFactory.deleteEvent = deleteEvent;
    eventServiceFactory.createEvent = createEvent;
    eventServiceFactory.editEvent = editEvent;
    eventServiceFactory.clearEventsList = clearEventList;

    return eventServiceFactory;
}]);