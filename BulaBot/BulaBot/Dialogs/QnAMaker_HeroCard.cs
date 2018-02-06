using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BulaBot.Dialogs
{
    [Serializable]
    public class QnAMaker_HeroCard : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            await context.PostAsync("**Meu primeiro HeroCard**");

            var message = activity.CreateReply();

            if(activity.Text.Equals("dipirona", StringComparison.InvariantCultureIgnoreCase))
            {

                var attachment = CreateHeroCard();
                message.Attachments.Add(attachment);
            }
            else if(activity.Text.Equals("video", StringComparison.InvariantCultureIgnoreCase))
            {

                var attachment = CreateVideoCard();
                message.Attachments.Add(attachment);

            }
           else if(activity.Text.Equals("carousel", StringComparison.InvariantCultureIgnoreCase))
            {
                var video = CreateVideoCard();
                var card = CreateHeroCard();
                message.AttachmentLayout = AttachmentLayoutTypes.Carousel;

                message.Attachments.Add(video);
                message.Attachments.Add(card);
            }
               
            await context.PostAsync(message);

            context.Wait(MessageReceivedAsync);
        }

        private Attachment CreateHeroCard()
        {
            var herocard = new HeroCard();

            herocard.Title = "Dipirona Sódica";
            herocard.Subtitle = "Gripe e Febre";
            herocard.Images = new List<CardImage>
                {
                new CardImage("https://media.netfarma.com.br/produtos/dipirona-sodica-100-ml-solucao-oral_zoom.jpg","Dipirona")
                };

            return herocard.ToAttachment();
        }
        private Attachment CreateVideoCard()
        {
            var videocard = new VideoCard();

            videocard.Title = "A importancia do Dipirona";
            videocard.Subtitle = "(:";
            videocard.Autoloop = false;
            videocard.Autostart = true;
            videocard.Media = new List<MediaUrl>
                {
                    new MediaUrl("https://www.youtube.com/watch?v=JCAdbKa3t1w")
                };
            return videocard.ToAttachment();
        }
    }
}