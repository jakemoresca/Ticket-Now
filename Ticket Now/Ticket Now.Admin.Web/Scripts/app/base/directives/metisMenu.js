app.directive("metisMenu", function ()
{
    return {
        restrict: "A",
        scope: true,
        link: function (scope, elem, attrs, control)
        {
            $(elem).metisMenu();
        }
    }
});