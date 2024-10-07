from Repos.baseRepo import BaseRepo
from Database.Models.attachmentSet import AttachmentSet


class attachmentSetRepo(BaseRepo):
    model = AttachmentSet

    def getByNewsId(self, news_id):
        """Read a record by News ID."""
        return self.model.select().where(self.model.news_id == news_id).get_or_none()

    def deleteByNewsId(self, news_id):
        """Delete a record by News ID."""
        query = self.model.delete().where(self.model.news_id == news_id)
        query.execute()
