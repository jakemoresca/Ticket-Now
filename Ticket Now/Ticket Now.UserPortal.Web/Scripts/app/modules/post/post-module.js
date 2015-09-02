var postModule = angular.module("PostModule", ["ngRoute", "ngResource", "ckeditor"]);

postModule.config(["$routeProvider","$locationProvider", function ($routeProvider, $locationProvider)
{
    $routeProvider
        .when("/posts",
        {
            templateUrl: "/templates/posts.htm",
            controller: "PostController",
            controllerAs: "postCtrl"
        })
        .when("/posts/:postId", {
            templateUrl: "/templates/posts.htm",
            controller: "PostController",
            controllerAs: "postCtrl"
        })
        .when("/posts-edit/:postId", {
            templateUrl: "/templates/post-edit.htm",
            controller: "PostDetailController",
            controllerAs: "postDtlCtrl"
        })
        .when("/posts-create", {
            templateUrl: "/templates/post-create.htm",
            controller: "PostCreateController",
            controllerAs: "postNewCtrl"
        });
    // configure html5 to get links working on jsfiddle
    //$locationProvider.html5Mode(true);
}]);