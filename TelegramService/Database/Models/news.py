from peewee import AutoField, BigIntegerField, ForeignKeyField
from peewee import CharField, DateField, BooleanField

from Database.Models.baseModel import BaseModel
from Database.Models.attachmentSet import AttachmentSet
from Database.Models.channel import Channel


class News(BaseModel):

    id = AutoField(primary_key=True)
    channel_id = ForeignKeyField(Channel, field="id", index=True, backref="channel")  # TODO: verify backref
    tg_message_id = BigIntegerField()
    attachments = ForeignKeyField(AttachmentSet, field="id", index=True, backref="attachment_set", null=True)
    content = CharField(null=True)
    author_name = CharField(null=True)
    json_body = CharField(null=True)
    date = DateField()
    was_sent = BooleanField(default=False)

