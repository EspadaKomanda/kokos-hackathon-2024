import logging

from config import TOKEN

from aiogram import Bot, Dispatcher, html
from aiogram.client.default import DefaultBotProperties
from aiogram.enums import ParseMode
from aiogram.filters import CommandStart
from aiogram.types import Message

logger = logging.getLogger(__name__)

# All handlers should be attached to the Router (or Dispatcher)
dp = Dispatcher()

bot = Bot(
    token=TOKEN,
    default=DefaultBotProperties(parse_mode=ParseMode.HTML)
)


@dp.message(CommandStart())
async def commandStartHandler(message: Message) -> None:
    """
    This handler receives messages with `/start` command
    """
    await message.answer(f"Hello, {html.bold(message.from_user.full_name)}!")


async def botPolling() -> None:
    global bot

    # And the run events dispatching
    await dp.start_polling(bot)
