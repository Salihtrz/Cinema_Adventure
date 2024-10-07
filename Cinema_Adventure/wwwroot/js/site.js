// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function validateForm() {
    var email = document.getElementById("ContactEmail").value;
    var address = document.getElementById("ContactAddress").value;
    var number = document.getElementById("ContactNumber").value;

    if (email === "" || address === "" || number === "") {
        alert("Lütfen tüm alanları doldurun.");
        return false;
    }
    return true;
}
document.addEventListener('DOMContentLoaded', function () {
    const stars = document.querySelectorAll('.star-container .star');
    const voteInput = document.getElementById('VoteGiven');

    stars.forEach(star => {
        star.addEventListener('click', function () {
            const value = this.getAttribute('data-value');
            voteInput.value = value;

            stars.forEach(s => {
                if (s.getAttribute('data-value') <= value) {
                    s.classList.add('selected');
                } else {
                    s.classList.remove('selected');
                }
            });
        });
    });
});





function searchCast() {
    var input, filter, select, option, i, txtValue;
    input = document.getElementById("searchCast");
    filter = input.value.toUpperCase();
    select = document.getElementById("selectedCastId");
    option = select.getElementsByTagName("option");
    for (i = 0; i < option.length; i++) {
        txtValue = option[i].textContent || option[i].innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            option[i].style.display = "";
        } else {
            option[i].style.display = "none";
        }
    }
}
document.addEventListener('DOMContentLoaded', function () {
    var selectedCasts = [];
    var dropdown = document.getElementById("castDropdown");

    // DropDownList'ta bir öğe seçildiğinde
    dropdown.addEventListener("change", function () {
        // Seçilen oyuncunun değerini al
        var selectedCastId = this.value;
        // Seçilen oyuncunun adını ve soyadını al
        var selectedCastName = this.options[this.selectedIndex].text;

        // Seçilen oyuncunun dropdown listesinden kaldırılması
        this.options[this.selectedIndex].disabled = true;

        // Seçilen oyuncuyu selectedCasts dizisine ekle
        selectedCasts.push({ id: selectedCastId, name: selectedCastName });

        // textarea içeriğini ve listeyi güncelle
        updateTextArea();
    });
});

document.addEventListener('DOMContentLoaded', function () {
    var selectedCategorys = [];
    var dropdown = document.getElementById("categoryDropdown");

    // DropDownList'ta bir öğe seçildiğinde
    dropdown.addEventListener("change", function () {
        // Seçilen oyuncunun değerini al
        var selectedCategoryId = this.value;
        // Seçilen oyuncunun adını ve soyadını al
        var selectedCategoryName = this.options[this.selectedIndex].text;

        // Seçilen oyuncunun dropdown listesinden kaldırılması
        this.options[this.selectedIndex].disabled = true;

        // Seçilen oyuncuyu selectedCasts dizisine ekle
        selectedCategorys.push({ id: selectedCategoryId, name: selectedCategoryName });

        // textarea içeriğini ve listeyi güncelle
        updateTextArea();
    });
});