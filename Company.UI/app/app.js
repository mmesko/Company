
// Main Module
(function (angular) {

    // Configure routes
    angular.module("app", ['ngRoute', 'ui.bootstrap']).config(config);


    function config($routeProvider) {

        $routeProvider
            .when('/', { templateUrl: 'app/home/home.html', controller: 'HomeController', controllerAs: 'vm'})
            .when('/department', { templateUrl: 'app/department/department.html', controller: 'DepartmentController', controllerAs: 'dp' })
            .when('/employee', { templateUrl: 'app/employee/employee.html', controller: 'EmployeeController', controllerAs: 'em' })
            .otherwise({ redirectTo: '/' });
    }

})(angular);