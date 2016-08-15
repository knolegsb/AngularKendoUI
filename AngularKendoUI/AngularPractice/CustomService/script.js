var app = angular.module("stringModule", []);

app.controller("stringController", function ($scope, stringService) {
    $scope.tranformString = function (input) {
        //if (!input) {
        //    return input;
        //}

        //var output = "";

        //for (var i = 0; i < input.length; i++) {
        //    if (i > 0 && input[i] == input[i].toUpperCase()) {
        //        output = output + " ";
        //    }
        //    output = output + input[i];
        //}
        //$scope.output = output;

        $scope.output = stringService.processString(input);
    }
});