define(function () {
	var Score = (function() {
		var attempts = 0,
			score = '',
			scoreList = [];
		
		function updateScore() {	
			attempts++;
			score = attempts
			
			return score;
		}
		
		function sortScoresAscending (a, b) {
			if (a.score < b.score) {
					return -1;
			}
			
			if (a.score > b.score) {
				return 1;
			}
				
			return 0;
		}
		
		function addScoreToStorage (score) {
			var	playerName = replaceTag(prompt('You scored: ' + score + '. Enter your name:') || 'Guest');
			
			scoreList.push({
							name: playerName,
							score: score
						});
						
			if (localStorage['SheepAndRamsScore'] === undefined) {
				localStorage.setItem('SheepAndRamsScore', JSON.stringify(scoreList));
			} else {
				var storageEntries = JSON.parse(localStorage.getItem('SheepAndRamsScore'));
						storageEntries.push({
							name: playerName,
							score: score
						});
					
					storageEntries = storageEntries.sort(sortScoresAscending);

				localStorage.setItem('SheepAndRamsScore', JSON.stringify(storageEntries));
			}
		}
		
		function replaceTag(input) {
            input = input.replace('<', '&lt;');
            input = input.replace('>', '&gt;');
			input = input.replace('&', '&amp;');
			
            return input;
        }
		
		function updateHighScores() {
			var HIGH_SCORES_COUNT = 10,
				highScoreBoard = $('#high-score-board');

			//remove a child node to keep high-score board length lower than highScoresCount
			while (highScoreBoard.children().length > 0) {
				highScoreBoard.empty();
			}
			
			//get all high-scores from localStorage		
			var storageEntries = JSON.parse(localStorage.getItem('SheepAndRamsScore'));
				
			//add scores to high-scores board
			if (storageEntries && storageEntries.length > 0)
				for (var i = 0; i < storageEntries.length && i < HIGH_SCORES_COUNT; i++) {
					var highScore = storageEntries[i],
						scoreListItem = $('<li />')
										.text(highScore['name'] + ' : ' + highScore['score'] + ' guesses')
										.appendTo(highScoreBoard);
			}
		}
		
		return {
			attempts: attempts,
			score: score,
			updateScore: updateScore,
			addScoreToStorage: addScoreToStorage,
			updateHighScores: updateHighScores
		}
		
	}());
		
	return Score;
});