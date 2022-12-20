
$('#categoryFilter input:checkbox').change(
    function () {
        if ($(this).is(':checked')) {
            var valueCheck = false;
            var value = $(this).siblings('input').val();
            value = parseInt(value);
            var categoryArr = [];
            categoryArrStr = getCookie("categoryItems");
            if (categoryArrStr.length == 0) { setCookie("categoryItems", JSON.stringify(categoryArr)) };
            //if (categoryArr.length != 0) { categoryArr = JSON.stringify(categoryArr) }


            categoryArrStr = getCookie("categoryItems");
            var arrs = JSON.parse(categoryArrStr);
            for (var i = 0; i < arrs.length; i++) {
                if (arrs[i] == value) { valueCheck = true; }
            }
            if (valueCheck == false) { arrs.push(value); }

            setCookie("categoryItems", JSON.stringify(arrs))
            //console.log(arrs);

        }
        else {
            var value = $(this).siblings('input').val();
            var categoryArr = [];

            categoryArrStr = getCookie("categoryItems");
            if (categoryArrStr.length != 0) {
                categoryArrStr = JSON.parse(categoryArrStr)
            }
            for (var i = 0; i < categoryArrStr.length; i++) {
                if (categoryArrStr[i] == value) { categoryArrStr.splice(i, 1); }
            }

            console.log(categoryArrStr);
            setCookie("categoryItems", JSON.stringify(categoryArrStr))
        }

    }
);



$('#categoryFilter input:checkbox').change(
    function () {
        var tempCategoryArr = [];
        categoryArrStr = getCookie("categoryItems");
        if (categoryArrStr.length != 0) {
            categoryArr = JSON.parse(categoryArrStr)
        }
        for (var i = 0; i < categoryArr.length; i++) {

            tempCategoryArr.push(categoryArr[i])
        }
        console.log("json-");
        console.log(typeof(tempCategoryArr));
        console.log(typeof(JSON.stringify(tempCategoryArr)) );

        datatosend = json.stringify({ 'categoryfilterviewmodel': tempcategoryarr });
        console.log(datatosend);
        //$.ajax({
        //    contentType: 'application/json; charset=utf-8',
        //    dataType: 'json',
        //    type: 'POST',
        //    url: 'FilterMehsul',
        //    //data: { "json": JSON.stringify(tempCategoryArr) },
        //    data: { "json": "salam" },
        //    success: function (data) {
        //        alert('PassThings()" successfully called.');
        //    },
        //    error: function (response) {
        //        alert(' AKUAA.');
        //    }
        //})


        for (var i = 0; i < categoryArr.length; i++) {

            tempCategoryArr.push(categoryArr[i])

        }

        console.log("temp");
        console.log(tempCategoryArr);
        $.post("FilterMehsul", { 'CategoryIds[]': tempCategoryArr });


        //$.ajax({
        //    url: '/product/FilterMehsul/' + categoryArrStr,
        //    type: 'POST',
        //    dataType: 'json',
        //    success: function (data) {
        //        console.log(data);
        //    }
        //})

    }
);

//categoryIsCheck Start
var arry = [];
var categoryBox = document.querySelectorAll("#categoryCheckBox");
for (var i = 0; i < categoryBox.length; i++) {
    arry.push(categoryBox[i]);
}
categoryIsCheck = getCookie("categoryItems");
if (categoryIsCheck.length != 0) {
    categoryIsCheck = JSON.parse(categoryIsCheck)
}
for (var i = 0; i < categoryIsCheck.length; i++) {
    for (var x = 0; x < arry.length; x++) {
        if (categoryIsCheck[i] == arry[x].lastElementChild.value) {
            arry[x].firstElementChild.checked = true;
        }
    }
}
//categoryIsCheck End

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





//$(function () {
//    categoryArrStr = getCookie("categoryItems");
//    $.ajax({
//        url: '/product/mehsullar/' + categoryArrStr,
//        type: 'POST',
//        dataType: 'json',
//        success: function (data) {
//            console.log(data);
//        }
//    })


//});





//$(document).ready(function () {
//    var things = [
//        { id: 1, color: 'yellow' },
//        { id: 2, color: 'blue' },
//        { id: 3, color: 'red' }
//    ];

//    things = JSON.stringify({ 'things': things });

//    $.ajax({
//        contentType: 'application/json; charset=utf-8',
//        dataType: 'json',
//        type: 'POST',
//        url: '/Home/PassThings',
//        data: things,
//        success: function () {
//            $('#result').html('"PassThings()" successfully called.');
//        },
//        failure: function (response) {
//            $('#result').html(response);
//        }
//    });
//});


//public void PassThings(List < Thing > things)
//{
//    var t = things;
//}

//public class Thing {
//    public int Id { get; set; }
//    public string Color { get; set; }
//}