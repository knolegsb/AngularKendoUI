(function(){
    'use strict';

    var app = angular.module('ngKendoApp', ['ngRoute', 'kendo.directives']);

    app.config(['$routeProvider', function($routeProvider){
        $routeProvider
            .otherwise({ redirectTo: '/' });
    }
        
    ]);
})();