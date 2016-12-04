'use strict';

ticTacToeApp.controller('RegisterController', ['$scope', '$location', 'auth', 'notifier',
    function RegisterController($scope, $location, auth, notifier) {
    $scope.signup = function(user) {
        auth.signup(user).then(function() {
            notifier.success('Registration successful!');
            $location.path('/');
        })
    }
}]);