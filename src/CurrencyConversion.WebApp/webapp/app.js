(function() {
    'use strict';

    angular.module('CurrencyConversion', ['ngRoute'])
        .config(function($routeProvider) {
            $routeProvider
                .when('/', {
                    templateUrl: '/webapp/html/pages/conversion/index.html'
                })
                .when('/requirements', {
                    templateUrl: '/webapp/html/pages/requirements/index.html'
                })
                .when('/contact', {
                    templateUrl: '/webapp/html/pages/contact/index.html'
                })
                .otherwise({
                    redirectTo: '/'
                });
        });
})();
