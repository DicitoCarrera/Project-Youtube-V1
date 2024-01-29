from pydantic import BaseModel, ConfigDict, EmailStr, Field


class UpateUserCommand(BaseModel):
    user_name: str = Field(default=...)
    email: EmailStr = Field(default=...)

    model_config = ConfigDict(frozen=True)
