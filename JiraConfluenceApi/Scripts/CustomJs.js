

// On click Card Open Details
function ClickCard(sender) {
    var IsClicked = $(sender).closest(".ContainerCard").find(".DetailsCard").hasClass("d-none");

    if (IsClicked) {
        $(sender).closest(".ContainerCard").find(".DetailsCard").removeClass("d-none");
    }
    else {
        $(sender).closest(".ContainerCard").find(".DetailsCard").addClass("d-none");
    }
}