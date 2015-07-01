/* Task Description */
/*
 Create a function constructor for Person. Each Person must have:
 *      properties `firstname`, `lastname` and `age`
 *      firstname and lastname must always be strings between 3 and 20 characters, containing only Latin letters
 *      age must always be a number in the range 0 150
 *      the setter of age can receive a convertible-to-number value
 *      if any of the above is not met, throw Error
 *      property `fullname`
 *      the getter returns a string in the format 'FIRST_NAME LAST_NAME'
 *      the setter receives a string is the format 'FIRST_NAME LAST_NAME'
 *      it must parse it and set `firstname` and `lastname`
 *      method `introduce()` that returns a string in the format 'Hello! My name is FULL_NAME and I am AGE-years-old'
 *      all methods and properties must be attached to the prototype of the Person
 *      all methods and property setters must return this, if they are not supposed to return other value
 *      enables method-chaining
 */
function solve() {
    var Person = (function () {
        function Person(firstname, lastname, age) {
            this.firstname = firstname;
            this.lastname = lastname;
            this.age = +age;
        }

        Person.prototype = {
            get firstname() {
                return this._firstname;
            },
            set firstname(value) {
                validateName(value);
                this._firstname = value;
            },
            get lastname() {
                return this._lastname;
            },
            set lastname(value) {
                validateName(value);
                this._lastname = value;
            },
            get fullname() {
                return this.firstname + ' ' + this.lastname;
            },
            set fullname(name) {
                var splitName = name.split(' ');
                this.firstname = splitName[0] || '';
                this.lastname = splitName[1] || '';
            },
            get age() {
                return this._age;
            },
            set age(value) {
                validateAge(value);
                this._age = value;
            },
            introduce: function () {
                return 'Hello! My name is ' + this.fullname + ' and I am ' + this.age + '-years-old'
            }
        }

        function hasOnlyLatinLetters(input) {
           return input.match(/^[a-zA-Z]*$/);
        }

        function isString(input){
            return typeof(input) === "string";
        }

        function isNumber(input){
            return !isNaN(input);
        }

        function isNameLengthValid(input){
            return input.length <= 20 && input.length >= 3;
        }

        function isAgeValid(age){
            return age <= 150 && age >= 0
        }

        function validateName(name){
            if (!isString(name)) {
                throw  new Error('Invalid argument. First and last names must be strings.');
            }

            if (!isNameLengthValid(name)) {
                throw new Error('Invalid argument. First and last names must be 3 and 20 characters.');
            }

            if (!hasOnlyLatinLetters(name)) {
                throw new Error('Invalid argument. First and last names must containing only Latin letters.');
            }
        }

        function validateAge(age){
            if (!isNumber(age)) {
                throw new Error('Invalid argument. Age must be a number.');
            }

            if (!isAgeValid(age)) {
                throw new Error('Inhuman age. A person cannot be younger than 0 or older than 150.');
            }
        }

        return Person;
    }());
    return Person;
}

module.exports = solve;