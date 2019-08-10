using Modelo.Tabelas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Modelo.Cadastros
{
    public class Produto
    {
        [DisplayName("ID")]
        public long? ProdutoID { get; set; }

        [StringLength(50, ErrorMessage = "O nome precisa ter no mínimo 5 caracteres", MinimumLength = 10)]
        [Required(ErrorMessage = "Informe um nome válido de produto")]
        public string Nome { get; set; }

        [DisplayName("Data de Cadastro")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Você precisa informar a data de cadastro do produto")]
        public DateTime? DataCadastro { get; set; }

        [DisplayName("Categoria")]
        public long? CategoriaID { get; set; }

        [DisplayName("Fabricante")]
        public long? FabricanteID { get; set; }

        public Categoria Categoria { get; set; }
        public Fabricante Fabricante { get; set; }

    }
}