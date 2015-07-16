using System.Linq;
using System.Collections.Generic;
namespace FlexgridComMVC.Models
{
    public class Cliente
    {
        public int CodCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public IQueryable<Cliente> Seleciona()
        {
            return (new List<Cliente>()
            {
                new Cliente{ CodCliente = 1, Nome = "Cliente 1", Cpf = "546.654.654-85", Telefone = "(11) 98787-8555", Endereco = "Rua do Teste, 123"},
                new Cliente{ CodCliente = 2, Nome = "Cliente 2", Telefone = "(90) 3787-3335", Endereco = "Rua do Teste 8qu342"},
                new Cliente{ CodCliente = 3, Nome = "Cliente 3", Telefone = "(22) 3000-7774", Endereco = "Rua do Teste 099078"},
                new Cliente{ CodCliente = 4, Nome = "Cliente 4", Telefone = "(55) 3888-9995", Endereco = "Rua do Teste 456546"},
                new Cliente{ CodCliente = 5, Nome = "Cliente 5", Endereco = "Rua do Teste 456546"},
                new Cliente{ CodCliente = 6, Nome = "Cliente 6", Endereco = "Rua do Teste 4566"},
                new Cliente{ CodCliente = 7, Nome = "Cliente 7", Cpf = "555.664.333-00", Telefone = "(14) 96666-8888", Endereco = "Rua do Teste 13"},
                new Cliente{ CodCliente = 8, Nome = "Cliente 8", Cpf = "999.600.650-54", Telefone = "(55) 98787-4444", Endereco = "Rua do Teste 55"},
                new Cliente{ CodCliente = 9, Nome = "Cliente 9", Cpf = "333.000.777-12", Telefone = "(87) 98787-1111"},
                new Cliente{ CodCliente = 10, Nome = "Cliente 10", Cpf = "776.654.654-11", Telefone = "(22) 98455-0000"},
            }).AsQueryable();
        }
    }
}