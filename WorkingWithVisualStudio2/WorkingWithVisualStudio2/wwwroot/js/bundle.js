document.addEventListener("DOMContentLoaded", function () {
    var element = document.createElement("p");
    element.textContent = "To jest element z pliku fourth.js.";
    document.querySelector("body").appendChild(element);
})
document.addEventListener("DOMContentLoaded", function () {
    var element = document.createElement("p");
    element.textContent = "To jest element ze zmodyfikowanego pliku third.js.";
    document.querySelector("body").appendChild(element);
})