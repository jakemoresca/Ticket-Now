postModule.controller("PostCreateController", ["$routeParams", "PostsFactory", "$location", "$q",
    function ($routeParams, PostsFactory, $location, $q)
{
    this.post = {};

    // Editor options.
    this.editorOptions = {
        language: 'en',
        allowedContent: true,
        entities: false
    };

    // callback for ng-click 'cancel':
    this.cancel = function ()
    {
        $location.path("/posts");
    };

    // callback for ng-click 'createNewPost':
    this.createNewPost = function ()
    {
        var deferred = $q.defer();
        deferred.resolve(PostsFactory.create(this.post));

        deferred.promise.then(function ()
        {
            $location.path("/posts");
        });
    }
}]);