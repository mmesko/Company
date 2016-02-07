(function (angular) {

    'use strict';

    angular.module('app')
        .controller('DepartmentController', ['departmentService', '$window', '$scope',
            function (departmentService, $window, $scope) {

                var dp= $scope.dp = {};
               
                dp.departments = [];
                dp.department = null;
               
                dp.searchString = "";
                dp.showDepartmentsTable = true;
              
                //pagination
                dp.pageNumber = 1;
                var pageSize = 5; // 5 alergens per page
               
               
               
                 //pagination
                dp.next = function () {

                    dp.pageNumber++;
                    dp.get();
                };

                dp.back = function () {

                    dp.pageNumber--;

                    if (dp.pageNumber < 1)
                        dp.pageNumber = 1;
                   dp.get();
                }

                dp.get = function () {

                    if (dp.searchString.length > 0) {
                       
                        departmentService.getDeartmentsBySearch(dp.searchString, dp.pageNumber, pageSize).success(function (data) {
                            dp.departments = data;
                        }).error(function (error) {
                            console.log('Unable to load table: ' + error.message);
                        });
                    }
                    else {
                        //inace mi dohvati sve
                        departmentService.getDepartments(dp.pageNumber, pageSize).success(function (data) {
                            dp.departments = data;
                            console.log("sagdhf");
                        }).error(function (error) {
                            console.log('Unable to load table: ' + error.message);
                        });
                    }

                };

       
     

            }]); 
})(angular);