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

window.fnLoadDateTimePicker = function (element, format ) {
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