window.showModal = (modalId) => {
    const modalElement = document.querySelector(modalId);
    if (modalElement) {
        const modal = new bootstrap.Modal(modalElement);
        modal.show();
    }
};
window.closeModal = (modalId) => {
    const modalElement = document.querySelector(modalId);
    if (modalElement) {
        let modal = bootstrap.Modal.getInstance(modalElement);
        if (modal) {
            modal.hide();
        }
    }
};
function resetStudentIdInput(inputId) {
    const inputElement = document.getElementById(inputId);
    if (inputElement) {
        inputElement.value = '';
    }
}

window.initSelectize = (id) => {
    const selectElement = $('#' + id);
    if (selectElement.length) {
        selectElement.selectize();
    }
};

function initializeDataTable() {
    $('#dataTable').DataTable({
        responsive: true,
        lengthChange: false,
        paging: true,
        dom: 'Bfrtip',
        buttons: ["copy", "excel", "colVis"],
        order: [[0, 'desc']]
    }).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');
    $('#payslipTable').DataTable({
        responsive: true,
        lengthChange: false,
        paging: true,
        dom: 'Bfrtip',
        buttons: [],
        order: [[0, 'desc']]
    });
    
    
}
