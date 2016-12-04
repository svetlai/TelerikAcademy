'use strict';

ticTacToeApp.controller('GameController', ['$scope', '$location', 'notifier', 'game',
    function GameController($scope, $location, notifier, game) {

        $scope.create = function () {
            game.createGame()
                .then(function (gameId) {
                    console.log(gameId);
                    $location.path('/game/' + JSON.parse(gameId));
                    notifier.success('Game created! Waiting for second player.');
                });
        }

        $scope.join = function () {
            game.joinGame()
            .then(function (gameId) {
                //console.log(JSON.parse(gameId));
                $location.path('/game/' + JSON.parse(gameId));      //location starts from index
                notifier.success('Game joined successfuly.');
                //$scope.game = game.getGameById(gameId)
            });
        }

        game.getAllGames()
        .then(function (data) {
            $scope.games = data;
        });
}]);