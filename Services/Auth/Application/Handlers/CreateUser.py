from datetime import datetime

from Application.Commands.CreateUser import CreateUserComandad
from Core.Entities.User import User
from Core.Repository.InterUsers import DataBaseRepository


class CreateUserHandler:
    def __init__(self, repository: DataBaseRepository) -> None:
        self.repository: DataBaseRepository = repository

    async def create_user(self, create_user: CreateUserComandad) -> bool:
        hash_password: str = create_user.pass_word

        user_db = User(
            user_name=create_user.user_name,
            email=create_user.email,
            hash_password=hash_password,
            created_at=datetime.now(),
            updated_at=datetime.now(),
        )
        await self.repository.create_user(user=user_db)

        return True
