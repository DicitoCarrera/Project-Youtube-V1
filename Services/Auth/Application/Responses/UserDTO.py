from typing import Annotated, Optional

from pydantic import BaseModel, BeforeValidator, ConfigDict, EmailStr, Field

# Represents an ObjectId field in the database.
# It will be represented as a `str` on the model so that it can be serialized to JSON.
PyObjectId = Annotated[str, BeforeValidator(func=str)]


class UserResponse(BaseModel):
    id: Optional[PyObjectId] = Field(alias="_id", default=None)
    user_name: str = Field(default=...)
    email: EmailStr = Field(default=...)
    model_config = ConfigDict(frozen=True)
