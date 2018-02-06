using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using Microsoft.Bot.Builder.Dialogs;
using QnAMakerDialog;

namespace BulaBot.Dialogs
{
    [Serializable]
    //[QnAMaker("2534312576ca45ca8c90133186443165", "24963aa4-3043-41d3-b582-3f06f2d5db83","Desculpa, nao entendi.", 0.5,3)]
    //public class QnaBotwithActivedLearning : Qna
    [QnAMakerService("2534312576ca45ca8c90133186443165", "24963aa4-3043-41d3-b582-3f06f2d5db83")]
    public class QnASimpleDialog : QnAMakerDialog<object>
    {
        public override async Task NoMatchHandler(IDialogContext context, string original)
        {
            await context.PostAsync($"Desculpe, mas nao entendi o que voce quis dizer com: '{original}'.");
            context.Wait(MessageReceived);
        }

       
    }
}