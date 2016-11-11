$(document).ready(function() {
    $('#list').click(function(event){event.preventDefault();$('#products .item').addClass('list-group-item');});
    $('#grid').click(function(event){event.preventDefault();$('#products .item').removeClass('list-group-item');$('#products .item').addClass('grid-group-item');});
});

window.onload = function () {
    document.getElementById("addIngredient").onclick = addIngredient;
    document.getElementById("addItem").onclick = addItem;
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
    var orderItem = '<div class="col-md-4"></div>';
    orderItem += '';
    $('#currentOrder').html('<div class="container">' + orderItem + '</div>')
};

function addIngredient() {
    var ingredient = '<div class="form-group">';
    ingredient += '@Html.ValidationSummary(true, "", new { @class = "text-danger" })';
    ingredient += '<div class="form-group">';
    ingredient += '@Html.LabelFor(model => model.InventoryID, "InventoryID", htmlAttributes: new { @class = "control-label col-md-2" })';
    ingredient += '<div class="col-md-10">';
    ingredient += '@Html.DropDownList("InventoryID", null, htmlAttributes: new { @class = "form-control" })';
    ingredient += '@Html.ValidationMessageFor(model => model.InventoryID, "", new { @class = "text-danger" })';
    ingredient += '</div></div>';
    $('#addIngredients').html('<div class="form-group">' + ingredient +'<div>')
};