from config import DATABASE

from peewee import PostgresqlDatabase


class Database:
    """
    Initializes database and safely creates required tables on connection.

    Returns the database object via the context manager protocol.
    """

    _db = None

    def __init__(self):

        self._db = PostgresqlDatabase(DATABASE)

    async def __aenter__(self) -> PostgresqlDatabase:
        self._db.connect()
        with self._db.atomic():
            self._db.create_tables([], safe=True)
        return self._db

    async def __aexit__(self, exc_type, exc_val, exc_tb):
        self._db.close()
