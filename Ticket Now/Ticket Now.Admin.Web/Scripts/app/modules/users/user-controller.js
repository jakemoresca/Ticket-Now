userModule.controller("userController", ["$http", "$location", "userService", function ($http, $location, userService) {
    var self = this;
    this.userList = userService.userList;
    
}]);