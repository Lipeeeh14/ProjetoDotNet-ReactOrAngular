namespace ApiProdutos.Domain.Models
{
    public class Produto : BaseModel
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}
