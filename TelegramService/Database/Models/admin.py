from peewee import AutoField, BigIntegerField

from Database.Models.baseModel import BaseModel


class Admin(BaseModel):

    id = AutoField(primary_key=True)
    tg_user_id = BigIntegerField(unique=True)
