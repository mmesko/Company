(function (angular) {

    angular.module("app").service("departmentService",
        ['$http', 'routePrefix', '$window',
            function ($http, routePrefix, $window) {

                return {

                    getDepartments: function (pageNumber, pageSize) {

                        return $http.get(routePrefix.department + "/" + pageNumber + "/" + pageSize);
                        
                    },

                    getDepartmentsBySearch: function (search, pageNumber, pageSize) {
                        return $http.get(routePrefix.department + "/GetByName/" + search + "/" + pageNumber + "/" + pageSize);
                    },

                    postDepartment: function (data) {
                        console.log($.param(data));
                        return $http({

                            method: 'post',
                            url: routePrefix.department + "/",
                            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                            data: $.param(data)

                        })
                    },


                    putDepartment: function (data) {
                        console.log($.param(data));
                        return $http({

                            method: 'put',
                            url: routePrefix.department + "/update/" + data.departmentNo,
                            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                            data: $.param(data)

                        })
                    },

                    deleteDepartment: function (departmentNo) {
                        console.log($.param(departmentNo));
                        return $http({

                            method: 'delete',
                            url: routePrefix.department + "/delete/" + departmentNo,
                            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
                            data: $.param(departmentNo)

                        })
                    }


                }
            }
        ]);

})(angular);