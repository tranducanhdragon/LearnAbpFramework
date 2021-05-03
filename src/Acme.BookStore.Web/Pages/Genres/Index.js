$(function () {
    var l = abp.localization.getResource('BookStore');
    var createModal = new abp.ModalManager(abp.appPath + 'Genres/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Genres/EditModal');

    var dataTable = $('#GenresTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.bookStore.genres.genre.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('BookStore.Genres.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                        //acme.bookStore.genres.genre
                                        //    .update(data.record.id, data.record)
                                        //    .then(function () {
                                        //        abp.notify.info(
                                        //            l('SuccessfullyUpdated')
                                        //        );
                                        //        dataTable.ajax.reload();
                                        //    });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('BookStore.Genres.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'BookDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        acme.bookStore.genres.genre
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name"
                }
            ]
        })

    );
    createModal.onResult(function () {
        dataTable.ajax.reload();
    })
    editModal.onResult(function () {
        dataTable.ajax.reload();
    })

    $('#NewGenreButton').click(function (e) {
        createModal.open();
    });
})