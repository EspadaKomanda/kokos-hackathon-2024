import logging

from config import TOKEN, ADMINS

from aiogram import Bot, Dispatcher
from aiogram.client.default import DefaultBotProperties
from aiogram.enums import ParseMode
from aiogram.filters import CommandStart, Command, CommandObject
from aiogram.types import Message

from Services.adminService import AdminService
from Services.channelService import ChannelService

logger = logging.getLogger(__name__)

adminService = AdminService()
channelService = ChannelService()

# All handlers should be attached to the Router (or Dispatcher)
dp = Dispatcher()

bot = Bot(
    token=TOKEN,
    default=DefaultBotProperties(parse_mode=ParseMode.HTML)
)


@dp.message(CommandStart())
@adminService.requiresAdmin
async def commandStartHandler(message: Message) -> None:
    """
    This handler receives messages with `/start` command
    """
    return channelService.status()


@dp.message(Command("channels"))
async def commandChannelsHandler(message: Message) -> None:
    """
    This handler receives messages with `/channels` command
    """
    if message.from_user.id not in ADMINS:
        return


async def botPolling() -> None:
    global bot
    await dp.start_polling(bot)
