'use strict'

ticTacToeApp.filter('board', function () {
    return function (input) {
        switch (input) {
            case '-': return " "; break
            case 'X': return 'X'; break
            case 'O': return 'O'; break
        }
    }
});