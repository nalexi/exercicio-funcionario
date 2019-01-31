$(function () {
    $("#cadastro-funcionario-privilegio").select2({
        ajax: {
            url: '/privilegio/obtertodosparajson',
            dataType: 'json'
        }
    }).on('select2:select', function (e) {
        $("#tabela-funcionarios").DataTable().ajax.reload();
    })

    $("#tabela-funcionarios").DataTable({
        "serverSide": true,
        "ajax": {
            "url": "/funcionario/ObterDataTable",
             "data": function (d) {
                d.idPrivilegio = $("#cadastro-funcionario-privilegio").val();
            },
        },
        "columns": [
            { "data": "Id", "name": "id" },
            { "data": "Privilegio.Nome", "name": "privilegio" },
            { "data": "Nome", "name": "nome" },
            { "data": "Login", "name": "nome" },
            { "data": "Senha", "name": "nome" },
            { "data": "Sexo", "name": "nome" },
            { "data": "Salario", "name": "nome" },
            {
                "data": null,
                "orderable": false,
                "render": function (data) {
                    return "<button class='btn btn-primary botao-editar' data-id='" + data.Id + "'>Editar</button>\
                     <button class='btn btn-danger botao-apagar' data-id='" + data.Id + "'>Apagar</button>"
                }
            }
        ],
        "language": {
            "decimal": "",
            "emptyTable": "Nenhum Registro Cadastrado",
            "info": "Mostrando _START_ de _END_ de _TOTAL_ Registros Total",
            "infoEmpty": "Mostrando 0 Registros",
            "infoFiltered": "(De um total de _MAX_ Registros)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Registros",
            "loadingRecords": "Carregando",
            "processing": "Processing...",
            "search": "Busca:",
            "zeroRecords": "Nada",
            "paginate": {
                "first": "Primeiro",
                "last": "Ultimo",
                "next": "Proximo",
                "previous": "Anterior"
            },
            "aria": {
                "sortAscending": ": activate to sort column ascending",
                "sortDescending": ": activate to sort column descending"
            }
        }
    });

});