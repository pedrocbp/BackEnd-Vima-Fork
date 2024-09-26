using VimaV2.Models;
using VimaV2.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace VimaV2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Criação da WebApplication
            var builder = WebApplication.CreateBuilder(args);

            // Configuração do Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Configuração do Banco de Dados
            builder.Services.AddDbContext<VimaV2DbContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.Parse("8.0.37-mysql")));

            builder.Services.AddScoped<VimaV2DbContext>();

            // Add services to the container.
            builder.Services.AddControllers();

            // Configuração do CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAllOrigins"); // Adicione isso antes de UseAuthorization

            app.UseAuthorization();

            app.MapControllers();

            #region Users
            // Rotas de usuários
            app.MapGet("/usuarios", (VimaV2DbContext dbContext) =>
            {
                return Results.Ok(dbContext.Usuarios);
            });

            app.MapPost("/usuario", (VimaV2DbContext dbContext, User user) =>
            {
                dbContext.Usuarios.Add(user);
                dbContext.SaveChanges();
                return Results.Created($"/usuario/{user.Id}", user);
            });
            #endregion

            #region Contact
            // Rotas de contato
            app.MapGet("/contact", (VimaV2DbContext dbContext) =>
            {
                return Results.Ok(dbContext.Contatos);
            });

            app.MapPost("/contact/save", (Contato contato, VimaV2DbContext dbContext) =>
            {
                dbContext.Contatos.Add(contato);
                dbContext.SaveChanges();
                return Results.Created($"/contact/{contato.Id}", contato);
            });
            #endregion

            #region Produto
            // Rotas de produto
            app.MapGet("/produtos", async (VimaV2DbContext dbContext) =>
            {
                var produtos = await dbContext.Produtos.ToListAsync();
                return Results.Ok(produtos);
            });

            app.MapPost("/produto/criar", async (VimaV2DbContext dbContext, Produto produto) =>
            {
                dbContext.Produtos.Add(produto);
                await dbContext.SaveChangesAsync();
                return Results.Created($"/produto/{produto.Id}", produto);
            });

            app.MapGet("/produto/{id}", async (VimaV2DbContext dbContext, int id) =>
            {
                var produto = await dbContext.Produtos.FindAsync(id);
                if (produto == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(produto);
            });


            app.MapDelete("/produto/delete/{Id}", (VimaV2DbContext dbContext, int Id) =>
            {
                // Encontra o produto especificado buscando pelo Id enviado
                Produto? produtoEncontrado = dbContext.Produtos.Find(Id);
                if (produtoEncontrado is null)
                {
                    // Indica que o produto não foi encontrado
                    return Results.NotFound();
                }

                // Remove o produto encontrado da lista de produtos
                dbContext.Produtos.Remove(produtoEncontrado);

                dbContext.SaveChanges();

                return TypedResults.NoContent();
            });

            app.MapPut("produto/update/{Id}", (VimaV2DbContext dbContext, int Id, Produto produto) =>
            {
                // Encontra o produto especificado buscando pelo Id enviado
                Produto? produtoEncontrado = dbContext.Produtos.Find(Id);
                if (produtoEncontrado is null)
                {
                    // Indica que o produto não foi encontrado
                    return Results.NotFound();
                }

                // Mantém o Id do produto como o Id existente
                produto.Id = Id;

                // Atualiza a lista de produtos
                dbContext.Entry(produtoEncontrado).CurrentValues.SetValues(produto);

                // Salva as alterações no banco de dados
                dbContext.SaveChanges();

                return TypedResults.NoContent();
            });


            #endregion
            #region Carrinho
            app.MapPost("/carrinho/criar", async (VimaV2DbContext dbContext, Carrinho carrinho) =>
            {
                dbContext.Carrinhos.Add(carrinho);
                await dbContext.SaveChangesAsync();
                return Results.Created($"/carrinho/{carrinho.Id}", carrinho);
            });
            app.MapPut("carrinho/update/{Id}", (VimaV2DbContext dbContext, int Id, Carrinho carrinho) =>
            {
                // Encontra o produto especificado buscando pelo Id enviado
                Carrinho? carrinhoEncontrado = dbContext.Carrinhos.Find(Id);
                if (carrinhoEncontrado is null)
                {
                    // Indica que o produto não foi encontrado
                    return Results.NotFound();
                }

                // Mantém o Id do produto como o Id existente
              
                // Atualiza a lista de produtos
                dbContext.Entry(carrinhoEncontrado).CurrentValues.SetValues(carrinho);

                // Salva as alterações no banco de dados
                dbContext.SaveChanges();

                return TypedResults.NoContent();
            });

            app.MapDelete("/carrinho/delete/{Id}", (VimaV2DbContext dbContext, int Id) =>
            {
                // Encontra o produto especificado buscando pelo Id enviado
                Carrinho? carrinhoEncontrado = dbContext.Carrinhos.Find(Id);
                if (carrinhoEncontrado is null)
                {
                    // Indica que o produto não foi encontrado
                    return Results.NotFound();
                }

                // Remove o produto encontrado da lista de produtos
                dbContext.Carrinhos.Remove(carrinhoEncontrado);

                dbContext.SaveChanges();

                return TypedResults.NoContent();
            });

            app.MapGet("/carrinho/get", async (VimaV2DbContext dbContext) =>
            {
                var carrinho = await dbContext.Carrinhos.ToListAsync();
                return Results.Ok(carrinho);
            });
            #endregion
            // Execução da aplicação
            app.Run();
        }
    }
}
