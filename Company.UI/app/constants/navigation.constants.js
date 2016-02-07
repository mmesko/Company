(function (angular) {

    angular.module("app").constant("navigationLinks",
        {
            home: "#/",
            department: "#/department",
            employee: "#/employee",
            
        });

    angular.module("app").constant("routePrefix",
        {
            department:"company/api/department",
            employee:"company/api/employee"
          
        });

})(angular);