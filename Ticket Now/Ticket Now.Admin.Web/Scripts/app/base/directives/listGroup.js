app.directive("listGroup", function ()
{
    return {
        restrict: "E",
        scope: {
            groupName: '=group',
            list: '=list',
            cssClass: '=cssClass',
            editItem: '&',
            createItem: '&',
            deleteItem: '&'
        },
        templateUrl: function(elem,attrs)
        {
            return attrs.templateUrl == null ? "./Content/templates/list-group.htm" : attrs.templateUrl;
        }
        //templateUrl: "./Content/templates/list-group.htm"
    }
});