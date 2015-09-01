postModule.controller("PostDetailController", ["$routeParams", "PostFactory", "$location", "$q",
    function ($routeParams, PostFactory, $location, $q)
{
    // Editor options.
    this.editorOptions = {
        language: 'en',
        allowedContent: true,
        entities: false
    };

    // callback for ng-click 'updatePost':
    this.updatePost = function ()
    {
        var deferred = $q.defer();
        deferred.resolve(PostFactory.update(this.post));

        deferred.promise.then(function () {
            $location.path("/posts");
        });
    };

    // callback for ng-click 'cancel':
    this.cancel = function ()
    {
        $location.path("/posts");
    };

    this.post = PostFactory.show({ id: $routeParams.postId });
}]);