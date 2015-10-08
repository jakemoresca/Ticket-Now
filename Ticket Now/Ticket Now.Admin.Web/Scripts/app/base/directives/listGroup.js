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
        templateUrl: "./Content/templates/list-group.htm"
    }
});