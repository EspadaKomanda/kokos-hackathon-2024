import logging
from functools import wraps

from aiogram.types import Message

from config import ADMINS
from Repos.adminRepo import AdminRepo

from Exceptions.AdminService.UserIsNotAdminException import UserIsNotAdminException

logger = logging.getLogger(__name__)


class AdminService:
    def __init__(self):
        self.adminRepo = AdminRepo()

        # Initialize admins from config
        self.addAdminsFromArray(ADMINS)

    def addAdminsFromArray(self, tg_ids):
        """
        Add admins from array of Telegram IDs.
        """
        for tg_id in tg_ids:
            admin = self.adminRepo.getByTgId(tg_id)
            if admin is None:
                self.adminRepo.create(tg_user_id=tg_id)

    def resetAdmins(self):
        """
        Delete all admins and re-add them from config.
        """
        self.adminRepo.deleteAll()
        self.addAdminsFromArray(ADMINS)

    def isTgUserAdmin(self, tg_id):
        """
        Check if Telegram user is an admin.
        """
        admin = self.adminRepo.getByTgId(tg_id)
        return admin is not None

    def addAdmin(self, by_user_id=None, tg_id=None) -> bool:
        """
        Add an admin.
        """
        if tg_id is None:
            logger.exception("tg_id for new admin was not provided")
            return False

        if by_user_id is not None and not self.isTgUserAdmin(by_user_id):
            logger.info("User %s is missing privilege to add new admin.", by_user_id)
            return False

        self.adminRepo.create(tg_id=tg_id)

    def requiresAdmin(self, func):
        @wraps(func)
        async def wrapper(message: Message, *args, **kwargs):
            if not self.isTgUserAdmin(message.from_user.id):
                logger.info("User %s is missing privilege for %s", message.from_user.id, func.__name__)
                await message.reply("Only admins can do this action.")
                return
            return await func(message, *args, **kwargs)
        return wrapper
