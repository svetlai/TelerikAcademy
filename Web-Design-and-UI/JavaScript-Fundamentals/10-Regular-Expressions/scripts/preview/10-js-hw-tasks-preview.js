//-------------------------------------Preview task 1----------------------------------------------
function testStringFormat() {

    var options = {name: 'John', age: 13};
    console.log('My name is #{name} and I am #{age}-years-old'.format(options));
    jsConsole.writeLine('My name is #{name} and I am #{age}-years-old'.format(options));
}
//-------------------------------------Preview task 2----------------------------------------------
function testHtmlBinding() {
    jsConsole.writeLine('Open the browser\'s console to view the result with tags: ')
    var str = '<div data-bind-content="name"></div>';
    console.log(str.bind(str, {name: 'Steven'}));
    jsConsole.write(str.bind(str, {name: 'Steven'}));

// <div data-bind-content="name">Steven</div>

    var bindingString = '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></a>'
    console.log(str.bind(bindingString, {name: 'Elena', link: 'http://telerikacademy.com'}));
    jsConsole.writeLine(str.bind(bindingString, {name: 'Elena', link: 'http://telerikacademy.com'}))

// <a data-bind-content="name" data-bind-href="link" data-bind-class="name" href="http://telerikacademy.com" class="Elena">Elena</à>
}