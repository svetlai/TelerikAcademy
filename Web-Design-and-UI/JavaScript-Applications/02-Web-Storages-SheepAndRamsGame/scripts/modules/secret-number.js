define(function () {
	var SecretNumber = (function() {
	
		function getSecretNumber(numberLength) {
			var secretNumber = [];

			secretNumber[0] = getRandomValue(1, 9);
			
			while (secretNumber.length < numberLength) {
				var randomNumber = getRandomValue(0, 9),
					digitExists = isDigitInNumber(randomNumber, secretNumber);
				
				if (!digitExists) {
					secretNumber.push(randomNumber);				
				}	
			}
			return secretNumber;
		}

		function getRandomValue(min, max) {
			return (Math.random() * (max - min) + min) | 0;
		}
		
		function isDigitInNumber(digit, numberAsArray) {
			var digitExists = false;

			for (var j = 0; j < numberAsArray.length; j++) {
				if (digit === numberAsArray[j]) {	
					digitExists = true;
					break;
				}
			}
			
			return digitExists;
		}

		return {
			get: getSecretNumber
		}
	}());
		
	return SecretNumber;
});