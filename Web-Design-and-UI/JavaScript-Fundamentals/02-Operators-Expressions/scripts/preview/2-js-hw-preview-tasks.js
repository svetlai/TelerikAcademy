//Ignore below this line. It's roughly written code for a better presentation of the homework.

//-------------------------------------Preview task 1----------------------------------------------
function oddOrEven() {
    var number = document.getElementById("enterNumber").value;  //gets the input with id "enterNumber"
    var wholeNumber = (!isNaN(number)) && (number !== "") && (number % 1 === 0); //a whole number

    if (wholeNumber) {
        if (number % 2 === 0) {   //if there's no remainder when divided by two, then it's even
            console.log("The number", number, "is even.");
            jsConsole.writeLine("The number " + number + " is even.");
        } else {
            console.log("The number", number, "is odd.");
            jsConsole.writeLine("The number " + number + " is odd.");
        }
    } else {
        console.log("Please enter a whole number.");
        jsConsole.writeLine("Please enter a whole number.");
    }
}
//-------------------------------------Preview task 2----------------------------------------------
function checkForReminder() {
    var number = document.getElementById("noRemainder").value;     //gets the input with id "noRemainder"
    var wholeNumber = (!isNaN(number)) && (number !== "") && (number % 1 === 0); //a whole number
    var noRemainder = (number % 7 === 0) && (number % 5 === 0);

    if (wholeNumber) {
        if (noRemainder) {
            console.log("The number divides by 7 & 5 without a remainder.");
            jsConsole.writeLine("The number divides by 7 & 5 without a remainder.");
        } else {
            console.log("The number doesn't divide by 7 & 5 without a remainder.");
            jsConsole.writeLine("The number doesn't divide by 7 & 5 without a remainder.");
        }
    } else {
        console.log("Please enter a whole number.");
        jsConsole.writeLine("Please enter a whole number.");
    }
}
//-------------------------------------Preview task 3---------------------------------------------
function calculateArea() {
    var height = document.getElementById("height").value;
    var width = document.getElementById("width").value;

    var isNumber = (!isNaN(height)) && (height !== "") && (!isNaN(width)) && (width !== ""); //a number

    if (isNumber) {
        var area = height * width;

        console.log("Area: " + area);
        jsConsole.writeLine("Area: " + area);
    } else {
        console.log("Please enter a number for height/width.");
        jsConsole.writeLine("Please enter a number for height/width.");
    }
}
//-------------------------------------Preview task 4---------------------------------------------
function findThirdDigit() {
    var number = document.getElementById("thirdDigit").value;     //gets the input with id "thirdDigit"
    //var digit = Number(number.toString().charAt(number.length - 3)); //converts to string to take 3rd char from the right and back to number
    //var digit = Number(number.toString()[number.length - 3]);
    var wholeNumber = (!isNaN(number)) && (number !== "") && (number % 1 === 0); //a whole number

    if (wholeNumber) {
        var digit = (number / 100) % 10 === 7; //makes 3rd digit last with a remainder 7

        if (digit) {
            console.log(number, "-> true");
            jsConsole.writeLine(number + " -> true");
        } else {
            console.log(number, "-> false");
            jsConsole.writeLine(number + " -> false");
        }
    } else {
        console.log("Please enter a whole number.");
        jsConsole.writeLine("Please enter a whole number.");
    }
}
//-------------------------------------Preview task 5---------------------------------------------
function findThirdBit() {
    var number = document.getElementById("thirdBit").value;
    var result = number >> 3;
    var wholeNumber = (!isNaN(number)) && (number !== "") && (number % 1 === 0); //a whole number

    if (wholeNumber) {
        if (result / 1 === 0) {
            console.log("The third bit of", number, "is 0.");
            jsConsole.writeLine("The third bit of " + number + " is 0.");
        }
        else {
            console.log("The third bit of", number, "is 1.");
            jsConsole.writeLine("The third bit of " + number + " is 1.");
        }
    } else {
        console.log("Please enter a whole number.");
        jsConsole.writeLine("Please enter a whole number.");
    }

}
//-------------------------------------Preview task 6---------------------------------------------
function randomPrint() {
    var x = document.getElementById("x").value;
    var y = document.getElementById("y").value;
    var radius = 5;
    var radiusPow = radius * radius;
    var p = (x * x) + (y * y);
    var isNumber = (!isNaN(x)) && (x !== "") && (!isNaN(y)) && (y !== ""); //a number and not empty

    if (isNumber) {
        if (p < radiusPow) {
            console.log("The print is WITHIN the circle K(O, 5)");
            jsConsole.writeLine("The print is WITHIN the circle K(O, 5)");
        } else if (p === radiusPow) {
            console.log("The print lies ON the circle K(O, 5)");
            jsConsole.writeLine("The print lies ON the circle K(O, 5)");
        } else {
            console.log("The print is OUTSIDE the circle K(O, 5)");
            jsConsole.writeLine("The print is OUTSIDE the circle K(O, 5)");
        }
    } else {
        console.log("Please enter a number for x/y.");
        jsConsole.writeLine("Please enter a number for x/y.");
    }
}
//-------------------------------------Preview task 7---------------------------------------------
function printPrimeNumber() {
    var n = document.getElementById("n").value | 0;
    var positiveInt = (n > 0) && (n <= 100) && (n % 1 === 0);

    if (positiveInt) {
        if (isPrime(n)) {
            console.log(n, "is prime");
            jsConsole.writeLine(n + " is prime.");
        } else {
            console.log(n, "is not prime.");
            jsConsole.writeLine(n + " is not prime.");
        }
    } else {
        console.log(n, "is not a positive integer lower or equal to 100.");
        jsConsole.writeLine(n + " is not a positive integer lower or equal to 100.");
    }
}
//-------------------------------------Preview task 8---------------------------------------------
function calculateTArea() {
    var a = document.getElementById("tsidea").value;
    var b = document.getElementById("tsideb").value;
    var h = document.getElementById("theight").value;

    var isNumber = (!isNaN(a)) && (a !== "") && (!isNaN(b)) && (b !== "") && (!isNaN(h)) && (h !== ""); //a number and not empty

    if (isNumber) {
        var tArea = ((parseInt(a) + parseInt(b)) / 2) * h;

        console.log(tArea);
        jsConsole.writeLine(tArea);
    } else {
        console.log("Please enter a number for a/b/h.");
        jsConsole.writeLine("Please enter a number for a/b/h.");
    }

}
//-------------------------------------Preview task 9---------------------------------------------
function checkRandomPoint() {
    var x = document.getElementById("xx").value;
    var y = document.getElementById("yy").value;
    var radius = 3;
    var isNumber = (!isNaN(x)) && (x !== "") && (!isNaN(y)) && (y !== ""); //a number and not empty

    if (isNumber) {
        // circle
        var pInK = ((x - 1) * (x - 1)) + ((y - 1) * (y - 1)) <= radius * radius; // the point is inside the circle; - 1 to push it to 0,0
        // rectangle
        var ax = -1;
        var by = 1;
        var cx = ax + 6;
        var dy = by - 2;
        var pNotInR = (x < ax) || (x > cx) || (y > by) || (y < dy); // the point is outside the rectangle

        var truePoint = pInK && pNotInR;    // the point is inside the circle and outside the rectangle

        if (truePoint) {
            console.log("The point is within circle K((1,1), 3) and out of rectangle R(top=1, left=-1, width=6, height=2)");
            jsConsole.writeLine("The point is within circle K((1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2)");
        } else {
            console.log("false");
            jsConsole.writeLine("false");
        }
    } else {
        console.log("Please enter a number for x/y.");
        jsConsole.writeLine("Please enter a number for x/y.");
    }
}

function clearConsole() {
    jsConsole.clear();
}