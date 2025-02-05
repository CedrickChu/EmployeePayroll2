window.showModal = (modalId) => {
    var modal = new bootstrap.Modal(document.querySelector(modalId));
    modal.show();
}

function resetStudentIdInput(inputId) {
    document.getElementById(inputId).value = '';
};

window.initSelectize = (id) => {
    $('#' + id).selectize();
};