// 1. Write a function for creating persons. Each person must have firstname, lastname, age and gender (true is female, false is male) Generate an array with ten person with different names, ages and genders
function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min) + min);
}

function getRandomString(length) {
    var alphabet = 'abcdefghijklmnopqrstuvwxyz',
        result = '';

    for (var i = 0; i < length; i += 1) {
        result += i === 0 ? alphabet[getRandomInt(0, alphabet.length - 1)].toUpperCase() : alphabet[getRandomInt(0, alphabet.length - 1)];
    }

    return result;
}

function createPerson(firstName, lastName, age, gender) {
    return {
        firstName: firstName,
        lastName: lastName,
        age: age,
        gender: gender
    }
}

function getArrayWithRandomPeople(count) {
    var people = [];
    for (var i = 0; i < count; i += 1) {
        var gender = Math.random() < 0.5 ? true : false,
            person = createPerson(getRandomString(5), getRandomString(5), getRandomInt(10, 80), gender);

        people.push(person);
    }

    return people;
}

var people = getArrayWithRandomPeople(9);
people[9] = createPerson('Pesho', 'Peshov', 16, true);

//console.log(people);

//if (!Array.prototype.fill) {
//    Array.prototype.fill = function (callback) {
//        var i, len = this.length;
//        for (i = 0; i < len; i += 1) {
//            this[i] = arguments[0];
//        }
//
//        return this;
//    }
//}
//function getRandomPerson() {
//    var gender = Math.random() < 0.5 ? true : false,
//        person = createPerson(getRandomString(5), getRandomString(5), getRandomInt(10, 80), gender);
//
//    return person;
//}
//
//var arr = [],
//    count = 10;
//arr[count - 1] = undefined;
//
//arr.fill(getRandomPerson());
//console.log(arr);
//-----------------------------------------------------------------------------------------------
// 2. Write a function that checks if an array of person contains only people of age (with age 18 or greater). Use only array methods and no regular loops (for, while)
function isOfAge(person){
    return person.age >= 18;
}

var ofAge = people.every(isOfAge);
//console.log(ofAge)
//-----------------------------------------------------------------------------------------------
// 3. Write a function that prints all underaged persons of an array of person. Use Array#filter and Array#forEach. Use only array methods and no regular loops (for, while)
function isUnderage(person){
    return person.age < 18;
}

var underage = people.filter(isUnderage);

function printUnderage(underage){
    underage.forEach(function(person){
        var gender = person.gender ? 'male' : 'female';
        console.log(person.firstName + ' ' + person.lastName + ', Age: ' + person.age + ', Gender: ' + gender);
    });
}
//-----------------------------------------------------------------------------------------------
// 4. Write a function that calculates the average age of all females, extracted from an array of persons. Use Array#filter. Use only array methods and no regular loops (for, while)
function isFemale(person){
    return !person.gender;
}

var females = people.filter(isFemale);
//console.log(females);

var agesSum = females.reduce(function(sum, person){
    return sum + person.age;
}, 0);

var averageAge = Math.round(agesSum / females.length);
//-----------------------------------------------------------------------------------------------
// 5. Write a function that finds the youngest male person in a given array of people and prints his full name. Use only array methods and no regular loops (for, while). Use Array#find
if (!Array.prototype.find) {
    Array.prototype.find = function (callback) {
        var i, len = this.length;
        for (i = 0; i < len; i += 1) {
            if (callback(this[i], i, this)){
                return this[i];
            }
        }
    }
}

function isMale(person){
    return person.gender;
}

var youngest = people.sort(function(firstPerson, secondPerson){
    return firstPerson.age > secondPerson.age;
}).find(isMale);

//console.log(youngest);
//-----------------------------------------------------------------------------------------------
// 6. Write a function that groups an array of persons by first letter of first name and returns the groups as a JavaScript Object. Use Array#reduce. Use only array methods and no regular loops (for, while)
var result = people.reduce(function(groups, person){
   if (groups[person.firstName[0]]){
       groups[person.firstName[0]].push(person);
   }else {
       groups[person.firstName[0]] = [person]
   }

   return groups;
}, {})

// console.log(result);
