
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



