$(function () {
    $("#cadastro-funcionario-privilegio").select2({
        ajax: {
            url: '/privilegio/obtertodosparajson',
            dataType: 'json'
        }
    });

});