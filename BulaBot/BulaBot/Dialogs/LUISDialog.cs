using System;
using System.Linq;
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
            await context.PostAsync("Olá! Eu me chamo Medi, e estou aqui para te ajudar. Tem dúvida sobre algum medicamento?");
          
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
            var medicamentos = resultado.Entities?.Select(e => e.Entity);

            await context.PostAsync($"Desculpe, mas ainda nao sei as recomendacoes para: {string.Join(", ",medicamentos.ToArray())}.");
        } 

        [LuisIntent("Posologia")]
        public async Task Posologia(IDialogContext context, LuisResult resultado)
        {
            var medicamento = resultado.Entities?.Select(e => e.Entity);

            await context.PostAsync($"Desculpe, mas ainda nao sei como tomar: {string.Join(", ",medicamento.ToArray())}.");
        }

    }
}