from datetime import datetime

from Application.Commands.UpateUser import UpateUserCommand
from Core.Entities.User import User
from Core.Repository.InterUsers import DataBaseRepository


class UpdateUserHandler:
    def __init__(self, repository: DataBaseRepository) -> None:
        self.repository: DataBaseRepository = repository


async def update_user(self, update_user: UpateUserCommand) -> bool:
    user_db_result = await self.repository.get_user_by_username(
        user_name=update_user.user_name
    )

    if user_db_result is not None:
        user_db_updated = User(
            user_name=update_user.user_name,
            email=update_user.email,
            created_at=user_db_result.created_at,
            updated_at=datetime.now(),
            hash_password=user_db_result.hash_password,
        )
        await self.repository.update_user(user=user_db_updated)
    else:
        pass
        # Handle user not found case
    return True
