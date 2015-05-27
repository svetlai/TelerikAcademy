//-------------------------------------Preview task 1----------------------------------------------
function printLastDigitName() {
    var number = document.getElementById("a1").value * 1;

    console.log(number + ' > ' + findLastDigitName(number));
    jsConsole.writeLine(number + ' > ' + findLastDigitName(number));
}
//-------------------------------------Preview task 2----------------------------------------------
function printReversedNumber(number) {
    var number = document.getElementById("a2").value;

    console.log(reverseNumber(number));
    jsConsole.writeLine(reverseNumber(number));
}
//-------------------------------------Preview task 3----------------------------------------------
function printWordOccurences() {
    var text = document.getElementById("randomtext").innerHTML,
        word = document.getElementById("a3").value,
        caseSensitive = document.getElementById("b3"),
        isCaseSensitive = false;

    if (caseSensitive.checked) {
        isCaseSensitive = true;
    }

    var wordOccurrences = wordSearch(word, text, isCaseSensitive);

    console.log(wordOccurrencesMessage(wordOccurrences));
    jsConsole.writeLine(wordOccurrencesMessage(wordOccurrences));
}
//-------------------------------------Preview task 4----------------------------------------------
function printCountedTags(tagToCount) {
    var divCount = countTags(tagToCount);

    console.log("The number of " + tagToCount + " tags on this web page is " + divCount + ".");
    jsConsole.writeLine("The number of " + tagToCount + " tags on this web page is " + divCount + ".");
}
//-------------------------------------Preview task 5----------------------------------------------
function printFrequencyOfNum() {
    var arr = [1, 5, 3, 2, 9, 0, 6, 5, 2, 0],
        number = 0,
        count = getFrequencyOfNum(arr, number);

    console.log("In [" + arr + "] " + number + " appears " + count + " times.");
    jsConsole.writeLine("In [" + arr + "] " + number + " appears " + count + " times.");
}

function printTestFrequencyResults() {
    var arr = [1, 5, 3, 2, 9, 0, 6, 5, 2, 0],
        number = 0;

    console.log(testFrequencyOfNum(arr, number, 2));
    jsConsole.writeLine(testFrequencyOfNum(arr, number, 2));
}
//-------------------------------------Preview task 6----------------------------------------------
function printCheckNeighbors(index) {
    var arr = [2, 3, 4, 5, 6, 7, 1, 3, 7, 8],
        index = document.getElementById("a6").value * 1,
        isBigger;

    try {
        isBigger = isBiggerThanNeighbors(arr, index);

        console.log('Bigger than neighbors: ' + isBigger);
        jsConsole.writeLine('Bigger than neighbors: ' + isBigger.toString());
    } catch (exception) {
        console.log(exception.message);
        jsConsole.writeLine(exception.message);
    }
}
//-------------------------------------Preview task 7----------------------------------------------
function printFirstBiggerThanNeighbours() {
    var arr = document.getElementById("a7").value.split(",").map(Number);

    console.log(firstBiggerThanNeighbours(arr));
    jsConsole.writeLine(firstBiggerThanNeighbours(arr).toString());
}

function clearConsole() {
    jsConsole.clear();
}