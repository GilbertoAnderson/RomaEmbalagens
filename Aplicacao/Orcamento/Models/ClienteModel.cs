using System.ComponentModel.DataAnnotations;

namespace Orcamento.Models
{
    public class ClienteModel
    {
        [Key]
        public int IdCliente { get; set; }

        public required string Nome { get; set; }    

        public string? Endereco { get; set; }

        public string? Bairro    { get; set; }

        public string? Cidade { get; set; }

        public string? UF { get; set; }

        public string? CEP { get; set; }

        public string? CNPJ { get; set; } 

        public string? Telefone { get; set; }

        public required int idStatus { get; set; }



    }
}
