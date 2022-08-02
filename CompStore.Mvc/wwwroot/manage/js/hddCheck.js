var isHHD = document.querySelector('.isHHDCheckInput');
var hhdHecm = document.getElementById('hddHecm');

isHHD.addEventListener('change', function () {
    if (isHHD.checked == true) {
        hhdHecm.style.display = "block"
    }
    else {
        hhdHecm.style.display = "none";
    }
});