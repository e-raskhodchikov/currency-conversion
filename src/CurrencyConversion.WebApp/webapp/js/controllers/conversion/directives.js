(function() {
    'use strict';

    angular.module('CurrencyConversion')
        .directive('converted', function() {
            return {
                restrict: 'E',
                templateUrl: '/webapp/html/pages/conversion/converted.html'
            };
        });
})();
