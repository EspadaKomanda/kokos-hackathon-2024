from sys import exit
from os import getenv
from dotenv import load_dotenv

from aiogram import Bot
from aiogram.enums import ParseMode
from aiogram.client.default import DefaultBotProperties

load_dotenv(override=False)

"""
Configuration file for the bot.

Utilizes environment variables and makes them accessible
everywhere else.

Do not modify this file, configure variables in your
environment instead.
"""

# SYSTEM AND ADMINISTRATION

# BOT_TOKEN - Your Telegram bot token (Avaiable from @BotFather)
#    (Example: 1234567890:ABCDefghijk)
TOKEN = getenv("BOT_TOKEN") or exit("BOT_TOKEN not found in environment!")

# DATABASE - Your database connection string.
#    (Example: "postgresql://[user[:password]@][netloc][:port][/dbname][?param1=value1&...]")
DATABASE = getenv("DATABASE") or exit("DATABASE not found in environment!")

# ADMINS - List of admin Telegram IDs with complete access.
#    (Example: 1234567890,1234567891,1234567892)
ADMINS = [int(admin_id) for admin_id in list((getenv("ADMINS") or "").split(","))]

# CUSTOMIZATION

# TIMEZONE - Your timezone.
#    (Default: Europe/Moscow)
TIMEZONE = getenv("TIMEZONE") or "Europe/Moscow"

# BOT

bot = Bot(
    token=TOKEN,
    default=DefaultBotProperties(parse_mode=ParseMode.HTML)
)
