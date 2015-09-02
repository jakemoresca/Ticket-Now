var currentUserModule = angular.module("CurrentUser", ["ngRoute"])
    .config(function ($routeProvider)
    {
        $routeProvider
            .when('/Post', {
                templateUrl: 'posts.html',
                controller: 'BookController'
            })
            .when('/Post/:postId', {
                templateUrl: 'chapter.html',
                controller: 'ChapterController'
            });

        // configure html5 to get links working on jsfiddle
        //$locationProvider.html5Mode(true);
    });