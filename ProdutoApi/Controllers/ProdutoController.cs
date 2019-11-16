using Microsoft.AspNetCore.Mvc;
using ProdutoApi.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        IfirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "vOgqS4hgAKLjRnj2r6smSvAsF9qx2ANQbCU3Z4ss",
            BasePath ="https://aulaterca-a8be0.firebaseapp.com"

        };
        
        private FirebaseClient client;
        public ProdutoController()
        {
            client = new FirebaseClient(config);
        }

        [HttpGet("GetProdutos", Name = "GetProdutos")]
        public async Task<IActionResult> GetAllAsync()
        {
            var clientProduto = await client.GetAllAsync("Produto");
            var produtos = clientProduto.ResultAs<dynamic>();

            return Json(produtos);

        }
        //[HttpGet("GetProduto", Name = "GetProdutos")]
        [HttpGet("GetProdutoByid/{id}", Name = "GetProdutoById/(id)")]

        public async Task<IActionResult> GetById(long id)
        {
            var clientProduto = await client.GetAsync("Produto/" + id);
            var Produto = clientProduto.ResultAs<ProdutoEntidade>();
            
            return Json(produto);
        }

        [HttpDelete("{id}")] //deletar

        public async Task<IActionResult> Delete(long id)
        {
            var clientProduto await client.DeleteAsunc("Produto/" + id)
            var result = clientProduto.ResultAs<dynamic>();


            return Json("Deletado com sucesso!");
        }

        [HttpPut] //atualizar

        public async Task<IActionResult> Update([FromBody] ProdutoEntidade value)
        {
            var clientProduto = await client.UpdateAsync("Produto/" + valeu.Index, value);
            var result = clientProduto.ResultAs<ProdutoEntidade>();
            
            return Json("Atualizado com sucesso!");
        }

        [HttpPost] 

        public async Task<IActionResult> Post([FromBody] ProdutoEntidade value)
        {
            var clientProduto = await client.GetAsync("Produto");
            var result =clientProduto.ResultAs<dynamic>;

            if(result!= null)
            {F
                List<ProdutoEntidade> listProdutos = ConvertjsonToList<ProdutoEntidade>(result);
                var maxId = listProdutos?.Where(c => c != null)?.Max(c => c.Id);
                value.Id = maxId == null ? 1 : (int)maxId + 1;

            }
            else
                value.Id = 1;

                var response = await client.PushAsync("Produto/",value);
                var setresult = response.ResultAs<ProdutoEntidade>();


            return Json(setresult);
        }

        private List<ProdutoEntidade> ListarProdutos()
        {
            List<ProdutoEntidade> listMock = new List<ProdutoEntidade>();
            for (int i = 0; i < 6; i++)
            {
                ProdutoEntidade objProduto = new ProdutoEntidade();
                objProduto.Id = i;
                objProduto.Nome = "Produto " + i;
                listMock.Add(objProduto);
            }
            return listMock;
        }



    }
}