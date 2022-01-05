
//-------------js for toggle menu-----------

function menutoggle() {
    var MenuItems = document.getElementById("MenuItems");

    MenuItems.style.maxHeight = "0px";

    if (MenuItems.style.maxHeight == "0px") {
        MenuItems.style.maxHeight = "200px"
    }
    else {
        MenuItems.style.maxHeight = "0px"
    }
}

//--------------js for toggle form----------->

function register() {
    var RegForm = document.getElementById("RegForm");
    var Indicator = document.getElementById("Indicator");
    LoginForm.style.transform = "translateX(0px)";
    RegForm.style.transform = "translateX(0px)";
    Indicator.style.transform = "translateX(100px)";
}


function login() {
    var LoginForm = document.getElementById("LoginForm");
    var Indicator = document.getElementById("Indicator");
    LoginForm.style.transform = "translateX(300px)";
    RegForm.style.transform = "translateX(300px)";
    Indicator.style.transform = "translateX(0px)";
}

//--------------js for product gallery----------->

function initProductimages() {
    var ProductImg = document.getElementById('ProductImg')
    var SmallImg = document.getElementsByClassName('small-img')

    SmallImg[0].onclick = function () {
        ProductImg.src = SmallImg[0].src;
    }
    SmallImg[1].onclick = function () {
        ProductImg.src = SmallImg[1].src;
    }
    SmallImg[2].onclick = function () {
        ProductImg.src = SmallImg[2].src;
    }
    SmallImg[3].onclick = function () {
        ProductImg.src = SmallImg[3].src;
    }
}



