'use strict'

ticTacToeApp.filter('state', function () {
    return function (input) {
        switch (input) {
            case 0: return "Waiting For Second Player"; break
            case 1: return "X's turn"; break
            case 2: return "O's turn"; break
            case 3: return "Won by X"; break
            case 4: return "Won by O"; break
            case 5: return "Draw"; break
        }
    }
});