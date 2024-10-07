from Database.Models.attachment import Attachment
from Repos.baseRepo import BaseRepo


class AttachmentRepo(BaseRepo):
    model = Attachment

    def getByFileId(self, file_id):
        """Read a record by File ID."""
        return self.model.select().where(self.model.file_id == file_id).get_or_none()

    def getByS3Link(self, s3_link):
        """Read a record by S3 Link."""
        return self.model.select().where(self.model.s3_link == s3_link).get_or_none()

    def getAllFromSet(self, attachment_set_id):
        """Read all records from a set."""
        return self.model.select().where(self.model.attachment_set_id == attachment_set_id)
