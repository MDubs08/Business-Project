$(document).ready(function() {
    $('#list').click(function(event){event.preventDefault();$('#products .item').addClass('list-group-item');});
    $('#grid').click(function(event){event.preventDefault();$('#products .item').removeClass('list-group-item');$('#products .item').addClass('grid-group-item');});
});

window.onload = function () {
    document.getElementById("addIngredient").onclick = addIngredient;
    //document.getElementById("addItem").onclick = addItem;
}


function addItem() {
    var item = '<div class="item add-on col-md-4">';
    item += '<div class="thumbnail">';
    item += '<img class="group list-group-image" src="~/Content/Pictures/Food/classic.jpg" alt="" />';
    item += '<div class="caption">';
    item += '<h4 id="menuItemTitle" class="group inner list-group-item-heading">The Classic</h4>';
    item += '<p id="menuItemDescription" class="group inner list-group-item-text">Where it all began. This tasty favorite comes with lettuce, tomatoes, onions, pickles, and a whole lot of flavor. There' + "'" + 's a reason it' + "'" + 's our #1 seller!</p>';
    item += '<div class="row">';
    item += '<div class="col-md-1"></div>';
    item += '<div class="col-md-2">';
    item += '<p class="lead" id="menuPrice">$6.00</p>';
    item += '</div>';
    item += '<div class="col-md-1"></div>';
    item += '<div class="col-md-4">';
    item += '<a class="btn btn-success" id="order">Add to Order</a>';
    item += '</div>';
    item += '<div class="col-md-4">';
    item += '<div class="input-append spinner " data-trigger="spinner">';
    item += '<div class="col-md-8">';
    item += '<input type="text" placeholder="1" data-rule="quantity" class="form-control">';
    item += '</div>';
    item += '<div class="col-md-4">';
    item += '<a href="javascript:;" class="spin-up" data-spin="up">';
    item += '<span class="glyphicon glyphicon-chevron-up spinner"></span></a>';
    item += '<a href="javascript:;" class="spin-down" data-spin="down"><span class="glyphicon glyphicon-chevron-down spinner"></span></a>';
    item += '</div></div></div></div></div></div></div>';
    $('#addItem').html('<div class="container">' + item + '</div>');
};

function addToOrder() {
    
};
function addMenuItem(itemIDTag, imageSource, itemTitle, itemDescription, itemPrice) {
    var menuItemMarkup = "";
    menuItemMarkup = '<div id="' + itemIDTag + '" class="item add-on col-md-4">';
    menuItemMarkup += '<div class="thumbnail">';
    menuItemMarkup += '<img class="group list-group-image" src="' + imageSource + '" alt="Menu Item Image" style="width:330px;height:228px; padding-top: 20px;/>';
    menuItemMarkup += '<div class="caption">';
    menuItemMarkup += '<h4 id="' + itemIDTag + 'menuItemTitle" class="group inner list-group-item-heading">' + itemTitle + '</h4>'
    menuItemMarkup += '<p id="menuItemDescription" class="group inner list-group-item-text">' + itemDescription + '</p>';
    menuItemMarkup += '<div class="row">';
    menuItemMarkup += '<center><p id="' + itemIDTag + 'itemPrice" class="lead">$' + itemPrice + '</p></center></div>';
    menuItemMarkup += '<div class="row">';
    menuItemMarkup += '<center><a class="btn btn-success" id="order" onclick="addElement(';
    menuItemMarkup += "'" + itemIDTag + "'";
    menuItemMarkup += ');">Add to Order</a></center></br></div>';
    menuItemMarkup += '</div></div></div>';
    document.getElementById("products").innerHTML += menuItemMarkup;
}
