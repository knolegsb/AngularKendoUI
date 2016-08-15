(function(){
    'use strict';

    var app = angular.module('ngKendoApp', ['ngRoute', 'kendo.directives']);

    app.config(['$routeProvider', function($routeProvider){
        $routeProvider
            .when('/', { templateUrl: 'app/welcome/welcome.html' })
            .when('/welcome2', { templateUrl: 'app/welcome/welcome2.html' })
            .when('/welcome3', { templateUrl: 'app/welcome/welcome3.html' })
            .when('/dataSource', { templateUrl: 'app/dataSource/dataSource.html' })
            .when('/modal', { templateUrl: 'app/modal/modalWindow.html' })
            .when('/globalEvents', { templateUrl: 'app/globalEvents/globalEvents.html' })
            .otherwise({ redirectTo: '/' });
    }
        
    ]);
})();