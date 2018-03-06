using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace BulaBot.Dialogs
{
    [Serializable]
    [LuisModel("d9aab061-1e8b-4704-8cf0-4ed059672984", "8df294bd8d1e4347ac3df5905ac0cec7")]
    public class LUISDialog : LuisDialog<object>
    {
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult resultado)
        {
            await context.PostAsync($"Desculpa, mas nao entendi o que voce quis dizer com {resultado.Query}");
           
        }

        [LuisIntent("Cumprimentos")]
        public async Task Cumprimentos(IDialogContext context, LuisResult resultado)
        {
            await context.PostAsync("Olá! \n\n\n\nTem dúvida sobre algum medicamento?");
          
        }

        [LuisIntent("Sobre")]
        public async Task Sobre(IDialogContext context, LuisResult resultado)
        {
            await context.PostAsync("Me chamo Medi. Sou um bot, e estou aqui para te ajudar com informaçoes farmaceuticas! Tenha paciencia" +
                " pois ainda estou aprendendo (:");
        
        }

        [LuisIntent("Indicacao")]
        public async Task Indicacao(IDialogContext context, LuisResult resultado)
        {
            var medicamento = resultado.Entities?.Select(e => e.Entity);

            var endpoint = $"http://webapiremedios.azurewebsites.net/api/remedio/?nome={medicamento.ToArray()[0]}";

            await context.PostAsync($"Já estou encontrando para que serve o remedio: {string.Join(", ", medicamento.ToArray()[0])}...");

            var result = await BuscarRemedio(context, endpoint);

            if (result == null)
            {
                return;
            }

            var indication = result.Select(r => $"{r.Indicacao}");
            await context.PostAsync($"Aqui está! \n\n\n\n{string.Join(",", indication.ToArray())}");
        } 

        [LuisIntent("Posologia")]
        public async Task Posologia(IDialogContext context, LuisResult resultado)
        {
            var medicamento = resultado.Entities?.Select(e => e.Entity);

            var endpoint = $"http://webapiremedios.azurewebsites.net/api/remedio/?nome={medicamento.ToArray()[0]}";

            await context.PostAsync($"Rapidinho, já estou procurando a posologia do remédio: {string.Join(", ", medicamento.ToArray()[0])}...");

            var result = await BuscarRemedio(context, endpoint);

            if (result == null)
            {
                return;
            }

            var posologia = result.Select(r => $"{r.Posologia}");
            await context.PostAsync($"Encontrei! (: \n\n\n\n{string.Join(",", posologia.ToArray())}");
        }

        [LuisIntent("Efeitos")]
        public async Task Efeitos(IDialogContext context, LuisResult resultado)
        {
            var medicamento = resultado.Entities?.Select(e => e.Entity);
            var endpoint = $"http://webapiremedios.azurewebsites.net/api/remedio/?nome={medicamento.ToArray()[0]}";

            await context.PostAsync($"Buscando os efeitos colaterais do(a): {string.Join(", ", medicamento.ToArray()[0])}...");

            var result = await BuscarRemedio(context, endpoint);

            if (result == null)
            {
                return;
            }

            var efeito = result.Select(r => $"{r.Efeitos}");
            await context.PostAsync($"{string.Join(",", efeito.ToArray())}");

        }


        [LuisIntent("Preco")]
        public async Task Preco(IDialogContext context, LuisResult resultado)
        {
            var medicamento = resultado.Entities?.Select(e => e.Entity);
            var endpoint = $"http://webapiremedios.azurewebsites.net/api/remedio/?nome={medicamento.ToArray()[0]}";

            var result = await BuscarRemedio(context, endpoint);

            if (result == null)
            {
                return;
            }
            
            var preco = result.Select(r => $"{r.Preco}");
            await context.PostAsync($"{string.Join(",", preco.ToArray())}");


        }

        private async Task<Models.Remedios[]> BuscarRemedio(IDialogContext context, string endpoint)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(endpoint);
                if (!response.IsSuccessStatusCode)
                {
                    await context.PostAsync("Ocorreu algum erro. Tente mais tarde (:");
                    return null;
                }
                else
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Remedios[]>(json);
                }
            }
        }
        
    }
    
}