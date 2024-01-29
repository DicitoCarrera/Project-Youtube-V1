from abc import ABC, abstractmethod
from typing import Optional

from Core.Entities.User import PyObjectId, User


class DataBaseRepository(ABC):
    @abstractmethod
    async def get_user(self, user_id: PyObjectId) -> Optional[User]:
        pass

    @abstractmethod
    async def get_user_by_username(self, user_name: str) -> Optional[User]:
        pass

    @abstractmethod
    async def create_user(self, user: User) -> bool:
        pass

    @abstractmethod
    async def update_user(self, user: User) -> bool:
        pass

    @abstractmethod
    async def delete_user(self, user_id: PyObjectId) -> bool:
        pass
