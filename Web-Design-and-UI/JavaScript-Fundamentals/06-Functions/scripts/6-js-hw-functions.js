//1. Write a function that returns the last digit of given integer as an English word. Examples: 512 > "two", 1024 > "four", 12309 > "nine"
function findLastDigitName(number) {
    var lastDigit = number % 10;

    switch (lastDigit) {
        case 0:
            return 'zero';
        case 1:
            return 'one';
        case 2:
            return 'two';
        case 3:
            return 'three';
        case 4:
            return 'four';
        case 5:
            return 'five';
        case 6:
            return 'six';
        case 7:
            return 'seven';
        case 8:
            return 'eight';
        case 9:
            return 'nine';
        default :
            throw new TypeError('Invalid number.');
    }
}
//------------------------------------------------------------------------------------------------
//2. Write a function that reverses the digits of given decimal number. Example: 256 > 652.
function reverseNumber(number) {
    var numberAsArray,
        reversedArr,
        reversed;

    numberAsArray = number.split('').map(function (el) {
        return +el;
    });

    reversedArr = numberAsArray.reverse();
    reversed = reversedArr.join('');

    return reversed;
}
//------------------------------------------------------------------------------------------------
//3. Write a function that finds all the occurrences of word in a text. The search can case sensitive or case insensitive. Use function overloading
function wordSearch(word, text, isCaseSensitive) {
    var replaced = ' ' + text.replace(/\W+/g, ' ') + ' ', // removes punctuation
        word = " " + word + " ",	//whole word
        searchStrLen = word.length,
        startIndex = 0,
        wordIndex = 0,
        foundWordIndices = [];

    isCaseSensitive = isCaseSensitive || false;

    if (isCaseSensitive === false) {
        replaced = replaced.toLowerCase();
        word = word.toLowerCase();
    }

    while ((wordIndex = replaced.indexOf(word, startIndex)) > -1) {
        foundWordIndices.push(wordIndex);
        startIndex = wordIndex + searchStrLen;
    }

    return {
        word: word.trim(),
        count: foundWordIndices.length,
        indices: foundWordIndices
    }
}

function wordOccurrencesMessage(wordOccurrences) {
    var output = "";

    console.log(wordOccurrences.indices);
    if (wordOccurrences.count === 0) {
        return "Not found.";
    } else {
        for (var i = 0; i < wordOccurrences.indices.length; i += 1) {
            output += wordOccurrences.indices[i] + ': ' + '"' + wordOccurrences.word + '"';

            if (i < wordOccurrences.indices.length - 1) {
                output += ", ";
            }
        }

        return '"' + wordOccurrences.word + '" was found ' + wordOccurrences.count + ' times in random text. Index: ' + output;
    }
}
//------------------------------------------------------------------------------------------------
//4. Write a function to count the number of divs on the web page.
function countTags(tagToCount) {
    return divCount = document.getElementsByTagName(tagToCount).length;
}
//------------------------------------------------------------------------------------------------
//5. Write a function that counts how many times given number appears in given array. Write a test function to check if the function is working correctly.
function getFrequencyOfNum(arr, number) {
    var count = 0,
        outputStr = "";

    for (var i = 0, l = arr.length; i < l; i += 1) {
        if (number === arr[i]) {
            count++;
        }
    }

    return count;
}

//Test
function testFrequencyOfNum(arr, number, expected) {
    return getFrequencyOfNum(arr, number) === expected;
}
//------------------------------------------------------------------------------------------------
//6. Write a function that checks if the element at given position in given array of integers is bigger than its two neighbours (when such exist).
function isBiggerThanNeighbors(arr, index) {
    var l = arr.length;

    if (index < 0 || index > l - 1 || isNaN(index)) {
        throw new Error('Invalid index.');
    }

    if (index > 0 && index < l - 1 && (arr[index] > arr[index - 1] && arr[index] > arr[index + 1])
        || index === 0 && arr[0] > arr[1]
        || index === (l - 1) && arr[l - 1] > arr[l - 2]) {
        return true;
    }

    return false;
}
//------------------------------------------------------------------------------------------------
//7. Write a function that returns the index of the first element in array that is bigger than its neighbors, or -1, if there's no such element. Use the function from the previous exercise.
function firstBiggerThanNeighbours(arr) {
    var bigger;

    for (var index = 0, l = arr.length; index < l; index++) {
        bigger = isBiggerThanNeighbors(arr, index);

        if (bigger) {
            return index;
        }
    }

    return -1;
}

//------------------------------------------------------------------------------------------------