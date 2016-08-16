var app = angular.module("sortingModule", [])
                .controller("sortingController", function ($scope) {
                    var employees = [
                        { Name: "Ben", DateOfBirth: new Date("November 23, 1980"), Gender: "Male", Salary: 55000 },
                        { Name: "Sara", DateOfBirth: new Date("May 05, 1970"), Gender: "Female", Salary: 68000 },
                        { Name: "Mark", DateOfBirth: new Date("August 15, 1974"), Gender: "Male", Salary: 57000 },
                        { Name: "Pam", DateOfBirth: new Date("October 27, 1979"), Gender: "Female", Salary: 53000 },
                        { Name: "Todd", DateOfBirth: new Date("December 30, 1983"), Gender: "Male", Salary: 60000 },
                    ];

                    $scope.employees = employees;
                    $scope.sortColumn = "Name";
                    $scope.reverseSort = false;

                    $scope.sortData = function (column) {
                        $scope.reverseSort = ($scope.sortColumn == column) ? !$scope.reverseSort : false;
                        $scope.sortColumn = column;
                    }

                    $scope.getSortClass = function (column) {
                        if ($scope.sortColumn == column) {
                            return $scope.reverseSort ? 'arrow-down' : 'arrow-up'
                        }

                        return '';
                    }
                });