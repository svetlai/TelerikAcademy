'use strict';

ticTacToeApp.factory('game', ['$http', '$q', 'identity', 'authorization', 'notifier', 'baseServiceUrl',
    function ($http, $q, identity, authorization, notifier, baseServiceUrl) {

        var usersApi = baseServiceUrl + '/api/games'

    return {
        createGame: function () {
            var deferred = $q.defer();
            var headers = authorization.getAuthorizationHeader();
            $http.post(usersApi + '/create', {}, { headers: headers})
                .success(function (response) {
                    deferred.resolve(response);
                }, function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        },
        joinGame: function () {
            var deferred = $q.defer();
            var headers = authorization.getAuthorizationHeader();

            $http.post(usersApi + '/join', {}, { headers: headers})
                .success(function (data) {
                    deferred.resolve(data);
                }).error(function (response) {
                    notifier.error('No game to join.')
                    deferred.reject(response);
                });

            return deferred.promise;
        },
        getAllGames: function () {
            var deferred = $q.defer();
            var headers = authorization.getAuthorizationHeader();

            $http.get(usersApi + '/all', { headers: headers})
                .success(function (data) {
                    deferred.resolve(data);
                }).error(function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;

        },
        getGameById: function (id) {
            var deferred = $q.defer();
            var headers = authorization.getAuthorizationHeader();

            $http.get(usersApi + '/byid/' + id, { headers: headers})
                .success(function (data) {
                    deferred.resolve(data);
                }, function (response) {
                    notifier.error(response.Message);
                    deferred.reject(response);
                });

            return deferred.promise;

        },
        play: function (data) {
            var deferred = $q.defer();

            //var headers = authorization.getAuthorizationHeader();
            var headers = {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded',
                    'Authorization': 'Bearer ' + identity.getCurrentUser()['access_token']
                }
            }
            $http.post(usersApi + '/play', data, headers)
                .success(function (data) {
                    deferred.resolve(data);
                }).error(function (response) {
                    notifier.error(response.Message)
                    deferred.reject(response);
                });

            return deferred.promise;
        }
    }
}])