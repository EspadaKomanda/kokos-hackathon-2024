from peewee import PostgresqlDatabase, Model

from config import DATABASE


class BaseModel(Model):
    """
    Base model class.
    """

    class Meta:
        database = PostgresqlDatabase(DATABASE)
