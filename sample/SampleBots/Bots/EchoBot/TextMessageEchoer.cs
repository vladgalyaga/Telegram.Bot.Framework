﻿using System.Threading.Tasks;
using Telegram.Bot.Framework;
using Telegram.Bot.Framework.Abstractions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace SampleBots.Bots.EchoBot
{
    public class TextMessageEchoer : UpdateHandlerBase
    {
        public override bool CanHandleUpdate(IBot bot, Update update)
        {
            return !string.IsNullOrEmpty(update.Message?.Text);
        }

        public override async Task<UpdateHandlingResult> HandleUpdateAsync(IBot bot, Update update)
        {
            string replyText = $"You said:\n`{update.Message.Text.Replace("\n", "`\n`")}`";

            await bot.Client.SendTextMessageAsync(
                update.Message.Chat.Id,
                replyText,
                ParseMode.Markdown,
                replyToMessageId: update.Message.MessageId);

            return UpdateHandlingResult.Continue;
        }
    }
}
