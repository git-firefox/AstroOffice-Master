window.fnFocusBlazorElement = function (element) {
    if (element instanceof HTMLInputElement) {
        element.focus();
    }
    console.log(element)
}



window.fnSelectTextBlazorElement = function (element) {
    if (element instanceof HTMLInputElement) {
        element.select();
    }
    console.log(element)
}
