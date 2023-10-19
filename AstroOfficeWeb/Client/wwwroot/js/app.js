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

function togglePasswordVisibility(inputId, iconId) {
    const inputField = document.getElementById(inputId);
    const toggleIcon = document.getElementById(iconId);

    if (inputField.type === "password") {
        inputField.type = "text";
        toggleIcon.classList.remove("fa-eye-slash");
        toggleIcon.classList.add("fa-eye");
    } else {
        inputField.type = "password";
        toggleIcon.classList.remove("fa-eye");
        toggleIcon.classList.add("fa-eye-slash");
    }

    // Return the focus to the input field
    inputField.focus();
}





window.fnShowOtpModal = function (element) {
    if (element instanceof HTMLDivElement) {

        $('[data-mask]', element).inputmask({ 'placeholder': '' });
        const inputs = $('.otp-field > input', element);

        const button = $('.btn[data-dismiss!="modal"]', element);

        inputs[0].focus();
        button.prop('disabled', true);

        inputs.first().on('paste', function (event) {
            event.preventDefault();

            const pastedValue = (event.originalEvent.clipboardData || window.clipboardData).getData('text');
            const otpLength = inputs.length;

            inputs.each(function (index) {
                if (index < pastedValue.length) {
                    $(this).val(pastedValue[index]);
                    $(this).prop('disabled', false);
                    $(this)[0].focus();
                } else {
                    $(this).val('');
                    $(this)[0].focus();
                }
            });
        });

        inputs.each(function (index1) {
            $(this).on('keyup', function (e) {
                const currentInput = $(this);
                const nextInput = currentInput.next();
                const prevInput = currentInput.prev();

                if (currentInput.val().length > 1) {
                    currentInput.val('');
                    return;
                }

                if (nextInput.length && nextInput.prop('disabled') && currentInput.val() !== '') {
                    nextInput.prop('disabled', false);
                    nextInput[0].focus();
                }

                if (e.key === 'Backspace') {
                    inputs.each(function (index2) {
                        if (index1 <= index2 && prevInput.length) {
                            $(this).prop('disabled', true);
                            $(this).val('');
                            prevInput[0].focus();
                        }
                    });
                }

                button.removeClass('active');
                button.prop('disabled', true);

                const inputsNo = inputs.length;
                if (!inputs.eq(inputsNo - 1).prop('disabled') && inputs.eq(inputsNo - 1).val() !== '') {
                    button.addClass('active');
                    button.prop('disabled', false);
                }
            });
        });

        $(element).modal('show');
    }
    console.log(element);
}



window.fnApplyInputMask = function (element, mask, placeHolder) {
    if (element instanceof HTMLInputElement) {
        $(element).inputmask(mask, { 'placeholder': placeHolder });
    }
    console.log(element);
}

window.fnGetInputMaskValue = function (element) {
    if (element instanceof HTMLInputElement) {
        var test = $(element).val();
        console.log(test);
        return $(element).val();
    }
    console.log(element);
}

window.fnGetOtpValue = function (element) {
    if (element instanceof HTMLDivElement) {
        var concatenatedValue = "";
        $('input[type="text"][data-inputmask]').each(function () {
            concatenatedValue += $(this).val(); 
        });
        return concatenatedValue;
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
    var pdfBlob = new Blob([byteArray], { type: 'application/pdf' });

    // Create a URL for the Blob
    var pdfUrl = URL.createObjectURL(pdfBlob);

    // Open the PDF in a new tab
    window.open(pdfUrl, '_blank');

    // Clean up resources
    URL.revokeObjectURL(pdfUrl);


    //var newWindow = window.open(dataUrl, '_blank');
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


