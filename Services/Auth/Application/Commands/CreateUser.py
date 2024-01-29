from pydantic import BaseModel, ConfigDict, EmailStr, Field


class CreateUserComandad(BaseModel):
    user_name: str = Field(default=...)
    email: EmailStr = Field(default=...)
    pass_word: str = Field(default=...)

    model_config = ConfigDict(frozen=True)
