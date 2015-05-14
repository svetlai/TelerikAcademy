//1. Assign all the possible JavaScript literals to different variables.
var intLit = 1,									//Integer
    floatLit = 1.5,								//Floating-point
    boolLit = true,								//Boolean
    stringLit = "This is a string literal.",	//String
    objectLit = { name: "John", age: 26 },		//Object
    arrayLit = ["red", "blue", "green"];		//Array
    functionLit = function functionName(a, b) {
        return (a + b);
    };							                //Function
//--------------------------------------------------------------------------------------------------

//2. Create a string variable with quoted text in it. For example: 'How you doin'?', Joey said.
var quotedString = "'How you doin'?', Joey said.";
var quotedString2 = "\"How you doin'?\", Joey said.";
//--------------------------------------------------------------------------------------------------

//3. Try typeof on all variables you created.
console.log(typeof (intLit));
console.log(typeof (floatLit));
console.log(typeof (boolLit));
console.log(typeof (stringLit));
console.log(typeof (objectLit));
console.log(typeof (arrayLit));
console.log(typeof (functionLit));
//--------------------------------------------------------------------------------------------------

//4. Create null, undefined variables and try typeof on them.
var nullVar = null,
    undefinedVar = undefined;

console.log(typeof (nullVar));
console.log(typeof (undefinedVar));
//--------------------------------------------------------------------------------------------------
