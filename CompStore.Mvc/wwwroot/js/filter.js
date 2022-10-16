
$('#categoryFilter input:checkbox').change(
    function () {


        if ($(this).is(':checked')) {
            var valueCheck = false;
            var value = $(this).siblings('input').val();
            value = parseInt(value);
            var categoryArr = [];
            categoryArrStr = getCookie("catArry");
            if (categoryArrStr.length == 0) { setCookie("catArry", JSON.stringify(categoryArr)) };
            if (categoryArr.length != 0) { categoryArr = JSON.stringify(categoryArr) }


            categoryArrStr = getCookie("catArry");
            var arrs = JSON.parse(categoryArrStr);
            for (var i = 0; i < arrs.length; i++) {
                if (arrs[i] == value) { valueCheck = true; }
            }
            if (valueCheck == false) { arrs.push(value); }

            setCookie("catArry", JSON.stringify(arrs))
            console.log(arrs);

        }
        else {
            var value = $(this).siblings('input').val();
            var categoryArr = [];

            categoryArrStr = getCookie("catArry");
            if (categoryArrStr.length != 0) {
                categoryArrStr = JSON.parse(categoryArrStr)
            }
            for (var i = 0; i < categoryArrStr.length; i++) {
                if (categoryArrStr[i] == value) { categoryArrStr.splice(i, 1); }
            }
          
            console.log(categoryArrStr);
            setCookie("catArry", JSON.stringify(categoryArrStr))
        }

        function setCookie(cname, cvalue) {
            const d = new Date();
            d.setTime(d.getTime() + (365 * 24 * 60 * 60 * 1000));
            let expires = "expires=" + d.toUTCString();
            document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
        }

        function getCookie(cname) {
            let name = cname + "=";
            let ca = document.cookie.split(';');
            for (let i = 0; i < ca.length; i++) {
                let c = ca[i];
                while (c.charAt(0) == ' ') {
                    c = c.substring(1);
                }
                if (c.indexOf(name) == 0) {
                    return c.substring(name.length, c.length);
                }
            }
            return "";
        }

    });


//$('#categoryFilter input:checkbox').change(
//    function () {
//        if ($(this).is(':checked')) {
//            var valueCheck = false;
//            var value = $(this).siblings('input').val();
//            value = parseInt(value);
//            var categoryArr = [];
//            var catArryStr = localStorage.getItem("catArry");
//            if (catArryStr != null) { categoryArr = JSON.parse(catArryStr) }
//            for (var i = 0; i < categoryArr.length; i++) {
//                if (categoryArr[i] == value) { valueCheck = true; }
//            }
//            if (valueCheck == false) { categoryArr.push(value); }
//            localStorage.setItem("catArry", JSON.stringify(categoryArr));
//            let arr = JSON.parse(catArryStr);
//            console.log(categoryArr);
//        }
//        else {
//            var catArryStr = localStorage.getItem("catArry");
//            if (catArryStr != null) {
//                catArryStr = JSON.parse(catArryStr)
//            }
//            var value = $(this).siblings('input').val();
//            for (var i = 0; i < catArryStr.length; i++) {
//                if (catArryStr[i] == value) { catArryStr.splice(i, 1); }
//            }
//            localStorage.setItem("catArry", JSON.stringify(catArryStr));
//        }
//    });

//$('#brendFilter input:checkbox').change(
//    function () {
//        if ($(this).is(':checked')) {
//            var value = $(this).siblings('input').val();
//            console.log(value);
//            var brendArr = [];
//            brendArr.push(value);
//            console.log(brendArr);

//        }
//    });




//var valueCheck = false;
//var value = $(this).siblings('input').val();
//value = parseInt(value);
//var categoryArr = [];
//categoryArrs = getCookie("catArry");
//if (categoryArrs.length == 0) { setCookie("catArry", JSON.stringify(categoryArr)) };
//if (categoryArr.length != 0) { categoryArr = JSON.stringify(categoryArr) }


//categoryArrs = getCookie("catArry");
//var arrs = JSON.parse(categoryArrs);
//arrs.push(value);
//setCookie("catArry", JSON.stringify(arrs))
//console.log(arrs);
