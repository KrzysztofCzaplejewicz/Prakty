(function () {
    'use strict';

    var EmpApp = angular.module('EmpApp', ['ngRoute', 'TeamControllers']);
    EmpApp.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/list',
                {
                    templateUrl: 'Team/list.html',
                    controller: 'ListController'
                }).
            when('/create',
                {
                    templateUrl: 'Team/edit.html',
                    controller: 'EditController'
                }).
            when('/edit/:id',
                {
                    templateUrl: 'Team/edit.html',
                    controller: 'EditController'
                }).
            when('/delete/:id',
                {
                    templateUrl: 'Team/delete.html',
                    controller: 'DeleteController'
                }).
            otherwise(
                {
                    redirectTo: '/list'
                });
    }]);
    
})();