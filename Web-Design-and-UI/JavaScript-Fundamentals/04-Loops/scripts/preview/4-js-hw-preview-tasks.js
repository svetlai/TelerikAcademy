//-------------------------------------Preview task 1----------------------------------------------
function printNumbersOnClick(number) {
    var number =  document.getElementById("a1").value * 1, //number
        isInteger = !isNaN(number) && (number !== "") && (number % 1 === 0);

    if (isInteger && number > 0) {
        console.log(printNumbers(number));
        jsConsole.writeLine(printNumbers(number));
    } else {
        console.log("Enter a valid number.");
        jsConsole.writeLine("Enter a valid number.");
    }
}
//-------------------------------------Preview task 2----------------------------------------------
function printNotDivBy3And7OnClick(number) {
    var number =  document.getElementById("a2").value * 1, //number
        isInteger = !isNaN(number) && (number !== "") && (number % 1 === 0);

    if (isInteger && number > 0) {
        console.log(printNotDivBy3And7(number));
        jsConsole.writeLine(printNotDivBy3And7(number));
    } else {
        console.log("Enter a valid number.");
        jsConsole.writeLine("Enter a valid number.");
    }
}
//-------------------------------------Preview task 3----------------------------------------------
function findMaxAndMinNumBtn(sequence) {
    var sequence = document.getElementById("a3").value,
        maxAndMinNum = findMaxAndMinNum(sequence);

    console.log("The max value is: " + maxAndMinNum.max);
    console.log("The min value is: " + maxAndMinNum.min);
    jsConsole.writeLine("The max value is: " + maxAndMinNum.max);
    jsConsole.writeLine("The min value is: " + maxAndMinNum.min);
}
//-------------------------------------Preview task 4----------------------------------------------
function findSLPropsInObjBtn(obj) {
    console.log(findSLPropsInObj());
    jsConsole.writeLine(findSLPropsInObj());
}

function clearConsole() {
    jsConsole.clear();
}