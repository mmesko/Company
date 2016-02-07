(function (angular) {

    angular.module("app").controller("NavigationController",
        ['navigationLinks', 'notificationService', '$scope', '$window', '$controller', '$location', 'navigationMenuService', '$route',
             function (navigationLinks, notificationService, $scope, $window, $controller, $location, navigationMenuService, $route) {

                 // Nav controller is first loaded controller and is alive all time 
                 $location.path("#/");  // redirect to home page every time when controller is created 

                 //#region Proporties

                 var vm = $scope.vm = {};

                 // Used to put out alert messagess
                 vm.alert = { msg: "", cls: ""};
                 vm.menus = navigationMenuService.getMenu();
                 
    

                 // Set CSS of navigation menu to active
                 vm.setActive = function (index) {
                     navigationMenuService.setMenuToActive(index);
                 };

                 // Keep track of notification service
                 $scope.$watch(function () {
                     return notificationService.notification;
                 }, function (oldValue, newValue) {
                     vm.alert = notificationService.returnNotification();
                 });

              
             }]);
})(angular);
