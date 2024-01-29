from typing import Optional

from motor.motor_asyncio import AsyncIOMotorClient

from Core.Entities.User import PyObjectId, User
from Core.Repository.InterUsers import DataBaseRepository


class MongoDBRepository(DataBaseRepository):
    def __init__(self, uri="mongodb://admin:pass@mongodb:27017") -> None:
        client = AsyncIOMotorClient(uri)
        db = client.get_database(name="UsersDB")
        self.user_collection = db.get_collection(name="Users")

    async def get_user(self, user_id: PyObjectId) -> Optional[User]:
        user_doc = self.user_collection.find_one({"_id": user_id})
        return User(**user_doc) if user_doc else None

    async def get_user_by_username(self, user_name: str) -> Optional[User]:
        user_doc = self.user_collection.find_one({"user_name": user_name})
        return User(**user_doc) if user_doc else None

    async def create_user(self, user: User):
        result = self.user_collection.insert_one(document=user.model_dump())
        return result

    async def update_user(self, user: User) -> bool:
        update_result = self.user_collection.update_one(
            filter={"_id": user.id},  # Assuming 'id' is a field in 'User'
            update={"$set": user.model_dump()},
        )
        return update_result.modified_count > 0

    async def delete_user(self, user_id: PyObjectId) -> bool:
        delete_result = self.user_collection.delete_one(filter={"_id": user_id})
        return delete_result.deleted_count > 0
