from peewee import AutoField

from Database.Models.baseModel import BaseModel


class AttachmentSet(BaseModel):

    id = AutoField(primary_key=True)
