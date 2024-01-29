from Core.Entities.User import PyObjectId
from Core.Repository.InterUsers import DataBaseRepository


class UpdateUserHandler:
    def __init__(self, repository: DataBaseRepository) -> None:
        self.repository: DataBaseRepository = repository

    async def update_user(self, user_id: PyObjectId) -> bool:
        await self.repository.delete_user(user_id=user_id)
        return True
