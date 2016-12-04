
/* 
Create a function that:
*   Takes an array of students
    *   Each student has a `firstName` and `lastName` properties
*   **Finds** all students whose `firstName` is before their `lastName` alphabetically
*   Then **sorts** them in descending order by fullname
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   Then **prints** them to the console
*   **Use underscore.js for all operations**
*/

function solve(){
  return function (students) {
    var filteredStudents = _.chain(students)
        .filter(function (student) {
          return student['firstName'].toLowerCase() < student['lastName'].toLowerCase();
        })
        .sortBy(function (student) {
          return student['firstName'] + ' ' + student['lastName'];
        })
        .value()
        .reverse();

        _.each(filteredStudents, function (student) {
          console.log(student['firstName'] + ' ' + student['lastName'])
        });
  };
}

module.exports = solve;