import logging

from config import ADMINS
from config import bot

from aiogram import Dispatcher
from aiogram.filters import CommandStart, Command
from aiogram.filters import ChatMemberUpdatedFilter, IS_MEMBER, IS_NOT_MEMBER
from aiogram.types import Message, ChatMemberUpdated

from Services.adminService import AdminService
from Services.channelService import ChannelService

logger = logging.getLogger(__name__)

adminService = AdminService()
channelService = ChannelService()

dp = Dispatcher()


@dp.message(CommandStart())
@adminService.requiresAdmin
async def commandStartHandler(message: Message) -> None:
    """
    This handler receives messages with `/start` command
    """
    return channelService.status()


@dp.chat_member(ChatMemberUpdatedFilter(IS_NOT_MEMBER >> IS_MEMBER))
async def addedToChatHandler(event: ChatMemberUpdated) -> None:
    """
    Register the new channels when the bot is added
    """

    # Get the bot's user object
    me = await bot.me()

    # Ignore other users being added
    if event.new_chat_member.id != me.id:
        return

    performer = event.from_user

    # Leave chat if performer is not a bot admin
    if not adminService.isTgUserAdmin(tg_id=performer.id):
        await bot.leave_chat(event.chat.id)
        return

    # Get bot's chat permissions
    my_perms = await bot.get_chat_member(event.chat.id, me.id)

    # Leave if permissions ar insufficient
    if not my_perms.can_send_messages:
        await bot.leave_chat(event.chat.id)
        await adminService.notifyAdmins(f"Leaving channel '{event.chat.title}' due to insufficient permissions.")

    await channelService.registerChannel(event.chat)


@dp.message(Command("channels"))
@adminService.requiresAdmin
async def commandChannelsHandler(message: Message) -> None:
    """
    This handler receives messages with `/channels` command
    """
    if message.from_user.id not in ADMINS:
        return


async def botPolling() -> None:
    global bot
    await dp.start_polling(bot)
