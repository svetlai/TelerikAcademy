/* Task Description */
/* 
 Write a function that sums an array of numbers:
 numbers must be always of type Number
 returns `null` if the array is empty
 throws Error if the parameter is not passed (undefined)
 throws if any of the elements is not convertible to Number

 */

function sum(numbers) {
    var sum;

    if (numbers === undefined) {
        throw new Error('Missing parameter. You need to pass an array of numbers to call the function.');
    }

    if (numbers.length === 0) {
        return null;
    }

    if (numbers.some(function (input) {
            return isNaN(input);
        })) {
        throw new Error('All elements of the array should be numbers or convertible to Number.');
    }

    numbers = numbers.map(Number);

    sum = numbers.reduce(function (sum, number) {
        return sum + number;
    }, 0)

    return sum;
}

module.exports = sum;

// BGCoder.com solution:
// function solve() {
//     return '[your solution/object/function]';
// }