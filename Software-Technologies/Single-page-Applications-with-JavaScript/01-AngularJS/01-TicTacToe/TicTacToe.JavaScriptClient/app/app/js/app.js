'use strict';
var routeUserChecks = {
    adminRole: {
        authenticate: function (auth) {
            return auth.isAuthorizedForRole('admin');
        }
    },
    authenticated: {
        authenticate: function (auth) {
            return auth.isAuthenticated();
        }
    }
};

var ticTacToeApp = angular.module('ticTacToeApp', ['ngRoute', 'ngResource', 'ngCookies']).
    config(['$routeProvider', function($routeProvider) {
        $routeProvider
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'RegisterController'
            })
            .when('/login', {
                templateUrl: 'views/partials/login.html',
                controller: 'LoginController'
            })
            .when('/game/:id', {
                templateUrl: 'views/partials/game-details.html',
                controller: 'PlayController',
                resolve: routeUserChecks.authenticated
            })
            .when('/game', {
                templateUrl: 'views/partials/game.html',
                controller: 'GameController',
                resolve: routeUserChecks.authenticated
            })
            .otherwise({ redirectTo: '/game' });
    }])
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://localhost:33257');

ticTacToeApp.run(function ($rootScope, $location) {
    $rootScope.$on('$routeChangeError', function (ev, current, previous, rejection) {
        if (rejection === 'not authorized') {
            $location.path('/login');
        }
    })
});