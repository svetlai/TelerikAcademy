//1. Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.
var a = 2,
    b = 1,
    temp = a;

if (a > b) {
    a = b;
    b = temp;
}

// console.log(a + ' ' + b);

//------------------------------------------------------------------------------------------------
//2. Write a script that shows the sign (+ or -) of the product of three real numbers without calculating it. Use a sequence of if statements.
var a = 0,
    b = 0,
    c = 0,
    negativeCount = 0;

var arr = [a, b, c];

for (var i = 0; i < arr.length; i += 1) {
    if (arr[i] < 0) {
        negativeCount++;
    }
}

if (negativeCount % 2 === 0) {
    console.log("The sign of the product of a * b * c is + .");
} else {
    console.log("The sign of the product of a * b * c is - .");
}
//------------------------------------------------------------------------------------------------
//3. Write a script that finds the biggest of three integers using nested if statements.
var a = 0,
    b = 0,
    c = 0,
    isInteger = (!isNaN(a)) && (a !== "") && (a % 1 === 0) && (!isNaN(b)) && (b !== "") && (b % 1 === 0) && (c !== "") && (c % 1 === 0);

if (isInteger) {
    if (a >= b) {
        if (a > c) {
            if (a === b) {
                console.log("a and b are equal.");
            } else {
                console.log("a is the biggest number.");
            }
        } else if (a === c) {
            if (b === c) {
                console.log("a, b and c are equal.");
            } else {
                console.log("a and c are equal.");
            }
        } else {
            console.log("c is the biggest number.");
        }
    } else if (b > a) {
        if (b > c) {
            console.log("b is the biggest number.");
        } else if (b === c) {
            console.log("b and c are equal.");
        } else {
            console.log("c is the biggest number.");
        }
    } else {
        console.log("a, b or c is empty or not an integer.");
    }
}
//-----------------------------------------------------------------------------------------------
//4. Sort 3 real values in descending order using nested if statements.
var a = 0,
    b = 0,
    c = 0,
    temp = a,
    temp2 = a,
    isInteger = (!isNaN(a)) && (a !== "") && (a % 1 === 0) && (!isNaN(b)) && (b !== "") && (b % 1 === 0) && (c !== "") && (c % 1 === 0);

if (isInteger) {
    if (a >= b) {
        if (a >= c) {
            if (b < c) {    // a, c, b
                temp = b;
                a = a;
                b = c;
                c = temp;
                console.log(a, b, c);
            } else {    // b > c : a, b, c
                a = a;
                b = b;
                c = c;
                console.log(a, b, c);
            }
        } else {        //a >=b && a < c : c, a,  b
            temp = a;
            temp2 = b;
            a = c;
            b = temp;
            c = temp2;
            console.log(a, b, c);
        }
    } else {        // b > a
        if (b >= c) {       //b, c, a
            if (a <= c) {
                temp = a;
                temp2 = b;
                a = temp2;
                b = c;
                c = temp;
                console.log(a, b, c);
            } else {    // a > c : b, a, c
                temp = a;
                a = b;
                b = temp;
                c = c;
                console.log(a, b, c);
            }
        } else {        //b < c : c, b, a
            temp = a;
            a = c;
            b = b;
            c = temp;
            console.log(a, b, c);
        }
    }
} else {
    console.log("a, b or c is empty or not an integer.");
}
//----------------------------------------------------------------------------------------------
//5. Write script that asks for a digit and depending on the input shows the name of that digit (in English) using a switch statement.
var digit = parseInt(document.getElementById("a5").value);

switch (digit) {
    case 0:
        console.log("zero");
        break;
    case 1:
        console.log("one");
        break;
    case 2:
        console.log("two");
        break;
    case 3:
        console.log("three");
        break;
    case 4:
        console.log("four");
        break;
    case 5:
        console.log("five");
        break;
    case 6:
        console.log("six");
        break;
    case 7:
        console.log("seven");
        break;
    case 8:
        console.log("eight");
        break;
    case 9:
        console.log("nine");
        break;
    default:
        console.log("error");
        break;
}
//----------------------------------------------------------------------------------------------
/*6. Write a script that enters the coefficients a, b and c of a quadratic equation
 a*x2 + b*x + c = 0
 and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.*/
var a = parseInt(document.getElementById("a6").value),
    b = parseInt(document.getElementById("b6").value),
    c = parseInt(document.getElementById("c6").value),

    discriminant = Math.sqrt(b * b - 4 * a * c),
    x = 0,
    x0 = (-b / (2 * a)),
    x1 = (-b + discriminant) / (2 * a),
    x2 = (-b - discriminant) / (2 * a);

if (discriminant > 0) {
    console.log("There are two real roots:", x1, "and", x2);
} else if (discriminant === 0) {
    console.log("There is one real root:", x0);
} else {
    console.log("There are no real roots");
}
//----------------------------------------------------------------------------------------------
//7. Write a script that finds the greatest of given 5 variables.
var a = document.getElementById("a7").value,
    b = document.getElementById("b7").value,
    c = document.getElementById("c7").value,
    d = document.getElementById("d7").value,
    e = document.getElementById("e7").value;

var largest = Math.max(a, b, c, d, e);

console.log(largest);
//----------------------------------------------------------------------------------------------
//8. Write a script that converts a number in the range [0...999] to a text corresponding to its English pronunciation.
function numberName() {
    var number = parseInt(document.getElementById("a8").value),
        digit1 = number % 10,
        digit10 = parseInt(number / 10) % 10,
        digit100 = parseInt(number / 100) % 10;

    function returnDigitName(number) {
        var digName = "";

        switch (number) {
            case 1:
                digName = "One";
                break;
            case 2:
                digName = "Two";
                break;
            case 3:
                digName = "Three";
                break;
            case 4:
                digName = "Four";
                break;
            case 5:
                digName = "Five";
                break;
            case 6:
                digName = "Six";
                break;
            case 7:
                digName = "Seven";
                break;
            case 8:
                digName = "Eight";
                break;
            case 9:
                digName = "Nine";
                break;
        }
        return digName;
    }

    if (isNaN(number)) {
        console.log("This is not a number.");
        jsConsole.writeLine("This is not a number.");
    } else if (number > 999 || number < 0) {
        console.log("Type a number between 0 & 999");
        jsConsole.writeLine("Type a number between 0 & 999");
    } else {
        if (digit1 === 0 && digit10 === 0 && digit100 === 0) {      //zero
            console.log("Zero");
            jsConsole.write("Zero");
        }
        else if (digit10 === 0 && digit100 === 0) {                 // 1 - 10
            console.log(returnDigitName(digit1));
            jsConsole.write(returnDigitName(digit1));
        }
        if (digit100 !== 0) {
            console.log(returnDigitName(digit100) + " Hundred ");       //hundreds
            jsConsole.write(returnDigitName(digit100) + " Hundred ");
            if (digit1 !== 0 || digit10 !== 0) {
                console.log("and ");
                jsConsole.write("and ");

            }
        }
        if (digit10 !== 0) {                                        //tens
            if (digit10 === 1) {
                switch (digit1) {                                   //10 - 19
                    case 0:
                        console.log("Ten");
                        jsConsole.write("Ten");
                        break;
                    case 1:
                        console.log("Eleven");
                        jsConsole.write("Eleven");
                        break;
                    case 2:
                        console.log("Twelve");
                        jsConsole.write("Twelve");
                        break;
                    case 3:
                        console.log("Thirteen");
                        jsConsole.write("Thirteen");
                        break;
                    case 5:
                        console.log("Fifteen");
                        jsConsole.write("Fifteen");
                        break;
                    case 8:
                        console.log("Eighteen");
                        jsConsole.write("Eighteen");
                        break;
                    default:
                        console.log(returnDigitName(digit1) + "teen");
                        jsConsole.write(returnDigitName(digit1) + "teen");
                        break;
                }
            }
            else {
                switch (digit10) {                          //20-90
                    case 2:
                        console.log("Twenty");
                        jsConsole.write("Twenty ");
                        break;
                    case 3:
                        console.log("Thirty");
                        jsConsole.write("Thirty ");
                        break;
                    case 5:
                        console.log("Fifty");
                        jsConsole.write("Fifty ");
                        break;
                    case 8:
                        console.log("Eighty");
                        jsConsole.write("Eighty ");
                        break;
                    default:
                        console.log(returnDigitName(digit10) + "ty");
                        jsConsole.write(returnDigitName(digit10) + "ty ");
                        break;
                }
            }
        }
        if (digit1 !== 0 && digit10 !== 1 && digit100 !== 0 || digit1 !== 0 && digit10 !== 1 && digit10 !== 0)    //adds last digit if over 20
        {
            console.log(returnDigitName(digit1));
            jsConsole.write(returnDigitName(digit1));
        }
        jsConsole.writeLine("");
    }
}