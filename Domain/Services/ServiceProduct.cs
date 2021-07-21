using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceProduct : IServiceProduct
    {

        private readonly IProduct _IProduct;

        public ServiceProduct(IProduct IProduct)
        {
            _IProduct = IProduct;
        }

        public async Task AddProduct(Produto produto)
        {
            var ValidaNome = produto.ValidaPropriedadeString(produto.Nome, "Nome");
            var ValidaValor = produto.ValidaPropriedadeDecimal(produto.Valor, "Valor");
            var ValidaQuantidadeEstoque = produto.ValidaPropriedadeInt(produto.QuantidadeEstoque, "QuantidadeEstoque");

            if (ValidaNome && ValidaValor && ValidaQuantidadeEstoque)
            {
                produto.DataCadastro = DateTime.Now;
                produto.DataAlteracao = DateTime.Now;
                produto.Estado = true;
                await _IProduct.Add(produto);
            }
        }

        public async Task UpdateProduct(Produto produto)
        {
            var ValidaNome = produto.ValidaPropriedadeString(produto.Nome, "Nome");
            var ValidaValor = produto.ValidaPropriedadeDecimal(produto.Valor, "Valor");
            var ValidaQuantidadeEstoque = produto.ValidaPropriedadeInt(produto.QuantidadeEstoque, "QuantidadeEstoque");

            if (ValidaNome && ValidaValor && ValidaQuantidadeEstoque)
            {
                produto.DataAlteracao = DateTime.Now;
                await _IProduct.Update(produto);
            }
        }
    }
}
