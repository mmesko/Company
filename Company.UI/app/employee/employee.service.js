(function (angular) {

    angular.module("app").service("employeeService",
        ['$http', 'routePrefix', '$window',
            function ($http, routePrefix, $window) {

                return {

                    getEmployees: function (pageNumber, pageSize) {

                        return $http.get(routePrefix.employee + "/" + pageNumber + "/" + pageSize);
                    },

                    getEmployeesBySearch: function (search, pageNumber, pageSize) {
                        return $http.get(routePrefix.employee + "/GetByName/" + search + "/" + pageNumber + "/" + pageSize);
                    }

                }
            }
        ]);

})(angular);