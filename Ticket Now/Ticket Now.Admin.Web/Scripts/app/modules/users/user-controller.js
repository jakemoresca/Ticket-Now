userModule.controller("userController", ["$http", "$location", "userService", function ($http, $location, userService) {
    var self = this;
    this.userList = userService.userList;
    
    this.deleteUsers = function ()
    {
        var forDeletionUsers = _.where(self.userList, { forDeletion: true });
        _.each(forDeletionUsers, function (user)
        {
            userService.deleteUser(user);
        })
    };
}]);