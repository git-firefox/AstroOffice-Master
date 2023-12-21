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
window.fnRemoveStyle = function (element) {
    $('*', '.embed-responsive').attr('style', '')
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

window.InputMaskInterop = {
    fnInitialize: function (element, mask, placeHolder) {
        if (element instanceof HTMLInputElement) {
            $(element).inputmask(mask, { 'placeholder': placeHolder });
        }
    },

    fnAddChangeEvent: function (element, dotnetObject) {
        $(element).on("change", function () {
            var inputValue = $(this).val();
            dotnetObject.invokeMethodAsync("OnInputMaskChange", inputValue);
        });
    },
};

window.InputMaskInterop2 = {
    fnInitialize: function (element) {
        if (element instanceof HTMLInputElement) {
            $(element).mask('Z#', {
                translation: {
                    'Z': { pattern: /[1-9]/ }
                }
            });
        }
    },

    fnAddChangeEvent: function (element, dotnetObject) {
        $(element).on("change", function () {
            var inputValue = $(this).val();
            dotnetObject.invokeMethodAsync("OnInputMaskChange", inputValue);
        });
    },
};

window.InputSelect2Interop = {
    fnInitialize: function (element, dropdownParent = null) {

        var select2Config = {
            theme: 'bootstrap4',
            width: '100%',
        };
        
        if (dropdownParent != undefined || dropdownParent != null) {
            select2Config.dropdownParent = dropdownParent;
        }

        if (element instanceof HTMLSelectElement) {
            $(element).select2(select2Config);
        }
    },

    fnAddChangeEvent: function (element, dotnetObject) {
        $(element).on("change", function () {
            var inputValue = $(this).val();
            dotnetObject.invokeMethodAsync("OnInputSelect2Change", inputValue);
        });
    },
};


window.fnSummernoteInterop = function (element, height, dotnetObject) {
    if (element instanceof HTMLDivElement || element instanceof HTMLTextAreaElement) {
        $(element).summernote({
            height: height, 
            focus: true,
            callbacks: {
                onInit: function () {
                    console.log('Summernote is launched');
                },
                onChange: function (contents, $editable) {         
                    dotnetObject.invokeMethodAsync("OnInputSummernoteTextChange", contents);
                }
            }
        });
        //$(element).on('summernote.change', function (we, contents, $editable) {
        //    console.log('summernote.change', contents, $editable, we);
        //});                                                                           
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

window.fnLoadEditor = function (element) {
    if (element instanceof HTMLDivElement || element instanceof HTMLTextAreaElement) {
        $(element).summernote({
            height: 400
        });
    }
}

window.fnGetEditorValue = function (element) {
    if (element instanceof HTMLDivElement || element instanceof HTMLTextAreaElement) {
        return $(element).summernote('code');
    }
    return null;
}

window.fnLoadSelect2 = function (element) {
    if (element instanceof HTMLSelectElement) {
        $(element).select2({
            theme: 'bootstrap4',
            width: '100%',
        });
    }
}

window.fnGetSelect2Data = function (element) {
    if (element instanceof HTMLSelectElement) {
        return $(element).select2('data');
    }
    return null;
}

window.fnShowTab = function (element) {
    if (element instanceof HTMLAnchorElement) {
        $(element).tab('show');
    }
}

window.getSearchboxValue = function () {
    var value = $("#searchShopBox").val();
    return value;
}

window.getDropdownValue = function () {
    var value = $("#sortShopdropdown").val();
    return value;
}

window.getPageSizeValue = function () {
    var value = $("#pageSizeShopdropdown").val();
    return value;
}


window.fnClearFilter = function () {
    $("#searchShopBox").val();;
}
// JavaScript Document
//function isDevice() {
//    return ((/android|webos|iphone|ipad|ipod|blackberry|iemobile|opera mini/i.test(navigator.userAgent.toLowerCase())))
//}

//function initZoom(width, height) {
//    $.removeData('#zoom_10', 'elevateZoom');
//    $('.zoomContainer').remove();
//    $('.zoomWindowContainer').remove();
//    $("#zoom_10").elevateZoom({
//        responsive: true,
//        tint: true,
//        tintColour: '#E84C3C',
//        tintOpacity: 0.5,
//        easing: true,
//        borderSize: 0,
//        lensSize: 100,
//        constrainType: "height",
//        loadingIcon: "https://icodefy.com/Tools/iZoom/images/loading.GIF",
//        containLensZoom: false,
//        zoomWindowPosition: 1,
//        zoomWindowOffetx: 20,
//        zoomWindowWidth: width,
//        zoomWindowHeight: height,
//        gallery: 'gallery_pdp',
//        galleryActiveClass: "active",
//        zoomWindowFadeIn: 500,
//        zoomWindowFadeOut: 500,
//        lensFadeIn: 500,
//        lensFadeOut: 500,
//        cursor: "https://icodefy.com/Tools/iZoom/images/zoom-out.png",
//    });
//}

//$(document).ready(function () {
//    /* init vertical carousel if thumb image length greater that 4 */
//    if ($("#gallery_pdp a").length > 4) {
//        $("#gallery_pdp a").css("margin", "0");
//        $("#gallery_pdp").rcarousel({
//            orientation: "vertical",
//            visible: 4,
//            width: 105,
//            height: 70,
//            margin: 5,
//            step: 1,
//            speed: 500,
//        });
//        $("#ui-carousel-prev").show();
//        $("#ui-carousel-next").show();
//    }
//    /* Init Product zoom */
//    initZoom(500, 475);

//    $("#ui-carousel-prev").click(function () {
//        initZoom(500, 475);
//    });

//    $("#ui-carousel-next").click(function () {
//        initZoom(500, 475);
//    });

//    // $(".zoomContainer").width($("#zoom_10").width());

//    // $("body").delegate(".fancybox-inner .mega_enl", "click", function() {
//    //     $(this).html("");
//    //     $(this).hide();
//    // });
//    // $('#gallery_pdp img').click((e) => {
//    // 	console.log(e)
//    // })

//});

//$(window).resize(function () {
//    var docWidth = $(document).width();
//    if (docWidth > 769) {
//        initZoom(500, 475);
//    } else {
//        $.removeData('#zoom_10', 'elevateZoom');
//        $('.zoomContainer').remove();
//        $('.zoomWindowContainer').remove();
//        $("#zoom_10").elevateZoom({
//            responsive: true,
//            tint: false,
//            tintColour: '#3c3c3c',
//            tintOpacity: 0.5,
//            easing: true,
//            borderSize: 0,
//            loadingIcon: "https://icodefy.com/Tools/iZoom/images/loading.GIF",
//            zoomWindowPosition: "productInfoContainer",
//            zoomWindowWidth: 330,
//            gallery: 'gallery_pdp',
//            galleryActiveClass: "active",
//            zoomWindowFadeIn: 500,
//            zoomWindowFadeOut: 500,
//            lensFadeIn: 500,
//            lensFadeOut: 500,
//            cursor: "https://icodefy.com/Tools/iZoom/images/zoom-out.png",
//        });

//    }
//})

//$(document).ready(function () {
//    $("#zoom_10").fancybox();
//});


