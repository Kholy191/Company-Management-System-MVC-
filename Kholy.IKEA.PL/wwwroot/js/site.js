// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function attachSearchHandler() {
    var SearchInp = document.getElementById("searchInp");

    if (!SearchInp) return;

    let debounceTimer;

    SearchInp.addEventListener("keyup", function () {
        clearTimeout(debounceTimer);
        debounceTimer = setTimeout(() => {
            var searchValue = SearchInp.value;

            var xhr = new XMLHttpRequest();
            xhr.open("GET", `/Employee/Index?search=${encodeURIComponent(searchValue)}`);
            xhr.onreadystatechange = function () {
                if (xhr.readyState === XMLHttpRequest.DONE) {
                    if (xhr.status === 200) {
                        // Replace body
                        const parser = new DOMParser();
                        const newDoc = parser.parseFromString(xhr.responseText, "text/html");
                        document.body.innerHTML = newDoc.body.innerHTML;

                        // Restore input value if it still exists
                        const newSearchInp = document.getElementById("searchInp");
                        if (newSearchInp) newSearchInp.value = searchValue;

                        // Re-attach handler
                        attachSearchHandler();
                    } else {
                        alert("Something went wrong.");
                    }
                }
            };
            xhr.send();
        }, 300);
    });
}

document.addEventListener("DOMContentLoaded", attachSearchHandler);
