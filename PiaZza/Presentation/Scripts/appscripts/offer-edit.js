var vehiclesSubcategory = ["Cars", "Trucks", "BIG trucks", "Motorcycles", "Others"];
var electronicsSubcategory = ["Mobile phones", "Accessories", "Computer", "TV", "Others"];
var estatesSubcategory = ["Sell", "Rent", "Buy", "Hire", "Others"];
var petsSubcategory = ["Pets", "Pet food", "Others"];
var homeSubcategory = ["Furniture", "Home accessories", "Garden tools", "Others"];

$(document).ready(function () {
    $("#Category").change(function () {
        var category = $(this).val();
        var optionContent = "";
        if (category == "Electronics") {
            optionContent = "";
            for (let i = 0; i < 5; i++)
            {
                optionContent += "<option value='" + electronicsSubcategory[i] + "'>" + electronicsSubcategory[i] + "</option>"
            }
            $("#Subcategory").html(optionContent);
        }
        else if (category == "Vehicles") {
            optionContent = "";
            for (let i = 0; i < 5; i++) {
                optionContent += "<option value='" + vehiclesSubcategory[i] + "'>" + vehiclesSubcategory[i] + "</option>"
            }
            $("#Subcategory").html(optionContent);
        }
        else if (category == "Home and garden") {
            optionContent = "";
            for (let i = 0; i < 4; i++) {
                optionContent += "<option value='" + homeSubcategory[i] + "'>" + homeSubcategory[i] + "</option>"
            }
            $("#Subcategory").html(optionContent);
        }
        else if (category == "Pets") {
            optionContent = "";
            for (let i = 0; i < 3; i++) {
                optionContent += "<option value='" + petsSubcategory[i] + "'>" + petsSubcategory[i] + "</option>"
            }
            $("#Subcategory").html(optionContent);
        }
        else if (category == "Estates") {
            optionContent = "";
            for (let i = 0; i < 5; i++) {
                optionContent += "<option value='" + estatesSubcategory[i] + "'>" + estatesSubcategory[i] + "</option>"
            }
            $("#Subcategory").html(optionContent);
        }
    });
});
