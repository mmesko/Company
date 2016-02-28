(function (angular) {

    'use strict';

    angular.module('app')
        .controller('DepartmentController', ['departmentService', '$window', '$scope','notificationService',
            function (departmentService, $window, $scope, notificationService) {

                var dp= $scope.dp = {};
               
                dp.departments = [];
                dp.department = null;
                dp.selected = {};
                dp.searchString = "";
                dp.showDepartmentsTable = true;
                dp.showAddView = false;
                dp.showEditView = false;
                dp.newItem = {};
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
                       
                        departmentService.getDepartmentsBySearch(dp.searchString, dp.pageNumber, pageSize).success(function (data) {
                            dp.departments = data;
                        }).error(function (error) {
                            notificationService.addNotification(data, false);
                        });
                    }
                    else {
                        //inace mi dohvati sve
                        departmentService.getDepartments(dp.pageNumber, pageSize).success(function (data) {
                            dp.departments = data;
                        }).error(function (error) {
                            notificationService.addNotification(data, false);
                        });
                    }

                };

                dp.showAdd = function () {
                    dp.showAddView = true;
                    dp.showEditView = false;
                    dp.showDetails = false;
                };

                dp.showEdit = function (item) {
                    dp.selected = {};
                    dp.selected = item;
                    dp.showDetails = false;
                    dp.showEditView = true;
                    dp.showAddView = false;
                };

                dp.post = function (item) {
                   dp.showAddView = false;

                    departmentService.postDepartment(item)
                          .success(function (data) {
                              notificationService.addNotification("Added successfully", true);
                              dp.get();
                              dp.selected = {};
                          })
                          .error(function (data) {
                              notificationService.addNotification(data, false);
                          });
                };

               dp.put = function (item) {

                    dp.selected.departmentName = item.departmentName;
                    dp.selected.departmentLocation = item.departmentLocation;

                    departmentService.putDepartment(dp.selected)
                       .success(function (data) {
                           dp.selected = data;
                           notificationService.addNotification("Updated successfully", true);
                           dp.showEdit();
                       })
                       .error(function (data) {
                           notificationService.addNotification(data, false);
                           dp.get();

                       });
                };


                dp.delete = function (item) {

                    if (confirm("Do you wana delete item named " + item.departmentName + "?")) {

                        departmentService.deleteDepartment(item.departmentNo)
                            .success(function (data) {
                                notificationService.addNotification("Successfully deleted", true);
                                dp.get();
                                dp.selected = {};

                            })
                            .error(function (data) {
                                notificationService.addNotification(data, false);
                                dp.get();
                            });
                    }
                };

       
                dp.get();

            }]); 
})(angular);