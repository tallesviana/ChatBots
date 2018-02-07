using System;
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
        public async Task Cumprimentos(IDialogContext context)
        {
            await context.PostAsync("Olá! Eu me chamo Dicine, e estou aqui para te ajudar. Tem dúvida sobre algum medicamento?");
        }

        [LuisIntent("Sobre")]
        public async Task Sobre(IDialogContext context)
        {
            await context.PostAsync("Me chamo Dicine. Sou bot powered com IA para te ajudar com informaçoes farmaceuticas! Tenha paciencia" +
                " pois ainda estou aprendendo (:");
        }

       
    }
}