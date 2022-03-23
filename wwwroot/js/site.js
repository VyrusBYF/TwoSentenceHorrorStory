// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const showPostSentence = function () {
    const postSentence = document.getElementById("Sentence-2");
    const showbtn = document.getElementById("showbtn");
    if (postSentence.style.display === "none") {
        postSentence.style.display = "block";
        showbtn.style.display = "none";

    } else {
        postSentence.style.display = "none";
        showbtn.style.display = "block";
    }
}