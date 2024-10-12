import logging

from aiogram.types import Chat

from Services.adminService import AdminService
from Repos.channelRepo import ChannelRepo

logger = logging.getLogger(__name__)


class ChannelService:
    def __init__(self):
        self.channelRepo = ChannelRepo()
        self.adminService = AdminService()

    def registerChannel(self, chat: Chat):
        """
        Register a new channel.
        """
        if self.channelRepo.getByChatId(chat.id) is not None:
            logger.info("Channel %s is already registered.", chat.id)
            return

        channel = self.channelRepo.create(
            chat_id=chat.id,
            name=chat.title,
            enable_sniff=False
        )

        await self.adminService.notifyAdmins(f"Added channel '{chat.title}' ({chat.id})")

    def getChannels(self):
        """
        See the list of registered channels and
        their status.
        """
        channels = self.channelRepo.getAll()

        message = "Channels:\n"
        for channel in channels:
            channel_status = f"✅ Enabled ({channel.sniff_delay} s)" if channel.enable_sniff else "❌ Disabled"
            message += f"{channel.chat_id} - {channel.name} - {channel_status}\n"

        return message

    def updateChannels():
        """
        Collect metadata for all channels.
        Can be used to track channel name updates.
        """
        raise NotImplementedError()
