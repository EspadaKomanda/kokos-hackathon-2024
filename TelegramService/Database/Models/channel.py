from peewee import AutoField, BigIntegerField, BooleanField, IntegerField
from peewee import Check

from Database.Models.baseModel import BaseModel


class Channel(BaseModel):

    id = AutoField(primary_key=True)
    chat_id = BigIntegerField(unique=True)
    enable_sniff = BooleanField(default=False)
    sniff_delay = IntegerField(default=60, constraints=[Check("sniff_delay > 9")])
