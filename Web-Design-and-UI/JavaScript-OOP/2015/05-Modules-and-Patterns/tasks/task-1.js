/* Task Description */
/* 
 * Create a module for a Telerik Academy course
 * The course has a title and presentations
 * Each presentation also has a title
 * There is a homework for each presentation
 * There is a set of students listed for the course
 * Each student has firstname, lastname and an ID
 * IDs must be unique integer numbers which are at least 1
 * Each student can submit a homework for each presentation in the course
 * Create method init
 * Accepts a string - course title
 * Accepts an array of strings - presentation titles
 * Throws if there is an invalid title
 * Titles do not start or end with spaces
 * Titles do not have consecutive spaces
 * Titles have at least one character
 * Throws if there are no presentations
 * Create method addStudent which lists a student for the course
 * Accepts a string in the format 'Firstname Lastname'
 * Throws if any of the names are not valid
 * Names start with an upper case letter
 * All other symbols in the name (if any) are lowercase letters
 * Generates a unique student ID and returns it
 * Create method getAllStudents that returns an array of students in the format:
 * {firstname: 'string', lastname: 'string', id: StudentID}
 * Create method submitHomework
 * Accepts studentID and homeworkID
 * homeworkID 1 is for the first presentation
 * homeworkID 2 is for the second one
 * ...
 * Throws if any of the IDs are invalid
 * Create method pushExamResults
 * Accepts an array of items in the format {StudentID: ..., Score: ...}
 * StudentIDs which are not listed get 0 points
 * Throw if there is an invalid StudentID
 * Throw if same StudentID is given more than once ( he tried to cheat (: )
 * Throw if Score is not a number
 * Create method getTopStudents which returns an array of the top 10 performing students
 * Array must be sorted from best to worst
 * If there are less than 10, return them all
 * The final score that is used to calculate the top performing students is done as follows:
 * 75% of the exam result
 * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
 */

function solve() {
    var Course = {
        init: function (title, presentations) {
            this.title = title;
            this.presentations = presentations;
            this._students = [];
            this._studentData = {};
            this._topStudents = [];
            return this;
        }
        ,
        addStudent: function (name) {
            validateName(name);
            var splitName = name.split(' '),
                student = {
                    firstname: splitName[0],
                    lastname: splitName[1],
                    id: this.students.length + 1
                };

            if (!this._studentData[student.id]) {
                this._studentData[student.id] = {
                    'homework': []
                }
            }

            this.students.push(student);
            return student.id;
        }
        ,
        getAllStudents: function () {
            return this.students;
        }
        ,
        submitHomework: function (studentID, homeworkID) {
            validateStudentID(studentID, this.students);
            validateHomeworkId(homeworkID, this.presentations);

            this._studentData[studentID]['homework'].push(homeworkID);
            return this;
        }
        ,
        pushExamResults: function (results) {
            validateResults(results, this.students);
            for (var i = 0, len = results.length; i < len; i += 1) {
                this._studentData[results[i].StudentID]['examResults'] = results[i].score;
            }

            return this;
        }
        ,
        getTopStudents: function () {
            var finalScores = [];
            for (var i = 0, len = this.students.length; i < len; i += 1) {
                var finalExamScore = this._studentData[this.students[i].id]['examResults'],
                    finalHomeworkScore = this._studentData[this.students[i].id]['homework'].length / this.presentations.length,
                    finalScore = finalExamScore / 100 * 75 + finalHomeworkScore / 100 * 25;

                finalScores.push([this.students[i].id, finalScore]);
            }

            var topScores = sortScore(finalScores)
                .reverse()
                .slice(0, 10);

            for (var i = 0, len = topScores.length; i < len; i += 1) {
                for (var j = 0; j < this.students.length; j += 1) {
                    if (topScores[i][0] === this.students[j].id) {
                        this._topStudents.push(this.students[j]);
                    }
                }
            }

            return this._topStudents;
        },
        get title() {
            return this._title;
        },
        set title(value) {
            validateTitle(value);
            this._title = value;
        },
        get presentations() {
            return this._presentations;
        },
        set presentations(value) {
            validatePresentations(value);
            this._presentations = value;
        },
        get students() {
            return this._students;
        }
    };

    function validateTitle(title) {
        if ((typeof(title) !== 'string' || title === '' || title !== title.trim() || title.match(/\s\s+/))) {
            throw new Error('Title must be a non-empty string without invalid white spaced.');
        }
    }

    function validatePresentations(presentations) {
        if (!presentations || !Array.isArray(presentations) || presentations.length === 0) {
            throw new Error('Missing argument. You must include presentations.')
        }

        for (var i = 0, len = presentations.length; i < len; i += 1) {
            validateTitle(presentations[i]);
        }
    }

    function validateName(name) {
        var splitName = name.split(' ');
        if (splitName.length !== 2) {
            throw new Error('Student must be provided with 2 names only.')
        }

        for (var i = 0, len = splitName.length; i < len; i += 1) {
            if (splitName[i][0] !== splitName[i][0].toUpperCase()) {
                throw new Error('Name must start with an uppercase letter.');
            }

            if (splitName[i].length > 1){
                for (var j = 1, len = splitName.length; j < len; j += 1) {
                    if (splitName[i][j] !== splitName[i][j].toLowerCase()) {
                        throw new Error('All letters of the name besides the first one must be lowercase.');
                    }
                }
            }
        }
    }

    function validateHomeworkId(id, presentations) {
        if (id < 1 || id > presentations.length) {
            throw new Error('Invalid id. There\'s no presentation with that id.');
        }
    }

    function validateStudentID(id, students) {
        var idExists = students.some(function (student) {
            return student.id === id
        });

        if (!idExists) {
            throw new Error('Invalid id. There is no student with that id.');
        }
    }

    function validateScore(score) {
        if (isNaN(score)) {
            console.log(score);
            throw new Error('Score must be a number');
        }
    }

    function sortResults(results) {
        return results.sort(function (firstResult, secondResult) {
            if (firstResult.StudentID < secondResult.StudentID) {
                return -1;
            }
            if (firstResult.StudentID > secondResult.StudentID) {
                return 1;
            }
            return 0;
        });
    }

    function validateResults(results, students) {
        sortResults(results);
        for (var i = 0, len = results.length; i < len; i += 1) {
            if (i < results.length - 1 && results[i].StudentID === results[i + 1].StudentID) {
                throw new Error('Duplicate ids.');
            }

            validateStudentID(results[i].StudentID, students);
            validateScore(results[i].score);
        }
    }

    function sortScore(arr) {
        return arr.sort(function (first, second) {
            if (first[1] < second[1]) {
                return -1;
            }
            if (first[1] > second[1]) {
                return 1;
            }
            return 0;
        });
    }

    return Course;
}


module.exports = solve;

//var course = solve().init('ssfsf', ['ljlk', 'kjhkh', 'khk']);
//
//var results = [{
//    StudentID: 1,
//    Score: 20
//},
//    {
//        StudentID: 3,
//        Score: 20
//    },
//    {
//        StudentID: 2,
//        Score: 20
//    }];
//
//course.addStudent('Pesho Ivanov')
//course.addStudent('Gosho Ivanov')
//course.addStudent('Maria Petrova')
//course.pushExamResults(results);
//
//course.submitHomework(1, 1)
//    .submitHomework(1, 2)
//    .submitHomework(1, 3)
//    .submitHomework(2, 1)
//    .submitHomework(3, 1);
//
//console.log(course.getTopStudents());
