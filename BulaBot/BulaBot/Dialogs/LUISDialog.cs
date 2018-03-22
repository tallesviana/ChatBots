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
            await context.PostAsync($"Desculpa, mas não entendi o quê você quis dizer com {resultado.Query}");
           
        }

        [LuisIntent("Cumprimentos")]
        public async Task Cumprimentos(IDialogContext context, LuisResult resultado)
        {
            await context.PostAsync("Olá! \n\n\n\nTem dúvida sobre algum medicamento?");
          
        }

        [LuisIntent("Sobre")]
        public async Task Sobre(IDialogContext context, LuisResult resultado)
        {
            await context.PostAsync("Me chamo Medi. Sou um bot, e estou aqui para te ajudar com informações farmacêuticas! Tenha paciência" +
                " pois ainda estou aprendendo (:");
        
        }

        [LuisIntent("Indicacao")]
        public async Task Indicacao(IDialogContext context, LuisResult resultado)
        {
            await context.PostAsync($"Já estou encontrando para que serve o medicamento...");

            var result = await BuscarRemedio(context, resultado);

            if (result.Length == 0)
            {
                await context.PostAsync($"Não encontrei para que é indicado. Esse medicamento existe?");
                return;
            }

            var indication = result.Select(r => $"{r.Indicacao}");
            await context.PostAsync($"Aqui está! \n\n\n\n{string.Join(",", indication.ToArray())}");
        } 

        [LuisIntent("Posologia")]
        public async Task Posologia(IDialogContext context, LuisResult resultado)
        {
            await context.PostAsync($"Rapidinho, já estou procurando a posologia do remédio...");

            var result = await BuscarRemedio(context, resultado);

            if (result.Length == 0)
            {
                await context.PostAsync("Não encontrei a posologia dessa remédio doido. Digite novamente o nome do medicamento (:");
                return;
            }

            var posologia = result.Select(r => $"**{r.Nome}**\n\n{r.Posologia}");
            await context.PostAsync($"Encontrei! (: \n\n\n\n{string.Join(",", posologia.ToArray())}");
        }

        [LuisIntent("Efeitos")]
        public async Task Efeitos(IDialogContext context, LuisResult resultado)
        {
           
            await context.PostAsync($"Buscando os efeitos colaterais do medicamento...");

            var result = await BuscarRemedio(context, resultado);

            if (result.Length == 0)
            {
                await context.PostAsync("Olha, cho que esse medicamento não existe. Tente digitar novamente, por favor ;) ");
                return;
            }

            var efeito = result.Select(r => $"{r.Efeitos}");
            await context.PostAsync($"{string.Join(",", efeito.ToArray())}");

        }


        [LuisIntent("Preco")]
        public async Task Preco(IDialogContext context, LuisResult resultado)
        {
            
            var result = await BuscarRemedio(context, resultado);

            if (result.Length == 0)
            {
                await context.PostAsync($"Tem certeza que {resultado.Entities?.Select(e => e.Entity).ToArray()[0]} existe? Dífícil de encontrar. Tente outro medicamento (:");
                return;
            }

            var preco = result.Select(r => $"{r.Preco}");
            await context.PostAsync($"{string.Join(",", preco.ToArray())}");


        }

        private async Task<Models.Remedios[]> BuscarRemedio(IDialogContext context, LuisResult resultado)
        {
            var medicamento = resultado.Entities?.Select(e => e.Entity);

            if (medicamento.ToArray().Length == 0)
            {
                await context.PostAsync("Ocorreu algum erro. Tente novamente!");
                return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Remedios[]>("[]");
            }
            else
            {
                var endpoint = $"http://webapiremedios.azurewebsites.net/api/remedio/?nome={medicamento.ToArray()[0]}";

                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(endpoint);
                    if (!response.IsSuccessStatusCode)
                    {
                        await context.PostAsync("Ocorreu algum erro. Tente mais tarde (:");
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Remedios[]>("[]");
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
    
}