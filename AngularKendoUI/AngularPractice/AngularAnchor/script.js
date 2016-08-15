var app = angular.module("anchorApp", []);

app.controller("anchorController", function ($scope, $location, $anchorScroll) {
    $scope.scrollTo = function (scrollLocation) {
        $location.hash(scrollLocation);
        $anchorScroll.yOffset = 20;
        $anchorScroll();
    }
});