class BaseRepo:

    """
    BaseRepo represting universal CRUD methods for any model.
    """
    # Guess what, Roma, mine isn't asynchronous either.
    model = None

    def create(self, **kwargs):
        """Create a new record."""
        return self.model.create(**kwargs)

    def getById(self, record_id):
        """Read a record by ID."""
        return self.model.get_by_id(record_id)

    def update(self, record_id, **kwargs):
        """Update a record by ID."""
        query = self.model.update(**kwargs).where(self.model.id == record_id)
        query.execute()

    def delete(self, record_id):
        """Delete a record by ID."""
        query = self.model.delete().where(self.model.id == record_id)
        query.execute()
