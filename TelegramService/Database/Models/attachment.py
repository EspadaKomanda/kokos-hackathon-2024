from peewee import AutoField, BigIntegerField, ForeignKeyField
from peewee import IntegerField, CharField

from Database.Models.baseModel import BaseModel
from Database.Models.attachmentSet import AttachmentSet
from Database.Models.attachmentType import AttachmentType


class Attachment(BaseModel):

    id = AutoField(primary_key=True)
    attachment_set_id = ForeignKeyField(AttachmentSet, field="id", index=True, backref="attachment_set")
    attachment_type_id = ForeignKeyField(AttachmentType, field="id", index=True, backref="attachment_type")
    file_id = BigIntegerField(unique=True)
    file_size = IntegerField()
    s3_link = CharField(null=True)

    class Meta:
        indexes = (
            (("attachment_set_id", "attachment_type_id"), True),  # unique
        )
