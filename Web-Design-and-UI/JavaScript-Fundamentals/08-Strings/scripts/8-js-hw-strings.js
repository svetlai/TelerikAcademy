// 1. Write a JavaScript function reverses string and returns it. Example: "sample" > "elpmas".

function reverseString(str) {
    var reversed = str.split('').reverse().join('');

    return reversed;
}
//------------------------------------------------------------------------------------------------
/* 2. Write a JavaScript function to check if in a given expression the brackets are put correctly.
 Example of correct expression: ((a+b)/5-d).
 Example of incorrect expression: )(a+b)).*/
function checkBrackets(expression) {
    var counter = 0,
        opening = "(",
        closing = ")";

    for (var i in expression) {
        if (expression[i] === opening) {
            counter++;
        } else if (expression[i] === closing) {
            if (counter === 0) {	//if there's a closing bracket before an opening bracket;
                return "false";     //as string in order to display in jsConsole
            } else {
                counter--;
            }
        }
    }

    if (counter === 0) {
        return true;
    }

    return false;
}
//------------------------------------------------------------------------------------------------
// 3. Write a JavaScript function that finds how many times a substring is contained in a given text (perform case insensitive search).
function countSubStr(text, subStr) {
    if (subStr === "") {
        throw new Error('Substring cannot be empty.');
    }

    var subStr = subStr.toLowerCase(),
        text = text.toLowerCase(),
        subStrLen = subStr.length,
        counter = 0,
        subStrIndex,
        startIndex = 0;

    while ((subStrIndex = text.indexOf(subStr, startIndex)) > -1) {
        counter++;
        startIndex = subStrIndex + subStrLen;
    }

    if (counter === 0) {
        return "Not found.";
    }

    return counter;
}
//------------------------------------------------------------------------------------------------
// 4. You are given a text. Write a function that changes the text in all regions: 
// <upcase>text</upcase> to uppercase.
// <lowcase>text</lowcase> to lowercase
// <mixcase>text</mixcase> to mix casing(random)
function changeCase(text) {
    var currentSymbol,
        openTag = '<',
        closeTag = '>',
        isTag = false,
        currentTag = '',
        result = '',
        tags = [];

    for (var i = 0, l = text.length; i < l; i += 1) {
        currentSymbol = text[i];

        if (currentSymbol === openTag) {
            isTag = true;
            continue;
        }

        if (currentSymbol === closeTag) {
            isTag = false;
            continue;
        }

        if (isTag) {
            switch (currentSymbol) {
                case 'u':
                    currentTag = '<upcase>';
                    tags.push(currentTag);
                    i += currentTag.length - 2;
                    break;
                case 'm':
                    currentTag = '<mixcase>';
                    tags.push(currentTag);
                    i += currentTag.length - 2;
                    break;
                case 'l':
                    currentTag = '<lowcase>';
                    tags.push(currentTag);
                    i += currentTag.length - 2;
                    break;
                case '/':
                    tags.pop();
                    i += currentTag.length - 2;
                    if (tags.length > 0) {
                        currentTag = tags[tags.length - 1];
                    } else {
                        currentTag = '';
                    }
                    break;
            }

            isTag = false;
            continue;
        }

        switch (currentTag) {
            case '<upcase>':
                result += currentSymbol.toUpperCase();
                break;
            case '<mixcase>':
                result += Math.random() < 0.5 ? currentSymbol.toUpperCase() : currentSymbol.toLowerCase();
                break;
            case '<lowcase>':
                result += currentSymbol.toLowerCase();
                break;
            default:
                result += currentSymbol;
                break;
        }
    }

    return result;
}

// alternative, without nesting:
//function changeCase(str) {
//    var upper,
//        mix,
//        lower,
//        strUpStart,
//        strLowStart,
//        strMixStart,
//        startIndex = 0;
//
//    while ((strUpStart = str.indexOf('<upcase>', startIndex)) > -1) {
//        var strUpEnd = str.indexOf('</upcase>', startIndex),
//            strUp = str.substring((strUpStart + '</upcase>'.length), strUpEnd);
//        upper = strUp.toUpperCase();
//        str = str.replace(strUp, upper);
//        startIndex = strUpEnd + 1;
//    }
//
//    startIndex = 0;
//    while ((strMixStart = str.indexOf('<mixcase>', startIndex)) > -1) {
//        var strMixEnd = str.indexOf('</mixcase>', startIndex),
//            strMix = str.substring((strMixStart + '</mixcase>'.length), strMixEnd);
//        mix = strMix;
//        for (var i in mix) {
//            if (Math.random() < 0.5) {
//                mix = mix.replace(mix[i], mix[i].toUpperCase());
//            }
//        }
//
//        str = str.replace(strMix, mix);
//        startIndex = strMixEnd + 1;
//    }
//
//    startIndex = 0;
//    while ((strLowStart = str.indexOf('<lowcase>', startIndex)) > -1) {
//        var strLowEnd = str.indexOf('</lowcase>', startIndex),
//            strLow = str.substring((strLowStart + '</lowcase>'.length), strLowEnd);
//        lower = strLow.toLowerCase();
//        str = str.replace(strLow, lower);
//        startIndex = strLowEnd + 1;
//    }
//
//    return str;
//}

//------------------------------------------------------------------------------------------------
// 5. Write a function that replaces non breaking white-spaces in a text with &nbsp;
function escapeSpace(str) {
    var result = str.split(' ').join('&nbsp;');

    return result;
}
//------------------------------------------------------------------------------------------------
// 6. Write a function that extracts the content of a html page given as text. The function should return anything that is in a tag, without the tags.
function removeTags(str) {
    var currentSymbol,
        openTag = "<",
        closeTag = ">",
        inTag = false,
        result = '';

    for (var i in str) {
        currentSymbol = str[i];
        if (currentSymbol === openTag) {
            inTag = true;
            continue;
        }
        if (currentSymbol === closeTag) {
            inTag = false;
            continue;
        }

        if (!inTag) {
            result += currentSymbol;
        }
    }

    return result;
}
//-----------------------------------------------------------------------------------------------
// 7. Write a script that parses an URL address given in the format:
//[protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements. 
//Return the elements in a JSON object.
//For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
//{protocol: 'http', 
// server: 'www.devbg.org',
// resource: '/forum/index.php'}
function parseURL(url) {
    var protocolEndIndex = url.indexOf(":"),
        protocol = url.substring(0, protocolEndIndex),
        serverStartIndex = protocolEndIndex + 3,
        serverEndIndex = url.indexOf("/", serverStartIndex),
        server = url.substring(serverStartIndex, serverEndIndex),
        resourceStartIndex = url.indexOf("/", serverEndIndex),
        resource = url.substr(resourceStartIndex),

        output = {
            "protocol": protocol,
            "server": server,
            "resource": resource
        };

    return output;
}
//hack
//function parseUri(input) {
//    var uri = document.createElement('a');
//    uri.href = input;

//    return {
//        protocol: uri.protocol,
//        server: uri.hostname,
//        resource: uri.pathname,
//    };
//}
//-----------------------------------------------------------------------------------------------
//8. Write a JavaScript function that replaces in a HTML document given as string all the tags <a href="�">�</a> with corresponding tags [URL=�]�/URL]. 
function replaceAnchorTag(str) {
    var currentSymbol,
        inHref = false,
        isTag = false,
        startIndex = 0,
        hrefIndex,
        href,
        strToReplace,
        newURL = "";

    for (var i = 0, l = str.length; i < l; i++) {
        currentSymbol = str[i];

        if (currentSymbol === '<') {
            isTag = true;
        } else if (currentSymbol === '>') {
            isTag = false;
        }

        if (isTag && currentSymbol === "a") {
            inHref = true;
        }

        if (inHref) {
            str = str.replace("'", '"');                //makes sure the quotes are "
            hrefIndex = str.indexOf('<a href="', startIndex)

            if (hrefIndex > -1) {
                href = str.substring(hrefIndex + '<a href="'.length, str.indexOf('"', hrefIndex + '<a href="'.length));
                strToReplace = str.substring(str.indexOf("<", hrefIndex), str.indexOf(">", hrefIndex) + 1);  //including attributes
                newURL = "[URL=" + href + "]";
                str = str.replace(strToReplace, newURL);
                isTag = false;
                inHref = false;
                i += newURL.length - 2;             //skips the already replaced URL
            }
            startIndex = hrefIndex + href.length;
        }
        str = str.replace('</a>', '[/URL]');
    }

    return str;
}
//-----------------------------------------------------------------------------------------------
//9. Write a function for extracting all email addresses from given text. All substrings that match the format <identifier>@<host>�<domain> should be recognized as emails. Return the emails as array of strings.
function extractEmail(str) {
    var emailArr = [],
        atIndex = str.indexOf("@"),
        dotIndex,
        endIndex,
        replaced = str.replace(/[^\w\s@.]|_/g, ' ') + ' ', //removes punctuation except for @ and .
        identifier,
        host,
        domain,
        email;

    while (atIndex > -1) {
        if (atIndex === 0) {
            atIndex = replaced.indexOf("@", atIndex + 1);
            continue;
        }

        if (atIndex === replaced.length - 1) {
            break;
        }

        if (replaced[atIndex + 1] !== " " && replaced[atIndex - 1] !== " ") {
            dotIndex = replaced.indexOf(".", atIndex + 1);
            endIndex = replaced.indexOf(" ", dotIndex + 1) < replaced.indexOf(".", dotIndex + 1) ? replaced.indexOf(" ", dotIndex + 1) : replaced.indexOf(".", dotIndex + 1);

            identifier = replaced.substring(replaced.lastIndexOf(" ", atIndex - 1) + 1, atIndex);
            host = replaced.substring(atIndex + 1, dotIndex);
            domain = replaced.substring(dotIndex + 1, endIndex);

            email = identifier + "@" + host + "." + domain;
            emailArr.push(email);
        }

        atIndex = replaced.indexOf("@", atIndex + 1); // atIndex + + host.length + domain.length
    }

    return emailArr;
}

//function extractEmail(str) {
//    var emailArr = [];

//    function findEmail(str) {
//        var email = str.match(/([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9._-]+)/gi);
//        return email;
//    }

//    emailArr.push(findEmail(str));

//    return emailArr;
//}
//-----------------------------------------------------------------------------------------------
//10. Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".
function extractPalindromes(text) {
    var splitText = text.split(/\W+/g), ///[ ,.?]+/
        palindromesArr = [];

    for (var i = 0, l = splitText.length; i < l; i++) {
        var word = splitText[i];
        if (word === word.split('').reverse().join('') && word.length > 1) {
            palindromesArr.push(word);
        }
    }

    return palindromesArr;
}

////non regex alternative for splitting text into words:
//for (var i in str) {
//    if (str[i] === '.' || str[i] === ',' || str[i] === '?') { //etc.
//        str = str.replace(str[i], '');
//    }
//}
//
//var wordArr = str.split(' ');

//11. Write a function that formats a string using placeholders:
function stringFormat() {
    var str = arguments[0],
        placeholder;

    if (arguments.length > 1) {
        for (var i = 1; i < arguments.length && i <= 31; i += 1)  {
            placeholder = "{" + (i - 1) + "}";
            for (var j in str) {                        //if placeholder repeats
                str = str.replace(placeholder, arguments[i]);
            }
        }
    }

    return str;
}

//-----------------------------------------------------------------------------------------------
//12. Write a function that creates a HTML UL using a template for every HTML LI. The source of the list should an array of elements. Replace all placeholders marked with �{�}�   with the value of the corresponding property of the object.
function generateList(list, template) {
    var placeholder,
        listAsArray = ["<ul>"];

    for (var i in list) {
        listAsArray.push("<li>")

        var liContent = template;

        for (var prop in list[i]) {
            placeholder = "-{" + prop + "}-";

            for (var j in liContent) {
                liContent = liContent.replace(placeholder, list[i][prop]);
            }

        }

        listAsArray.push(liContent);
        listAsArray.push("</li>");
    }

    listAsArray.push("</ul>");

    return listAsArray.join('');;
}
//-----------------------------------------------------------------------------------------------