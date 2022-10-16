


$('#categoryFilter input:checkbox').change(
    function () {
        if ($(this).is(':checked')) {
            var valueCheck = false;
            var value = $(this).siblings('input').val();
            value = parseInt(value);
            var categoryArr = [];
            var catArryStr = localStorage.getItem("catArry");
            if (catArryStr != null) { categoryArr = JSON.parse(catArryStr) }

            for (var i = 0; i < categoryArr.length; i++) {
                if (categoryArr[i] == value) {
                    valueCheck = true;
                }
            }
            if (valueCheck == false) { categoryArr.push(value); }
            localStorage.setItem("catArry", JSON.stringify(categoryArr));
            let arr = JSON.parse(catArryStr);
            console.log(categoryArr);
        }
        else {
            var catArryStr = localStorage.getItem("catArry");
            var categoryArr = [];
            if (catArryStr != null) {
                catArryStr = JSON.parse(catArryStr)
            }
            var value = $(this).siblings('input').val();
            for (var i = 0; i < catArryStr.length; i++) {
                if (catArryStr[i] == value) {
                    catArryStr.splice(i, 1);
                }
            }
            localStorage.setItem("catArry", JSON.stringify(catArryStr));
        }
    });

$('#brendFilter input:checkbox').change(
    function () {
        if ($(this).is(':checked')) {
            var value = $(this).siblings('input').val();
            console.log(value);
            var brendArr = [];
            brendArr.push(value);
            console.log(brendArr);

        }
    });