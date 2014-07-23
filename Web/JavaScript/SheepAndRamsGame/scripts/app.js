(function () {
	'use strict';
	require.config({
		paths: {
			"jquery": "../libs/jquery-2.1.1.min",
		}
	});
	require(['modules/game-engine', 'modules/score', 'jquery'], function (SheepAndRams, Score) {
			(function loadGame(SheepAndRams, Score){
				$(document).ready(Score.updateHighScores);
				
				var newGameButton = $('#new-game')
					.on('click', SheepAndRams.startGame);
					
				var sourceCode = $('#task').hide();

				var sourceCodeButton = $('#source-code-button')
						.on('click', function () {
							if	(sourceCode.css('display') == 'none') {
								sourceCode.show();
							} else {
								sourceCode.hide();
							}
						});
				}(SheepAndRams, Score));
		});
}());