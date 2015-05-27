//Ignore below this line. It's roughly written code for a better presentation of the homework (basically the same code put in functions).

//-------------------------------------Preview task 1----------------------------------------------
function swapValues() {
    var a = document.getElementById("a1").value,
        b = document.getElementById("b1").value,
        temp = a,
        wholeNumber = (!isNaN(a)) && (a !== "") && (a % 1 === 0) && (!isNaN(b)) && (b !== "") && (b % 1 === 0); //a whole number

    if (wholeNumber) {
        if (a > b) {
            a = b;
            b = temp;
        }

        console.log(a + ' ' + b);
        jsConsole.writeLine(a + ' ' + b);
    } else {
        console.log("a or b is not an integer.");
        jsConsole.writeLine("a or b is not an integer.");
    }
}
//-------------------------------------Preview task 2---------------------------------------------
function showSign() {
    var a = document.getElementById("a2").value,
        b = document.getElementById("b2").value,
        c = document.getElementById("c2").value,
        negativeCount = 0,
        isInteger = (!isNaN(a)) && (a !== "") && (a % 1 === 0) && (!isNaN(b)) && (b !== "") && (b % 1 === 0) && (!isNaN(c)) && (c !== "") && (c % 1 === 0);

    if (isInteger) {
        var arr = [a, b, c];

        for (var i = 0; i < arr.length; i+=1) {
            if (arr[i] < 0){
                negativeCount++;
            }
        }

        if (negativeCount % 2 === 0) {
            console.log("The sign of the product of a * b * c is + .");
            jsConsole.writeLine("The sign of the product of a * b * c is + .");
        } else {
            console.log("The sign of the product of a * b * c is - .");
            jsConsole.writeLine("The sign of the product of a * b * c is - .");
        }
    } else {
        console.log("a, b or c is not an integer.");
        jsConsole.writeLine("a, b or c is not an integer.");
    }
}
//-------------------------------------Preview task 3---------------------------------------------
function findBiggest() {
    var a = parseInt(document.getElementById("a3").value),
        b = parseInt(document.getElementById("b3").value),
        c = parseInt(document.getElementById("c3").value),
        isInteger = (!isNaN(a)) && (a !== "") && (a % 1 === 0) && (!isNaN(b)) && (b !== "") && (b % 1 === 0) && (!isNaN(c)) && (c !== "") && (c % 1 === 0);

    if (isInteger) {
        if (a >= b) {
            if (a > c) {
                if (a === b) {
                    console.log("a and b are equal.");
                    jsConsole.writeLine("a and b are equal.");
                } else {
                    console.log("a is the biggest number.");
                    jsConsole.writeLine("a is the biggest number.");
                }
            } else if (a === c) {
                if (b === c) {
                    console.log("a, b and c are equal.");
                    jsConsole.writeLine("a, b and c are equal.");
                } else {
                    console.log("a and c are equal.");
                    jsConsole.writeLine("a and c are equal.");
                }
            } else {
                console.log("c is the biggest number.");
                jsConsole.writeLine("c is the biggest number.");
            }
        } else if (b > a) {
            if (b > c) {
                console.log("b is the biggest number.");
                jsConsole.writeLine("b is the biggest number.");
            } else if (b === c) {
                console.log("b and c are equal.");
                jsConsole.writeLine("b and c are equal.");
            } else {
                console.log("c is the biggest number.");
                jsConsole.writeLine("c is the biggest number.");
            }
        }
    } else {
        console.log("a, b or c is empty or not an integer.");
        jsConsole.writeLine("a, b or c is empty or not an integer.");
    }
}
//-------------------------------------Preview task 4---------------------------------------------
function sortDescending() {
    var a = parseInt(document.getElementById("a4").value),
        b = parseInt(document.getElementById("b4").value),
        c = parseInt(document.getElementById("c4").value),
        temp = a,
        temp2 = a,
        realNumber = (!isNaN(a)) && (a !== "") && (!isNaN(b)) && (b !== "") && (!isNaN(c)) && (c !== "");  //a number and not empty

    if (realNumber) {
        if (a >= b) {
            if (a >= c) {
                if (b < c) {    // a, c, b
                    temp = b;
                    a = a;
                    b = c;
                    c = temp;
                    console.log(a, b, c);
                    jsConsole.writeLine(a + " " + b + " " + c);
                } else {    // b > c : a, b, c
                    a = a;
                    b = b;
                    c = c;
                    console.log(a, b, c);
                    jsConsole.writeLine(a + " " + b + " " + c);
                }
            } else {        //a >=b && a < c : c, a,  b
                temp = a;
                temp2 = b;
                a = c;
                b = temp;
                c = temp2;
                console.log(a, b, c);
                jsConsole.writeLine(a + " " + b + " " + c);
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
                    jsConsole.writeLine(a + " " + b + " " + c);
                } else {    // a > c : b, a, c
                    temp = a;
                    a = b;
                    b = temp;
                    c = c;
                    console.log(a, b, c);
                    jsConsole.writeLine(a + " " + b + " " + c);
                }
            } else {        //b < c : c, b, a
                temp = a;
                a = c;
                b = b;
                c = temp;
                console.log(a, b, c);
                jsConsole.writeLine(a + " " + b + " " + c);
            }
        }
    } else {
        console.log("a, b or c is empty or not a number.");
        jsConsole.writeLine("a, b or c is empty or not a number.");
    }
}
//-------------------------------------Preview task 5---------------------------------------------
function digitName() {
    var digit = parseInt(document.getElementById("a5").value);

    switch (digit) {
        case 0: console.log("zero"); jsConsole.writeLine("zero"); break;
        case 1: console.log("one"); jsConsole.writeLine("one"); break;
        case 2: console.log("two"); jsConsole.writeLine("two"); break;
        case 3: console.log("three"); jsConsole.writeLine("three"); break;
        case 4: console.log("four"); jsConsole.writeLine("four"); break;
        case 5: console.log("five"); jsConsole.writeLine("five"); break;
        case 6: console.log("six"); jsConsole.writeLine("six"); break;
        case 7: console.log("seven"); jsConsole.writeLine("seven"); break;
        case 8: console.log("eight"); jsConsole.writeLine("eight"); break;
        case 9: console.log("nine"); jsConsole.writeLine("nine"); break;
        default: console.log("error"); jsConsole.writeLine("error"); break;
    }
}
//-------------------------------------Preview task 6---------------------------------------------
function findRealRoots() {
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
        jsConsole.writeLine("There are two real roots: " + x1 + " and " + x2);
    } else if (discriminant === 0) {
        console.log("There is one real root:", x0);
        jsConsole.writeLine("There are two real root: " + x0);
    } else {
        console.log("There are no real roots");
        jsConsole.writeLine("There are no real roots");
    }
}
//-------------------------------------Preview task 7---------------------------------------------
function greatestVar() {
    var a = document.getElementById("a7").value,
        b = document.getElementById("b7").value,
        c = document.getElementById("c7").value,
        d = document.getElementById("d7").value,
        e = document.getElementById("e7").value;

    var largest = Math.max(a, b, c, d, e);

    console.log(largest);
    jsConsole.writeLine(largest);
}

function clearConsole() {
    jsConsole.clear();
}