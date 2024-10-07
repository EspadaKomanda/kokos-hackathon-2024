from peewee import AutoField

from Database.Models.baseModel import BaseModel


class Channel(BaseModel):

    id = AutoField(primary_key=True)
