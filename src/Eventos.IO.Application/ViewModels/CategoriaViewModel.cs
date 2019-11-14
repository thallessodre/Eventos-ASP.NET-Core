using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Application.ViewModels
{
    public class CategoriaViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public SelectList Categorias()
        {
            return new SelectList(ListarCategorias(), "Id", "Nome");
        }

        public List<CategoriaViewModel> ListarCategorias()
        {
            var categoriasList = new List<CategoriaViewModel>()
            {
                new CategoriaViewModel() { Id = new Guid("2eb281cf-f6a0-42f7-8204-2764d1657aaa"), Nome = "Congresso"},
                new CategoriaViewModel() { Id = new Guid("60c7d6de-1f81-481c-becd-3dac6af0f882"), Nome = "Meetup"},
                new CategoriaViewModel() { Id = new Guid("a408ab8d-c4d0-4dba-8d11-7769ed50b316"), Nome = "Workshop"}
            };

            return categoriasList;
        }
    }
}
