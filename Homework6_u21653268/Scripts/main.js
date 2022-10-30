function OpenEditModal(id) {
    var data = { product_id: id };
    $.ajax(
        {
            type: 'GET',
            url: '/products/Edit/' + id,
            contentType: 'application/json; charset=utf=8',
            data: data,
            success: function (result) {
                $('#modal-edit-content').html(result);
                $('#modal-edit').modal('show');
            },
            error: function (er) {
                alert(er);
            }
        });
}

function OpenDeleteModal(id) {
    var data = { product_id: id };
    $.ajax(
        {
            type: 'GET',
            url: '/products/Delete/' + id,
            contentType: 'application/json; charset=utf=8',
            data: data,
            success: function (result) {
                $('#modal-delete-content').html(result);
                $('#modal-delete').modal('show');
            },
            error: function (er) {
                alert(er);
            }
        });
}

function OpenDetailsModal(id) {
    var data = { product_id: id };
    $.ajax(
        {
            type: 'GET',
            url: '/products/Details/' + id,
            contentType: 'application/json; charset=utf=8',
            data: data,
            success: function (result) {
                $('#modal-details-content').html(result);
                $('#modal-details').modal('show');
            },
            error: function (er) {
                alert(er);
            }
        });
}

function OpenAddModal() {
    $.ajax(
        {
            type: 'GET',
            url: '/products/Create',
            contentType: 'application/json; charset=utf=8',
            success: function (result) {
                $('#modal-add-content').html(result);
                $('#modal-add').modal('show');
            },
            error: function (er) {
                alert(er);
            }
        });
}