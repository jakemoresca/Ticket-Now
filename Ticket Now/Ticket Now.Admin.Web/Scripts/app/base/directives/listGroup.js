app.directive("listGroup", function ()
{
    return {
        restrict: "E",
        scope: {
            groupName: '=group',
            list: '=list',
            css: '=css',
            editItem: '&',
            createItem: '&',
            deleteItem: '&'
        },
        templateUrl: function(elem,attrs)
        {
            return attrs.templateUrl == null ? "./Scripts/app/base/directives/list-group.htm" : attrs.templateUrl;
        }
    }
});