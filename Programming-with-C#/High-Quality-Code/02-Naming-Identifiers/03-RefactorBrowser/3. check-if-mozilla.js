function onBtnClick(event, arguments) {
    var browser = window.navigator.appCodeName;
    var isBrowserMozilla = (browser === "Mozilla");

    if (isBrowserMozilla) {
        alert("Yes");
    }
    else {
        alert("No");
    }
}
