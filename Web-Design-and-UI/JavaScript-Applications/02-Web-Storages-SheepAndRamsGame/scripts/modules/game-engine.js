//1. Create a simple number guessing game
define(['modules/secret-number', 'modules/input-number', 'modules/score', 'jquery'], function (secretNumberber, inputNumberber, Score) {
	var SheepAndRams = (function(secretNumberber, inputNumberber, Score) {
		var NUM_LENGTH = 4;
			secretNumber = secretNumberber.get(NUM_LENGTH),
			inputField = $("#input-number");

		function startGame() {
			secretNumber = secretNumberber.get(NUM_LENGTH);
			Score.attempts = 0;
			inputField.val('')
					  .focus();

			//clear previous attempts
			$('#guess-attempts').find('.guess').empty();
		}

		function compareNumbers(firstNumber, secondNumber) {
			var sheep = 0,
				rams = 0;

			for (var i = 0; i < secondNumber.length; i++) {
				for (var j = 0; j < firstNumber.length; j++) {
					if (firstNumber[j] === secondNumber[i]) {
						if (i === j) {
							rams++;
							break;
						}
						else {
							sheep++;
							break;
						}
					}
				}
			}

			return {
				'sheep': sheep,
				'rams': rams
			}
		}
		
		function isNumberGuessed(guesses, numberLength) {
			var isGuessed = false;
			
			if (guesses.rams === numberLength) {
				isGuessed = true;
			}
			
			return isGuessed;
		}
		
		function endGame(score) {
			Score.addScoreToStorage(score);
			Score.updateHighScores();
		}

		function displayAttempts(inputNumberber, guesses) {		
			var attemptItem = $('<td />')
				.text(inputNumberber.join(''));
			var sheepGuessed = $('<td />')
				.text(guesses.sheep)
			var ramsGuessed = $('<td />')
				.text(guesses.rams);
			
			var tableRow = $('<tr />')
				.addClass('guess')
				.append(attemptItem)
				.append(sheepGuessed)
				.append(ramsGuessed);
				
			var container = $('#guess-attempts')
				.append(tableRow);	
		}

		var buttonGuess = $('#guess-btn')
		.on('click', function() {
			var inputNumber = inputNumberber.get(NUM_LENGTH);
			
			if (inputNumber) {
				var	guesses = compareNumbers(inputNumber, secretNumber);
			
				displayAttempts(inputNumber, guesses);
				inputField.select();
				
				var isGuessed = isNumberGuessed(guesses, NUM_LENGTH);

				if (isGuessed) {
					endGame(Score.updateScore());
				} else {				
					Score.updateScore();
				}
			}
		});
		
		$(document).keyup(function (ev) {
			if (inputField.is(":focus") && (ev.keyCode === 13)) {
				buttonGuess.click();
			}
		});
		
		return {
			startGame: startGame
		};
	}(secretNumberber, inputNumberber, Score));
	
	return SheepAndRams;
});
//------------------------------------------------------------------------------------------------