(function (angular) {

    'use strict';

    angular.module('app')
        .controller('EmployeeController', ['employeeService', '$window', '$scope',
            function (employeeService, $window, $scope) {

                var em= $scope.em = {};
               
                em.employees = [];
                em.employee = null;
                //selected item from table
               
                em.searchString = "";
                em.showEmployeeTable = true;
              
               em.pageNumber = 1;
                var pageSize = 5; // 5 alergens per page
               
               
               
                 //pagination
                em.next = function () {

                    em.pageNumber++;
                    em.get();
                };

                em.back = function () {

                    em.pageNumber--;

                    if (em.pageNumber < 1)
                        em.pageNumber = 1;
                   em.get();
                }

               em.get = function () {

                    if (em.searchString.length > 0) {
                       
                        employeeService.getEmployeesBySearch(em.searchString, em.pageNumber, pageSize).success(function (data) {
                            em.employees = data;
                        }).error(function (error) {
                            console.log('Unable to load table: ' + error.message);
                        });
                    }
                    else {
                        //inace mi dohvati sve
                        employeeService.getEmployees(em.pageNumber, pageSize).success(function (data) {
                            em.employees = data;
                        }).error(function (error) {
                            console.log('Unable to load table: ' + error.message);
                        });
                    }

                };

            }]); 
})(angular);