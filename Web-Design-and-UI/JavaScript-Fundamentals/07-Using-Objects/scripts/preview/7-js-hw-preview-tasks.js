//-------------------------------------Preview task 1----------------------------------------------
function printPlanarCoordinates() {
    var pointAArr = document.getElementById("a1").value.split(",").map(Number),  //converts array string elements into numbers
        pointBArr = document.getElementById("b1").value.split(",").map(Number),  //converts array string elements into numbers
        pointCArr = document.getElementById("c1").value.split(",").map(Number),  //converts array string elements into numbers
        pointA = getPoint(pointAArr[0], pointAArr[1]),
        pointB = getPoint(pointBArr[0], pointBArr[1]),
        pointC = getPoint(pointCArr[0], pointCArr[1]),
        firstLine = getLine(pointA, pointB),
        secondLine = getLine(pointB, pointC),
        thirdLine = getLine(pointC, pointA);

    console.log('Can form triangle? ' + canFormTriangle(firstLine, secondLine, thirdLine));
    jsConsole.writeLine('Can form triangle? ' + canFormTriangle(firstLine, secondLine, thirdLine).toString());
}
//-------------------------------------Preview task 2----------------------------------------------
function removeElementFromArray() {
    var arr = document.getElementById("a2").value.split(",").map(Number),
        value = document.getElementById("b2").value * 1;

    console.log(arr.remove(value));
    jsConsole.writeLine(arr.remove(value));
}
//-------------------------------------Preview task 3----------------------------------------------
/*var num = 1,
 str = "random string",
 bool = true,
 arr = [1,2,3],
 object = { a: 1, b: 2};*/

function printDeepCopy(obj) {
    var copy = deepCopy(obj);

    console.log("Type of var obj: " + typeof(obj) + "\nBefore change: \nobj = " + JSON.stringify(obj) + "\ncopy = " + JSON.stringify(copy));
    jsConsole.writeLine("Type of var obj: " + typeof(obj) + "<p>Before change: </p><p>obj = " + JSON.stringify(obj) + "</p>copy = " + JSON.stringify(copy));
    obj = 'new value';
    console.log("After assigning a new value to obj: \nobj = " + JSON.stringify(obj) + "\ncopy = " + JSON.stringify(copy));
    jsConsole.writeLine("After assigning a new value to obj: <p>obj = " + JSON.stringify(obj) + "</p>copy = " + JSON.stringify(copy));
}
//-------------------------------------Preview task 4----------------------------------------------
var obj = {fname: "brad", lname: "kolev", age: 21, eyecolor: "blue", height: 180, weight: 75},
    arr = [1, 2, 3];

function objHasPropBtn(obj) {
    var prop = document.getElementById("a4").value,
        hasProp = hasProperty(obj, prop);

    console.log('Has property? ' + hasProp);
    jsConsole.writeLine('Has property? ' + hasProp.toString());
}
//-------------------------------------Preview task 5----------------------------------------------
function youngestPersonBtn() {
    var persons = [
            {firstname: 'Gosho', lastname: 'Petrov', age: 32},
            {firstname: 'Bay', lastname: 'Ivan', age: 81},
            {firstname: 'Holly', lastname: 'Berry', age: 21}];

    console.log(findYoungestPerson(persons));
    jsConsole.writeLine(findYoungestPerson(persons));
}
//-------------------------------------Preview task 6----------------------------------------------
function groupPeople(criterion) {
    var people = [
        {firstname: "Gosho", lastname: "Petrov", age: 32},
        {firstname: "Bay", lastname: "Ivan", age: 81},
        {firstname: "Gosho", lastname: "Berry", age: 18},
        {firstname: "Holly", lastname: "Berry", age: 21},
        {firstname: "Nikki", lastname: "Watson", age: 32}];

    //var groupByFname = group(persons, "Gosho");
    //var groupByLname = group(persons, "Berry");
    //var groupByAge = group(persons, '32');

    console.log(JSON.stringify(group(people, criterion)));
    jsConsole.writeLine(JSON.stringify(group(people, criterion)));
}

function clearConsole() {
    jsConsole.clear();
}