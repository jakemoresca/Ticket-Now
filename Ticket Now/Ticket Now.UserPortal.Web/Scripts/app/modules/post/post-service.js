postModule.factory("PostsFactory", function ($resource)
{
    return $resource("/api/Post", {},
    {
        query: { method: "GET", isArray: true },
        create: { method: "POST" }
    });
});

postModule.factory("PostFactory",  function ($resource)
{
    return $resource("/api/Post/:id", {},
    {
        show: { method: "GET" },
        update: { method: "PUT", params: { id: "@id" } },
        delete: { method: "DELETE", params: { id: "@id" } }
    });
});

    