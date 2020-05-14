$(document).ready(function () {
    var prevScrollpos = window.pageYOffset;
    window.onscroll = function () {
        var currentScrollPos = window.pageYOffset;
        if (prevScrollpos > currentScrollPos)
        {
            $("#mynavbar").css({ top: '0px' });
        }
        else
        {
            $("#mynavbar").css({ top: '-100px' });
        }
        prevScrollpos = currentScrollPos;
    }
});
