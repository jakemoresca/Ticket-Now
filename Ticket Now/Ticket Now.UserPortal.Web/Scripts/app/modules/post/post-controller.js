postModule.controller("PostController", ["$routeParams", "PostsFactory", "PostFactory", "$location",
    function ($routeParams, PostsFactory, PostFactory, $location)
{
    this.posts = {};
    this.canEdit = true;

    this.editPost = function (id)
    {
        $location.path("/posts-edit/" + id);
    }

    this.viewPost = function (id)
    {
        $location.path("/posts/" + id);
    }

    this.deletePost = function (id)
    {
        PostFactory.delete({ id: id });
        this.posts = PostsFactory.query();
    }

    this.createNewUser = function () {
        $location.path("/posts-create");
    };

    this.posts = !$routeParams.postId? PostsFactory.query() : [PostFactory.show({ id: $routeParams.postId })];
}]);