//-------------------------------------Preview task 1----------------------------------------------
function printIncreasedArray() {
    console.log(increaseArrayNumbers());
    jsConsole.writeLine(increaseArrayNumbers());
}
//-------------------------------------Preview task 2----------------------------------------------
function printCharArraysComparison() {
    var first = ["a", "x", "c", "d"],
        second = ["k", "l", "c", "z"];

    console.log(compareCharArrays(first, second));
    jsConsole.writeLine(compareCharArrays(first, second).toString());
}
//-------------------------------------Preview task 3----------------------------------------------
function printMaxSequence() {
    var arr = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1],
        result = findMaxEqualSequence(arr);

    console.log("The maximal sequence of equal elements in the array has a total of " + result.max + " elements > " + result.maxSequence + ".");
    jsConsole.writeLine("The maximal sequence of equal elements in the array has a total of " + result.max + " elements > " + result.maxSequence + ".");
}
//-------------------------------------Preview task 4----------------------------------------------
function printMaxIncreasingSequence() {
    var arr = [2, 1, 0, 2, 3, 4, 0, 1, 3, 4, 0, 2, 1],
        result = findMaxIncreasingSequence(arr);

    console.log("The maximal sequence of increasing elements in the array has a total of " + result.max + " elements > " + result.maxSequence + ".");
    jsConsole.writeLine("The maximal sequence of increasing elements in the array has a total of " + result.max + " elements > " + result.maxSequence + ".");
}
//-------------------------------------Preview task 5----------------------------------------------
function printSelectionSort() {
    var inputArr = document.getElementById("a5").value,
        arr = inputArr.split(",").map(Number),   //converts array string elements into numbers
        result = selectionSort(arr);

    console.log(result);
    jsConsole.writeLine(result.toString());
}
//-------------------------------------Preview task 6----------------------------------------------
function printMostFrequent() {
    var inputArr = document.getElementById("a6").value,
        arr = inputArr.split(",").map(function (el) {
            return +el;
        }),	//converts array string elements into numbers
        original = [];

        for (var i = 0; i < arr.length ; i+=1) {
            original[i] = arr[i];
        }

        var result = findMostFrequent(arr);

    console.log(original + " > " + result.start + " (" + result.count + " times)");
    jsConsole.writeLine(original + " > " + result.start + " (" + result.count + " times)");
}
//-------------------------------------Preview task 7----------------------------------------------
function binarySearchBtn(inputArr, x) {
    var inputArr = document.getElementById("a7").value,
        arr = inputArr.split(",").map(function (el) {
            return +el;
        }),   //converts array string elements into numbers
        x = document.getElementById("b7").value * 1,
        result = binarySearch(arr, x);

    console.log("Your array is: [" + arr + "].\n The index of " + x  + " is " + result + ".");
    jsConsole.writeLine("Your array is: [" + arr + "].\n The index of " + x  + " is " + result + ".");
}

function clearConsole() {
    jsConsole.clear();
}