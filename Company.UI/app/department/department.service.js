(function (angular) {

    angular.module("app").service("departmentService",
        ['$http', 'routePrefix', '$window',
            function ($http, routePrefix, $window) {

                return {

                    getDepartments: function (pageNumber, pageSize) {

                        return $http.get(routePrefix.department + "/" + pageNumber + "/" + pageSize);
                        
                    },

                    getDeartmentsBySearch: function (search, pageNumber, pageSize) {
                        return $http.get(routePrefix.department + "/GetByName/" + search + "/" + pageNumber + "/" + pageSize);
                    }


                }
            }
        ]);

})(angular);