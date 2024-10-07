from Database.Models.channel import Channel
from Repos.baseRepo import BaseRepo


class ChannelRepo(BaseRepo):
    model = Channel

    def getByChatId(self, chat_id):
        """Read a record by Chat ID."""
        return self.model.select().where(self.model.chat_id == chat_id).get_or_none()

    def deleteByChatId(self, chat_id):
        """Delete a record by Chat ID."""
        query = self.model.delete().where(self.model.chat_id == chat_id)
        query.execute()
