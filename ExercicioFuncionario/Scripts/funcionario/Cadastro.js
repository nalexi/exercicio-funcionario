$(function () {
    $("#cadastro-funcionario-privilegio").select2({
        ajax: {
            url: '/privilegio/obtertodosparajson',
            dataType: 'json'
        }
    }).on('select2:select', function (e) {
        //$("#tabela-funcionarios").DataTable().ajax.reload();
    })


});