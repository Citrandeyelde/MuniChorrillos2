// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", () => {

    const toggleButton = document.querySelector(".navbar__toogle-btn");
    const mobileMenu = document.querySelector(".navbar__mobile-menu");

    const toggleMenu = () => {
        mobileMenu.style.display =
            mobileMenu.style.display === "none" || mobileMenu.style.display === ""
            ? "flex"            
            : "none";
    };

    const hideMenuResize = () => {
        mobileMenu.style.display = "none"
    }

    toggleButton.addEventListener("click", toggleMenu);

    window.addEventListener("resize", hideMenuResize);

    window.addEventListener("load", hideMenuResize);
});