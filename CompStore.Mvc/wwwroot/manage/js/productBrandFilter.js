let select = document.querySelector(".select1 select");

select.addEventListener('change', function handleChange(event) {

    var options = select.options[select.selectedIndex];

    var categoryId = options.getAttribute('data-id');

    let select2 = document.querySelector(".select2 select");

    fetch("/manage/product/getBrand?categoryId=" + categoryId)
        .then(response => response.json())
        .then(data => {
            select2.innerHTML = "";
            for (var i = 0; i < data.length; i++) {
                const newOption = document.createElement("option");
                newOption.value = data[i].id;
                newOption.dataset.id = data[i].id;
                newOption.innerText = data[i].name;
                select2.appendChild(newOption);
            }
        })
});