//1. Write a script that prints all the numbers from 1 to N.
function printNumbers(upperLimit) {
	var outputStr = "";
	
	for (var i = 1; i <= upperLimit; i++) {
		outputStr += i;
		if (i < upperLimit) {
			outputStr += ", ";
		}
	}

	return outputStr;
}
//------------------------------------------------------------------------------------------------
//2. Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.
function printNotDivBy3And7(upperLimit) {
    var outputStr = "";
	
	for (var i = 1; i <= upperLimit; i++) {
	    var divisible = (i % 3 === 0) && (i % 7 === 0); // alternative: i % 21 == 0

	    if (!divisible) {
			outputStr += i;
			if (i < upperLimit) {
			    outputStr += ", ";
			}
		}
	}

	return outputStr;
}
//------------------------------------------------------------------------------------------------
//3. Write a script that finds the max and min number from a sequence of numbers.
function findMaxAndMinNum(sequence) {
    var sequenceArr = sequence.split(",").map(function (el) {
        return +el;
    }),   //converts array string elements into numbers
      max = sequenceArr[0],
      min = sequenceArr[0];

    for (var i in sequenceArr) {
        if (sequenceArr[i] > max) {
            max = sequenceArr[i];
        } else if (sequenceArr[i] < min) {
            min = sequenceArr[i];
        }
    }

    return { max: max, min: min };
}
//-----------------------------------------------------------------------------------------------
//4. Write a script that finds the lexicographically smallest and largest property in document, window and navigator objects.
function findSLPropsInObj() {
    var arrObj = [document, window, navigator],
		outputStr = "";

	for (var i in arrObj) {
			var arr = [],
				currentObj = arrObj[i],
				smallest,
				largest;

			for (var prop in currentObj) {
				arr.push(prop);
				}
			arr.sort();	
			smallest = arr[0];
			largest = arr[arr.length-1];
			outputStr += "The smallest property of " + currentObj + "is: " + smallest + ". \nThe largest property of " + currentObj + "is: " + largest + ".\n";			
	}

	return outputStr;
}