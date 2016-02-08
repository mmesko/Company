(function (angular) {

    'use strict';

    angular.module('app')
        .controller('EmployeeController', ['employeeService', '$window', '$scope',
            function (employeeService, $window, $scope) {

                var em= $scope.em = {};
               
                em.employees = [];
                em.employee = null;
                //selected item from table
                em.selected = {};
                em.searchString = "";
                em.showEmployeeTable = true;
                em.showAddView = false;
                em.showEditView = false;
                em.newItem = {};
               em.pageNumber = 1;
                var pageSize = 5; 
               
               
               
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

               em.showAdd = function () {
                   em.showAddView = true;
                   em.showEditView = false;
                   em.showDetails = false;
               };

               em.showEdit = function (item) {
                   em.selected = {};
                   em.selected = item;
                   em.showDetails = false;
                   em.showEditView = true;
                   em.showAddView = false;
               };

               em.post = function (item) {
                   em.showAddView = false;

                   employeeService.postEmployee(item)
                         .success(function (data) {
                             console.log(data);
                             $window.alert("Added successfully!");
                             em.get();
                             em.selected = {};
                         })
                         .error(function (data) {
                             console.log($window.alert("Cannot be added!"));
                             console.log(data); //error
                         });
               };

               em.put = function (item) {

                   em.selected.employeeName = item.employeeName;
                   em.selected.salary = item.salary;

                   employeeService.putEmployee(em.selected)
                      .success(function (data) {
                          em.selected = data;
                          console.log($window.alert("User updated successfully!"));
                          em.showEdit();
                      })
                      .error(function (data) {

                          $window.alert("Name already exist!");
                          console.log(em.selected);
                          console.log(data); // error 
                          em.get();

                      });
               };


               em.delete = function (item) {

                   if (confirm("Do you wana delete item named " + item.employeeName + "?")) {

                       employeeService.deleteEmployee(item.employeeNo)
                           .success(function (data) {
                               console.log(data);
                               console.log($window.alert("Deleted"));
                               em.get();
                               em.selected = {};

                           })
                           .error(function (data) {
                               console.log(data);
                           });
                   }
               };


            }]); 
})(angular);