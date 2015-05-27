/*1. Write functions for working with shapes in standard Planar coordinate system
 > Points are represented by coordinates P(X, Y)
 > Lines are represented by two points, marking their beginning and ending L(P1(X1,Y1), P2(X2,Y2))
 > Calculate the distance between two points
 > Check if three segment lines can form a triangle*/
function getPoint(x, y) {
    var point = {
        x: x,
        y: y
    };

    return point;
}

function getLine(startPoint, endPoint) {
    var line = {
        start: startPoint,
        end: endPoint
    };

    return line;
}

function calculateDistance(line) {
    var dx = Math.pow((line.start.x - line.end.x), 2),
        dy = Math.pow((line.start.y - line.end.y), 2),
        distance = Math.sqrt(dx + dy);

    return distance;
}

function canFormTriangle(firstLine, secondLine, thirdLine) {
    var firstLength = calculateDistance(firstLine),
        secondLength = calculateDistance(secondLine),
        thirdLength = calculateDistance(thirdLine);

    if (firstLength + secondLength > thirdLength && firstLength + thirdLength > secondLength && secondLength + thirdLength > firstLength) {
        return true;
    }

    return false;
}
//------------------------------------------------------------------------------------------------
/*2. Write a function that removes all elements with a given value
 > Attach it to the array type.
 > Read about prototype and how to attach methods.*/
Array.prototype.remove = function (value) {
    for (var i in this) {
        if (this[i] === value) {
            this.splice(i, 1);
        }
    }

    return this;
}
//------------------------------------------------------------------------------------------------
//3. Write a function that makes a deep copy of an object. The function should work for both primitive and reference types.
function deepCopy(obj) {
    var copy = obj instanceof Array ? [] : {};

    if (obj === null || typeof(obj) !== 'object') {
        return obj;
    }

    for (var i in obj) {
        if (typeof(obj[i]) === 'object') {
            copy[i] = deepCopy(obj[i])
        } else {
            copy[i] = obj[i];
        }
    }

    return copy;
}
//------------------------------------------------------------------------------------------------
//4. Write a function that checks if a given object contains a given property.
function hasProperty(obj, prop) {
    if (prop in obj) {
        return true;
    }

    return false;
}
//------------------------------------------------------------------------------------------------
//5. Write a function that finds the youngest person in a given array of persons and prints his/hers full name. 
//Each person have properties firstname, lastname and age
function findYoungestPerson(persons) {
    var youngest = {},
        min = 200;

    for (var i = 0; i < persons.length; i += 1) {
        if (persons[i].age < min) {
            min = persons[i].age;
            youngest = persons[i];
        }
    }

    return youngest.firstname + " " + youngest.lastname;
}

// alternative:
//function findYoungestPerson(persons){
//    var arr = [];
//
//    for (var i in persons) {
//        arr.push([persons[i].firstname, persons[i].lastname, persons[i].age]);	//make each element (person) an array instead of object so it can be sorted
//    }
//
//    arr.sort(function (a, b) {
//        return a[2] - b[2];       //sort ascending by index 2 in array (age)
//    });
//
//    var fullName = arr[0][0] + " " + arr[0][1];
//
//    return fullName;
//}

//------------------------------------------------------------------------------------------------
/*6. Write a function that groups an array of persons by age, first or last name. 
 The function must return an associative array, with keys - the groups, and values -
 arrays with persons in this groups.
 Use function overloading (i.e. just one function).*/
function group(people, criterion) {
    var arr = [];

    for (var i in people) {
        for (var prop in people[i]) {
            if (people[i][prop] === criterion) {
                arr.push(people[i]);
            }
        }
    }

    if (arr.length > 0) {
        return {key: criterion, value: arr};
    } else {
        return "There's no person with such data.";
    }
}
//------------------------------------------------------------------------------------------------