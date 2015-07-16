    <%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
    
    <script type="text/javascript">
        $(document).ready(function () {

            var grid = $("#flexigrid").flexigrid(
                {
                    url: '/Home/CarregaFlexgrid', //Caminho onde será ontido as informações para renderização do grid
                    dataType: 'json', //Tipo de retorno da requisição
                    colModel: //Cria as colunas 
	                    [
		                    { display: 'Código', name: 'CodCliente', width: $(document).width() * 0.10, sortable: true, align: 'center' },
		                    { display: 'Nome', name: 'Nome', width: $(document).width() * 0.10, sortable: true, align: 'left' },
                            { display: 'CPF', name: 'Cpf', width: $(document).width() * 0.10, sortable: true, align: 'left' },
                            { display: 'Telefone', name: 'Telefone', width: $(document).width() * 0.10, sortable: true, align: 'left' },
                            { display: 'Endereço', name: 'Endereco', width: $(document).width() * 0.30, sortable: true, align: 'left' }
	                    ],
                    searchitems:
			            [
				            { display: 'Nome', name: 'Nome', isdefault: true },
                            { display: 'CPF', name: 'Cpf' },
                            { display: 'Telefone', name: 'Telefone' },
                            { display: 'Endereço', name: 'Endereco' }
				        ],
                    buttons:
			            [
				            { name: 'Adicionar', onpress: adiciona, title: 'Adicionar' },
				            { name: 'Editar', onpress: edita, title: 'Editar' },
                            { name: 'Excluir', onpress: exclui, title: 'Excluir' },
                            { name: 'Verificar Seleção', onpress: visualizar, title: 'Visualizar' }
				        ],
                    title: 'GRID DE CLIENTES', //Título do grid
                    sortname: "Nome", //Campo para ordenação padrão
                    sortorder: "asc", //Tipo de ordenação padrão (asc ou desc)
                    usepager: true //Exibe a barra de status (Paginação, Busca, Status...)
                });

            function adiciona(com, g) {
                //Implementação da rotina...
            }

            function edita(com, g) {

                //Verifica se existe apenas um item selecionado
                if ($('.trSelected', g).length == 1) {
                    //Implementação da rotina...
                }
                //Verifica se existe mais que um item selecionado
                else if ($('.trSelected', g).length > 1)
                    alert('Por favor, selecione <b>somente</b> um item para editar. Obrigado.', 'ATENÇÃO');
                else
                    alert('Por favor, selecione um item para editar. Obrigado.', 'ATENÇÃO');
            }

            function exclui(com, g) {

                //Caso exista alguma linha selecionada
                if ($('.trSelected', g).length > 0) {

                    //Obtém todas as linhas selecionadas do grid
                    var linhas = $('.trSelected', g);

                    //Percorre cada linha selecionada do grid
                    for (i = 0; i < linhas.length; i++) {
                        var codCliente = $('.trSelected', g)[i].id.substr(3);
                        //Implementação da rotina...
                    }

                    //Recarrega o grid
                    grid.flexReload();
                }
                else {
                    alert('Por favor, selecione um item para excluir. Obrigado.', 'ATENÇÃO');
                }
            }

            function visualizar(com, g) {

                var linhas = $('.trSelected', g).length;

                if (linhas == 1) {

                    //Seleciona o Índice inteiro
                    var codClienteIndiceInteiro = $('.trSelected', g)[0].id;

                    //Seleciona apenas o número do Índice
                    var codClienteIndice = $('.trSelected', g)[0].id.substr(3);

                    //Seleciona os demais valores do grid
                    var codCliente = $('.trSelected', g).find('td').eq(1).text();
                    var cpf = $('.trSelected', g).find('td').eq(2).text();
                    var endereco = $('.trSelected', g).find('td').eq(4).text();

                    alert("Índice completo: " + codClienteIndiceInteiro +
                "\nNº Índice: " + codClienteIndice +
                "\nCódigo: " + codCliente +
                "\nCPF: " + cpf +
                "\nEndereço: " + endereco);
                }
                else if (linhas > 1)
                    alert('Você selecionou ' + linhas + 'linha(s)', 'ATENÇÃO');
                else
                    alert('Por favor, selecione uma linha para visualizar. Obrigado.', 'ATENÇÃO');

            }

        });
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <table id="flexigrid"></table>
        
    </div>

</asp:Content>
