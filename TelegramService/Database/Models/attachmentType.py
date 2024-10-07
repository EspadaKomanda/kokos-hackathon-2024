from peewee import AutoField, CharField

from Database.Models.baseModel import BaseModel


class AttachmentType(BaseModel):

    id = AutoField(primary_key=True)
    name = CharField(unique=True)
