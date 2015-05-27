//1. Write an expression that checks if given integer is odd or even.
var x = 0;
var even = (x % 2 === 0);  //if there's no remainder when divided by two, then it's even

/*if (x % 2 === 0) {   //if there's no remainder when divided by 2, then it's even
 console.log("The number", number, "is even.")
 } else {
 console.log("The number", number, "is odd.")
 }*/
//--------------------------------------------------------------------------------------------------
//2. Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.

var noRemainder = (x % 7 === 0) && (x % 5 === 0); // && - if both are true

/*  if (noRemainder) {
 console.log("The number divides by 7 & 5 without a remainder.");
 } else {
 console.log("The number doesn't divide by 7 & 5 without a remainder.");
 }*/
//--------------------------------------------------------------------------------------------------
// 3. Write an expression that calculates rectangle’s area by given width and height.
var height = 0;
var width = 0;
var area = (height * width);
//console.log(area);
//--------------------------------------------------------------------------------------------------
//4. Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732 > true.
var digit = parseInt((x / 100) % 10) === 7;
/*if (digit) {
 console.log(x + " > true");
 } else {
 console.log(x + " > false");
 }*/
//--------------------------------------------------------------------------------------------------
//5. Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.
var givenNumber = givenNumber >> 3;
var result = givenNumber / 1 === 0; //gives 0

/*if (result) {
 console.log("The third bit of " + givenNumber + " is 0.");
 }
 else {
 console.log("The third bit of " + givenNumber + " is 1.");
 }*/
//--------------------------------------------------------------------------------------------------
//6. Write an expression that checks if given print (x,  y) is within a circle K(O, 5).
var x = 0;
var y = 0;
var radius = 5;
var randomPoint = (x * x) + (y * y) <= (radius * radius); //Point P(x, y) is inside a circle if х^2+у^2<R^2, where R is the radius; if х^2+у^2=R^2, the point lies on the circle;
//--------------------------------------------------------------------------------------------------
//7. Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.
function isPrime(number) {
    if (number === 1){
        return false;
    }

    if (number === 2) {
        return true;
    }

    for (var i = 2; i <= Math.sqrt(number); i++) { //it's enought to check for every i until the square root of n; after that up until n the combinations of multiplying numbers is the same, only reversed.
        if (number % i === 0) {        //n is prime if it can be divided without a reminder only by one and itself;
            return false;
        }
    }

    return true;
}
//--------------------------------------------------------------------------------------------------
// 8. Write an expression that calculates trapezoid's area by given sides a and b and height h.
var a = 0;
var b = 0;
var h = 0;
var tArea = ((a + b) / 2) * h;

//console.log(tArea);
//--------------------------------------------------------------------------------------------------
// 9. Write an expression that checks for given point (x, y) if it is within the circle K((1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).
var x = 0;
var y = 0;

// circle K( (1,1), 3)
var radius = 3;
var pInK = ((x - 1) * (x - 1)) + ((y - 1) * (y - 1)) <= radius * radius; // the point is inside the circle; - 1 to push the center to 0,0

// rectangle R(top=1, left=-1, width=6, height=2)
var ax = -1;
var by = 1;
var cx = ax + 6;
var dy = by - 2;
var pNotInR = (x < ax) || (x > cx) || (y > by) || (y < dy); //the point is outside the rectangle

var truePoint = pInK && pNotInR; //the point is inside the circle and outside the rectangle

/*  if (truePoint) {
 console.log("The point is within circle K((1,1), 3) and out of rectangle R(top=1, left=-1, width=6, height=2)");
 } else {
 console.log("false");
 }
 */
//--------------------------------------------------------------------------------------------------