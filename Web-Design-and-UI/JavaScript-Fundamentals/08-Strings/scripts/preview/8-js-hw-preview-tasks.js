//-------------------------------------Preview task 1----------------------------------------------
function testReverseString() {
    var str = document.getElementById("a1").value;

    console.log(reverseString(str));
    jsConsole.writeLine(reverseString(str));
}
//-------------------------------------Preview task 2----------------------------------------------
function testCheckBrackets() {
    var expression = document.getElementById("a2").value;

    console.log(checkBrackets(expression));
    jsConsole.writeLine(checkBrackets(expression).toString());
}
//-------------------------------------Preview task 3----------------------------------------------
function testCountSubStr() {
    var subStr = document.getElementById("a3").value,
        text = document.getElementById('sometext').innerText;

    try {
        var count = countSubStr(text, subStr);
        console.log(count);
        jsConsole.writeLine(count);
    } catch (exception) {
        console.log(exception.message);
        jsConsole.writeLine(exception.message);
    }
}
//-------------------------------------Preview task 4----------------------------------------------
function testChangeCase() {
   var text = document.getElementById("changecasetext").innerText;
    //var text = 'We are <upcase><mixcase><lowcase></lowcase>living</mixcase> in </upcase>a <upcase>yellow submarine</upcase>. We <mixcase>don\'t</mixcase> have <lowcase>anything</lowcase> else.';

    console.log(changeCase(text));
    jsConsole.writeLine(changeCase(text));
}
//-------------------------------------Preview task 5----------------------------------------------
function testEscapeSpace() {
    var str = document.getElementById("escapespacetext").innerText;

    console.log(escapeSpace(str));
    jsConsole.writeLine('Take a look in the browser\'s console');
}
//-------------------------------------Preview task 6----------------------------------------------
function testRemoveTags() {
    var str = "<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>"

    console.log(removeTags(str));
    jsConsole.writeLine(removeTags(str));
}
//-------------------------------------Preview task 7----------------------------------------------
function testParseURL() {
    var url = document.getElementById("a6").value || "http://www.devbg.org/forum/index.php";

    console.log(parseURL(url));
    jsConsole.writeLine(JSON.stringify(parseURL(url)));
}
//-------------------------------------Preview task 8----------------------------------------------
function testReplaceAhref() {
    var str = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>';

    console.log(replaceAnchorTag(str));
    jsConsole.writeLine(replaceAnchorTag(str));
}
//-------------------------------------Preview task 9----------------------------------------------
function testExtractEmail(str) {
    var str = document.getElementById("extractemailtext").innerText;

    console.log(extractEmail(str));
    jsConsole.writeLine(extractEmail(str));
}
//-------------------------------------Preview task 10----------------------------------------------
function testExtractPalindromes(text) {
    var text = document.getElementById("extraxtpalindromestext").innerText;

    console.log(extractPalindromes(text));
    jsConsole.writeLine(extractPalindromes(text));
}
//-------------------------------------Preview task 11----------------------------------------------
function testStringFormat(str) {
    var str = stringFormat('Hello, {1} {0}! {2} {3} of you to {5} {4}, {0}!', 'Peter', 'dear', 'How', 'nice', 'us', 'join');

    console.log(str);
    jsConsole.writeLine(str);
}
//-------------------------------------Preview task 12----------------------------------------------
function testGenerateList() {
    var people = [{name: 'Peter', age: 14},
            {name: 'George', age: 18}],
        template = document.getElementById("list-item").innerHTML,
        peopleList = generateList(people, template);

    console.log(peopleList);
    jsConsole.writeLine(peopleList);
}