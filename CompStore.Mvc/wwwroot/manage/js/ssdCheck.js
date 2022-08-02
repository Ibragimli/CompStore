var isSSD = document.querySelector('.isSSDCheckInput');
var ssdType = document.getElementById('ssdType');
var ssdHecm = document.getElementById('ssdHecm');
isSSD.addEventListener('change', function () {
    if (isSSD.checked == true) {
        ssdType.style.display = "block"
        ssdHecm.style.display = "block"
    }
    else {
        ssdType.style.display = "none";
        ssdHecm.style.display = "none";
    }
});
