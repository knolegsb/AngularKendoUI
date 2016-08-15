var app = angular.module("sqlApp", []);

app.controller("countryController", function ($scope, $http, $location, $anchorScroll) {
    $http.get("EmployeeService.asmx/GetData").then(function (response) {
        $scope.countries = response.data;
    });
    $scope.scrollTo = function (countryName) {
        $location.hash(countryName);
        $anchorScroll();
    }
});

app.controller("employeeController", function ($scope) {
    $scope.getEmployee = function () {
        $.ajax({
            type: "POST",
            url: "EmployeeService.asmx/GetEmployeeDetails",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "xml",
            success: function (data) {
                $(data).find('Table').each(function (i, row) {
                    $scope.Id = $(row).find('Id').text();
                    $scope.FirstName = $(row).find('FirstName').text();
                    $scope.LastName = $(row).find('LastName').text();
                    $scope.Address = $(row).find('Address').text();
                    $scope.City = $(row).find('City').text();
                    $scope.Pincode = $(row).find('Pincode').text();
                    $scope.State = $(row).find('State').text();
                    $scope.Country = $(row).find('Country').text();
                });
            }
        });
    };

    $scope.save = function () {
        $.ajax({
            type: "POST",
            url: "EmployeeService.asmx/InsertEmployee",
            data: "{'empId':'" + $scope.EmpId + "', 'firstName':'" + $scope.EmpFirstName + "', 'lastName':'" + $scope.EmpLastName + "', 'address':'" + $scope.EmpAddress + "', 'city':'" + $scope.EmpCity + "','pincode':'" + $scope.EmpPincode + "','state':'" + $scope.EmpState + "','country':'" + $scope.country + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert(data.d);
            },
            error: function (data) {
                alert(data.d);
            }
        });
    };
});