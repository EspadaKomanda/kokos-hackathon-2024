from peewee import Model, PostgresqlDatabase


class BaseModel(Model):
    """
    Base model class.
    """
    @classmethod
    def __init__(cls, db: PostgresqlDatabase):
        cls.Meta.database = db

    class Meta:
        database = None
