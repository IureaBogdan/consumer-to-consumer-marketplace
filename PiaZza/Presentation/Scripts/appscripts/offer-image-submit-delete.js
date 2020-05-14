function deleteOfferImage(id, event) {
    event.preventDefault();
    $.ajax({
        method: "DELETE",
        url: "/api/offer/" + id,
        success: function () {
            var card = $("#" + id);
            card.remove();
        },
        error: function (error) {
            console.log(error);
        }
    });
} 