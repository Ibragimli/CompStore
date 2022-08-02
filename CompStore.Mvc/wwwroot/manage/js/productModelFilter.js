let select2 = document.querySelector(".select2 select");

select2.addEventListener('change', function handleChange(event) {

    var options = select2.options[select2.selectedIndex];

    var brandId = options.getAttribute('data-id');
    let select3 = document.querySelector(".select3 select");

    fetch("/manage/product/getModel?brandId=" + brandId)
        .then(response => response.json())
        .then(data => {

            console.log(data);

            select3.innerHTML = "";
            console.log(select3);

            for (var i = 0; i < data.length; i++) {
                const newOption = document.createElement("option");
                newOption.value = data[i].id;
                newOption.innerText = data[i].name;
                console.log(newOption);
                select3.appendChild(newOption);
            }
        })
});