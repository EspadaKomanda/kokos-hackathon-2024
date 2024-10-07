from Repos.baseRepo import BaseRepo
from Database.models.admin import Admin


class AdminRepo(BaseRepo):
    model = Admin

    def getByTgId(self, tg_id):
        """Read a record by Telegram ID."""
        return self.model.select().where(self.model.tg_id == tg_id).get_or_none()

    def deleteByTgId(self, tg_id):
        """Delete a record by Telegram ID."""
        query = self.model.delete().where(self.model.tg_id == tg_id)
        query.execute()
