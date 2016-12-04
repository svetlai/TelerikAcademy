'use strict';

ticTacToeApp.controller('PlayController', ['$scope', '$location', '$routeParams', '$interval', 'notifier', 'game',
    function PlayController($scope, $location, $routeParams, $interval, notifier, game) {

        if ($routeParams.id != undefined) {
            getGameStatus($scope, $routeParams);

            $scope.play = function ($event) {
                var id = $event.target.id

                var row = Math.floor(id / 3) + 1;
                var col = id % 3 + 1;

                var playMove = 'GameId=' + $routeParams.id + '&Row=' + row + '&Col=' + col;
                //console.log(playMove);
                game.play(playMove);
            }

            var checkStatus = $interval(function () {
                if ($routeParams.id !== undefined) {
                    getGameStatus($scope, $routeParams)
                }
            }, 1000);
        }

        function getGameStatus($scope, $routeParams) {
            game.getGameById($routeParams.id)
            .then(function (currentGame) {
                $scope.currentGame = currentGame;
                var board = currentGame.Board;
                var squares = [];
                for (var i = 0; i < board.length; i++) {
                    //$scope.square = board[i];
                    squares.push(board[i]);
                }

                $scope.board = board;
                //console.log($scope.board);
                //console.log($scope.currentGame);

                if (currentGame.State > 2) {
                    $interval.cancel(checkStatus);
                    var state = currentGame.State;

                    switch (state) {
                        case 3: notifier.success("Won by X"); break
                        case 4: notifier.success("Won by O"); break
                        case 5: notifier.success("Draw"); break
                    }

                    //console.log(checkStatus);
                }
            });
        }
    }]);