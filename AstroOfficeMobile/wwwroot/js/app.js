window.fnFocusBlazorElement = function (element) {
    if (element instanceof HTMLInputElement) {
        element.focus();
    }

}

window.fnSelectTextBlazorElement = function (element) {
    if (element instanceof HTMLInputElement) {
        element.select();
    }

}

window.fnShowModal = function (element) {
    if (element instanceof HTMLDivElement) {
        $(element).modal('show');
    }

}
window.fnCloseModal = function (element) {
    if (element instanceof HTMLDivElement) {
        $(element).modal('hide');
    }

}

window.fnShowOtpModal = function (element) {
    if (element instanceof HTMLDivElement) {
        $('[data-mask]', element).inputmask({ 'placeholder': '' });
        const inputs = $('.otp-field > input', element);

        const button = $('.btn[data-group!="otp"]', element);

        inputs.each(function (index) {
            if (index == 0) {
                $(this).val('').prop('disabled', false)[0].focus();
            } else {
                $(this).val('').prop('disabled', true);
            }
        });

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

}



window.fnApplyInputMask = function (element, mask, placeHolder) {
    if (element instanceof HTMLInputElement) {
        $(element).inputmask(mask, { 'placeholder': placeHolder });
    }

}

window.fnGetInputMaskValue = function (element) {
    if (element instanceof HTMLInputElement) {
        var test = $(element).val();
        return $(element).val();
    }

}

window.fnGetOtpValue = function (element) {
    if (element instanceof HTMLDivElement) {
        var concatenatedValue = "";
        $('input[type="text"][data-inputmask]').each(function () {
            concatenatedValue += $(this).val();
        });
        return concatenatedValue;
    }

}


window.fnCloseModal = function (element) {
    if (element instanceof HTMLDivElement) {
        $(element).modal('hide');
    }

}

window.fnLoadDateTimePicker = function (element, format) {
    if (element instanceof HTMLDivElement) {
        $(element).datetimepicker({ icons: { time: 'far fa-clock' }, format: 'MM/DD/YYYY HH:mm:ss' });
    }
}

window.fnGetDateFromDateTimePicker = function (element) {
    if (element instanceof HTMLDivElement) {
        //return new Date($('input', element).val());
        return $(element).datetimepicker('date').format('MM,DD,YYYY,HH,mm,ss');
    }

    return null;
}

window.fnOpenDocumentInNewTab = function (fileName, base64Data) {
    if (!base64Data) return;

    var byteCharacters = atob(base64Data);
    var byteNumbers = new Array(byteCharacters.length);
    for (var i = 0; i < byteCharacters.length; i++) {
        byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    var byteArray = new Uint8Array(byteNumbers);
    var pdfBlob = new Blob([byteArray], { type: 'application/pdf' });

    var pdfUrl = URL.createObjectURL(pdfBlob);

    window.open(pdfUrl, '_blank');
    URL.revokeObjectURL(pdfUrl);
}

//window.fnShowToast = function (title, icon, position) {
//    Swal.mixin({
//        toast: true,
//        position: position,
//        showConfirmButton: false,
//        timer: 3000
//    }).fire({
//        icon: icon,
//        allowOutsideClick: true, // Set this to true to allow closing by clicking outside
//        backdrop: true, // Set this to true to display a backdrop (overlay) behind the modal
//        html: '<br />' + title,
//        timerProgressBar: true,
//        allowEscapeKey: true,
//        allowOutsideClick: true,
//        showClass: {
//            popup: 'animate__animated animate__fadeInRight'
//        },
//        hideClass: {
//            popup: 'animate__animated animate__fadeOutRight'
//        }
//    });
//}


window.fnShowToast = function (title, icon, position) {
    Swal.fire({
        icon: icon,
        html: '<br />' + title,
        position: position,
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true,
        toast: true,
        showClass: {
            popup: 'animate__animated animate__fadeInRight'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutRight'
        }
    });
}

window.fnAddSidebarCollapse = function () {
    $('body').addClass('sidebar-collapse');

}

window.fnAddSidebarClose = function () {
    $('body').addClass('sidebar-close');
}