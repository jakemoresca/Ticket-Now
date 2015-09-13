userModule.controller("userController", ["$http", "$location", "userService", function ($http, $location, userService) {
    var self = this;
    debugger;
    this.userList = userService.userList;
    
}]);