from typing import Optional

from Application.Responses.UserDTO import UserResponse
from Core.Entities.User import User
from Core.Repository.InterUsers import DataBaseRepository


class GetUserByUserNameHandler:
    def __init__(self, repository: DataBaseRepository) -> None:
        self.repository: DataBaseRepository = repository

    async def get_user_by_username(self, user_name: str) -> UserResponse:
        user_db: Optional[User] = await self.repository.get_user_by_username(
            user_name=user_name
        )
        if user_db is None:
            raise Exception("User not found")

        return UserResponse(**user_db)
