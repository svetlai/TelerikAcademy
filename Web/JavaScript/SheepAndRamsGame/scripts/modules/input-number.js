define(function () {
	var InputNumber = (function() {
			
		function getInputNumber(numberLength) {
			var input = $('#input-number')
						.val();
					
			var isValid = isInputValid(input, numberLength);
				
			if (isValid) {
				var inputNumber = input.split('')
					.map(Number);	

				return inputNumber;
			} else {
				alert('You must enter four different digits!');
			}
		}
			
		function isInputValid(input, inputLength) {
			var isInputValid = true;
			
		//In case you don't want to allow the input number to start with a 0, uncomment these lines:
			// if (Math.floor(input / 1000) === 0) {
				// isInputValid = false;
			// }	
			
			if (input.length > inputLength || inputLength > input.length || isNaN(input)) {
				isInputValid = false;
			}  else {
				var sorted = input.split('').sort(function(a, b) {
						return a - b;
					});
					
				for (var i = 1; i < sorted.length; i++) {		
					var currentDigit = sorted[i];

					if (currentDigit === sorted[i - 1]) {				
						isInputValid = false;
					}
				}
			}

			return isInputValid;
		}

		return {
			get: getInputNumber
		}
	}());
		
	return InputNumber;
});
