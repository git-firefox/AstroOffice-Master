window.fnFocusBlazorElement = function (element) {
    if (element instanceof HTMLInputElement) {
        element.focus();
    }
    console.log(element);
}

window.fnSelectTextBlazorElement = function (element) {
    if (element instanceof HTMLInputElement) {
        element.select();
    }
    console.log(element);
}

window.fnShowModal = function (element) {
    if (element instanceof HTMLDivElement) {
        $(element).modal('show');
    }
    console.log(element);
}
window.fnCloseModal = function (element) {
    if (element instanceof HTMLDivElement) {
        $(element).modal('hide');
    }
    console.log(element);
}

window.fnLoadDateTimePicker = function (element, format) {
    if (element instanceof HTMLDivElement) {
        $(element).datetimepicker({ icons: { time: 'far fa-clock' }, format: 'MM/DD/YYYY HH:mm:ss' });
    }
    console.log(element);
    console.log(format);
}

window.fnGetDateFromDateTimePicker = function (element) {
    if (element instanceof HTMLDivElement) {
        console.log($(element).datetimepicker('date').format('MM,DD,YYYY,HH,mm,ss'));
        //return new Date($('input', element).val());
        return $(element).datetimepicker('date').format('MM,DD,YYYY,HH,mm,ss');
    }
    console.log(element);
    return null;
}

window.fnOpenDocumentInNewTab = function (fileName, base64Data) {
    //var blob = fnBase64Blob(base64Data);
    //var blobURL = URL.createObjectURL(blob);
    // Create a Blob from the Base64 PDF data
    if (!base64Data) return;

    var byteCharacters = atob(base64Data);
    var byteNumbers = new Array(byteCharacters.length);
    for (var i = 0; i < byteCharacters.length; i++) {
        byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    var byteArray = new Uint8Array(byteNumbers);
    var pdfBlob = new Blob([byteArray], { type: "application/pdf" });

    // Create a URL for the Blob
    var pdfUrl = URL.createObjectURL(pdfBlob);

    // Open the PDF in a new tab
    window.open(pdfUrl, "_blank");

    // Clean up resources
    URL.revokeObjectURL(pdfUrl);


    //var newWindow = window.open(dataUrl, "_blank");
    console.log(pdfUrl);
    console.log(byteNumbers);
    console.log(base64Data);

    //window.open(blobURL);
}

function fnBase64Blob(base64Data) {
    var sliceSize = 512;
    var byteCharacters = atob(base64Data);
    var byteArrays = [];

    for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        var slice = byteCharacters.slice(offset, offset + sliceSize);
        var byteNumbers = new Array(slice.length);
        for (var i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
            var byteArray = new Uint8Array(byteNumbers);
            byteArrays.push(byteArray);
        }
        var blob = new Blob(byteArrays, { type: 'application/pdf' });
        return blob;
    }
}


