/* Task description */
/*
 Write a function that finds all the prime numbers in a range
 1) it should return the prime numbers in an array
 2) it must throw an Error if any on the range params is not convertible to `Number`
 3) it must throw an Error if any of the range params is missing
 */

function findPrimes(min, max) {
    if (min === undefined || max === undefined) {
        throw new Error('Missing parameter. You need to pass min and max values of the range to call the function.');
    }

    if (isNaN(min) || isNaN(max)) {
        throw new Error('Min and max values of the range should be numbers or convertible to Number.');
    }

    min = +min;
    max = +max;

    var primes = [];

    for (var i = min; i <= max ; i += 1) {
        if (isPrime(i)){
            primes.push(i);
        }
    }

    return primes;
}

function isPrime(number) {
    if (number <= 1){
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

module.exports = findPrimes;

// BGCoder.com solution:
// function solve() {
//     return '[your solution/object/function]';
// }