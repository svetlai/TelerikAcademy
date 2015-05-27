//1. Write a script that allocates array of 20 integers and initializes each element by its index multiplied by 5. Print the obtained array on the console.
function increaseArrayNumbers(){
    var arr = new Array(20);

    for (var i = 0, l = arr.length; i < l; i++) {
        arr[i] = i * 5;
    }
    /* alternative:
    var arr = [];

    for (var i = 0; i < 20; i++) {
        arr.push(i * 5);
    }
    */
	return arr;
}
//------------------------------------------------------------------------------------------------
//2. Write a script that compares two char arrays lexicographically (letter by letter).
function compareCharArrays(first, second) {
    if (first.length !== second.length){
        return false;
    }

    for (var i = 0; i < first.length; i+=1) {
        if (first[i] !== second[i]){
            return false;
        }
    }

    return true;
}
//------------------------------------------------------------------------------------------------
//3. Write a script that finds the maximal sequence of equal elements in an array.
    //Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} > {2, 2, 2}.
function findMaxEqualSequence(arr) {
    var seqStart,
        seqLength = 1,
        max = seqLength,
        maxSequence = [];

    for (var i = 0, l = arr.length; i < l - 1; i+=1) {
        if (arr[i] === arr[i + 1]) {
            seqLength++;
            if (seqLength > max) {
                max = seqLength;
                seqStart = arr[i];
            } 
        } else {
            seqLength = 1;  // reset
        }
    }

    for (var j = 0; j < max; j+=1) {
        maxSequence.push(seqStart);
    }

    return {
        max: max,
        maxSequence: maxSequence
    }
}
//-----------------------------------------------------------------------------------------------
//4. Write a script that finds the maximal increasing sequence in an array. 
    //Example: {3, 2, 3, 4, 2, 2, 4} > {2, 3, 4}.
function findMaxIncreasingSequence(arr) {
    var seqEnd,
        seqLength = 1,
        max = seqLength,
        maxSequence = [];

    for (var i = 1, l = arr.length; i < l; i++) {
        if (arr[i] === arr[i - 1] + 1) {
            seqLength++;
            if (seqLength >= max) {
                max = seqLength;
                seqEnd = arr[i];
            }
        } else {
            seqLength = 1;  //reset
        }
    }

    for (var j = 0; j < max; j++) {
        maxSequence.push(seqEnd);
        seqEnd--;
    }

    maxSequence.reverse();

    return {
        max: max,
        maxSequence: maxSequence
    }
}
//-----------------------------------------------------------------------------------------------
//5. Sorting an array means to arrange its elements in increasing order. Write a script to sort an array. Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc. Hint: Use a second array.
function selectionSort(arr) {
    var min,
        sorted = [];

    while(arr.length) {
        min = 0;
        for (var i = 0, l = arr.length; i < l; i+=1) {
            if (arr[i] < arr[min]){
                min = i;
            }
        }

        sorted.push(arr[min]);
        arr.splice(min, 1);
    }

    return sorted;
}
//-----------------------------------------------------------------------------------------------
//6. Write a program that finds the most frequent number in an array. 
//Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} > 4 (5 times)
function findMostFrequent(arr) {
    var start = arr[0],
        count = 1,
        mostFrequent = count;

    arr.sort(function (a, b) {
            return a - b;       //ascending
        });

    for (var i = 0, l = arr.length; i < l - 1; i++) {
        if (arr[i] === arr[i + 1]) {
            count++;
            if (count > mostFrequent) {
                mostFrequent = count;
                start = arr[i];
            }
        } else {
            count = 1;  //reset
        }
    }

    return {
        count: mostFrequent,
        start: start
    };
}
//-----------------------------------------------------------------------------------------------
//7. Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm (find it in Wikipedia).
//Example: {1, 2, 3, 4, 5, 12} > 3 > (index: 2)
function binarySearch(arr, x) {

    arr.sort(function (a, b) {
            return a - b;       //ascending
        });

    var indexX,
        l = arr.length,
        middleIndex = Math.floor(l / 2),
        middle = arr[middleIndex];

    if (x === middle) {
        indexX = middleIndex;
    } else if (x < middle) {
        for (var i = 0; i < middleIndex; i++) {
            if (x === arr[i]) {
                indexX = i;
                break;
            }
        }
    } else {
        for (var j = 0; j > middleIndex, j < l; j++) {
            if (x === arr[j]) {
                indexX = j;
                break;
            }
        }
    }

    return indexX;
}
//-----------------------------------------------------------------------------------------------

