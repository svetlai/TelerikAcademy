(function () {
    'use strict';

    var browserName = navigator.appName,
        addScroll = false,
        positionX = 0,
        positionY = 0,
        theLayer;

    if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
        addScroll = true;
    }

    if (browserName === "Netscape") {
        document.captureEvents(Event.MOUSEMOVE);
    }

    document.onmousemove = mouseMove();

    function mouseMove(ev) {
        if (browserName === "Netscape") {
            positionX = ev.pageX - 5;
            positionY = ev.pageY;

            if (document.layers.ToolTip.visibility === 'show') {
                popTip();
            }
        } else {
            positionX = event.x - 5;
            positionY = event.y;

            if (document.all.ToolTip.style.visibility === 'visible') {
                popTip();
            }
        }
    }

    function popTip() {
        if (browserName === "Netscape") {
            theLayer = document.layers.ToolTip;

            if ((positionX + 120) > window.innerWidth) {
                positionX = window.innerWidth - 150;
            }

            theLayer.left = positionX + 10;
            theLayer.top = positionY + 15;
            theLayer.visibility = 'show';
        } else {
            theLayer = document.all.ToolTip;

            if (theLayer) {
                positionX = event.x - 5;
                positionY = event.y;

                if (addScroll) {
                    positionX = positionX + document.body.scrollLeft;
                    positionY = positionY + document.body.scrollTop;
                }

                if ((positionX + 120) > document.body.clientWidth) {
                    positionX = positionX - 150;
                }

                theLayer.style.pixelLeft = positionX + 10;
                theLayer.style.pixelTop = positionY + 15;
                theLayer.style.visibility = 'visible';
            }
        }
    }

    function hideTip() {
        if (browserName === "Netscape") {
            document.layers.ToolTip.visibility = 'hide';
        } else {
            document.all.ToolTip.style.visibility = 'hidden';
        }
    }

    function hideMenu1() {
        if (browserName === "Netscape") {
            document.layers.menu1.visibility = 'hide';
        } else {
            document.all.menu1.style.visibility = 'hidden';
        }
    }

    function showMenu1() {
        if (browserName === "Netscape") {
            theLayer = document.layers.menu1;
            theLayer.visibility = 'show';
        } else {
            theLayer = document.all.menu1;
            theLayer.style.visibility = 'visible';
        }
    }

    function hideMenu2() {
        if (browserName === "Netscape") {
            document.layers.menu2.visibility = 'hide';
        } else {
            document.all.menu2.style.visibility = 'hidden';
        }
    }

    function showMenu2() {
        if (browserName === "Netscape") {
            theLayer = document.layers.menu2;
            theLayer.visibility = 'show';
        } else {
            theLayer = document.all.menu2;
            theLayer.style.visibility = 'visible';
        }
    }
}());