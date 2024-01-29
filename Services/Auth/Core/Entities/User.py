from datetime import datetime

from pydantic import BaseModel, ConfigDict, EmailStr, Field


class User(BaseModel):
    user_name: str = Field(default=...)
    email: EmailStr = Field(default=...)
    hash_password: str = Field(default=...)
    created_at: datetime = Field(default=...)
    updated_at: datetime = Field(default=...)

    model_config = ConfigDict(frozen=True)
