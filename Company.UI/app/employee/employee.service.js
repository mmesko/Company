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
                    },

                    postEmployee: function (data) {
                        console.log($.param(data));
                        return $http({

                            method: 'post',
                            url: routePrefix.employee + "/",
                            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                            data: $.param(data)

                        })
                    },

                   
                        putEmployee: function (data) {
                            console.log($.param(data));
                            return $http({

                                method: 'put',
                                url: routePrefix.employee + "/update/" + data.employeeNo,
                                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                                data: $.param(data)

                            })
                        },

                        deleteEmployee: function (employeeNo) {
                            console.log($.param(employeeNo));
                            return $http({

                                method: 'delete',
                                url: routePrefix.employee + "/delete/" + employeeNo,
                                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                                data: $.param(employeeNo)

                            })
                        }

                }
            }
        ]);

})(angular);