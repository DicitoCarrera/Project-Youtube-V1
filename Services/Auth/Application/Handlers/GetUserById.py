from typing import Optional

from Application.Responses.UserDTO import UserResponse
from Core.Entities.User import PyObjectId, User
from Core.Repository.InterUsers import DataBaseRepository


class GetUserByIdHandler:
    def __init__(self, repository: DataBaseRepository) -> None:
        self.repository: DataBaseRepository = repository

    async def get_user_by_id(self, user_id: PyObjectId) -> UserResponse:
        user_db: Optional[User] = await self.repository.get_user(user_id=user_id)
        if user_db is None:
            raise Exception(f"User with id {user_id} not found")
        return UserResponse(**user_db)
