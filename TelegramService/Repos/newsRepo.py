from Database.Models.news import News
from Repos.baseRepo import BaseRepo


class NewsRepo(BaseRepo):
    model = News

    def getByTgMessageId(self, tg_message_id):
        """Read a record by Telegram ID."""
        return self.model.select().where(self.model.tg_message_id == tg_message_id).get_or_none()
