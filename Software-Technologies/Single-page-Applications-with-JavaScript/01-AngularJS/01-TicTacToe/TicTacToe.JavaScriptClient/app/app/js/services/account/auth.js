'use strict';

ticTacToeApp.factory('auth', ['$http', '$q', 'identity', 'authorization', 'baseServiceUrl', function ($http, $q, identity, authorization, baseServiceUrl) {
    var usersApi = baseServiceUrl + '/api/users'

    return {
        signup: function(user) {
            var deferred = $q.defer();

            $http.post(usersApi + '/register', user)
                .success(function() {
                    deferred.resolve();
                }, function(response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        },
        login: function(user){
            var deferred = $q.defer();
            user['grant_type'] = 'password';
			var data = 'username=' + user.username + '&password=' + user.password + '&grant_type=password';
			var headers = { 
				headers: {
				'Content-Type': 'application/x-www-form-urlencoded'
				} 
			}			
            
			$http.post(usersApi + '/login', data, headers)
                .success(function(response) {
                    if (response["access_token"]) {
                        identity.setCurrentUser(response);
                        deferred.resolve(true);
                    }
                    else {
                        deferred.resolve(false);
                    }
                });

            return deferred.promise;
        },
        logout: function() {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.post(usersApi + '/logout', {}, { headers: headers })
                .success(function() {
                    identity.setCurrentUser(undefined);
                    deferred.resolve();
                });

            return deferred.promise;
        },
        isAuthenticated: function() {
            if (identity.isAuthenticated()) {
                return true;
            }
            else {
                return $q.reject('not authorized');
            }
        }
    }
}])