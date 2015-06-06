//-------------------------------------Preview task 1----------------------------------------------
function printPeople(people){
   people.forEach(function(person){
       console.log(JSON.stringify(person));
       jsConsole.writeLine(JSON.stringify(person));
    });
}
//-------------------------------------Preview task 2----------------------------------------------
function printIsOfAge(ofAge){
    console.log('Are all people of age? ' + ofAge);
    jsConsole.writeLine('Are all people of age? ' + ofAge);
}
//-------------------------------------Preview task 3----------------------------------------------
function printUnderage(underage){
    underage.forEach(function(person){
        var gender = person.gender ? 'male' : 'female';
        console.log(person.firstName + ' ' + person.lastName + ', Age: ' + person.age + ', Gender: ' + gender);
        jsConsole.writeLine(person.firstName + ' ' + person.lastName + ', Age: ' + person.age + ', Gender: ' + gender);
    });
}
//-------------------------------------Preview task 4----------------------------------------------

function printAverageAge(averageAge){
    console.log('The average age of all females is: ' + averageAge);
    jsConsole.writeLine('The average age of all females is: ' + averageAge);
}

//-------------------------------------Preview task 5----------------------------------------------
function printYoungest(youngest){
    console.log('The youngest person is: ' + JSON.stringify(youngest));
    jsConsole.writeLine('The youngest person is: ' + JSON.stringify(youngest));
}

//-------------------------------------Preview task 6----------------------------------------------
function printGroups(groups){
    console.log(JSON.stringify(groups));
    jsConsole.writeLine(JSON.stringify(groups));
}