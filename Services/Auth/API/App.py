from fastapi import FastAPI

from Application.Commands.CreateUser import CreateUserComandad
from Application.Handlers.CreateUser import CreateUserHandler
from Application.Handlers.GetUserById import GetUserByIdHandler
from Application.Handlers.GetUserByUserName import GetUserByUserNameHandler
from Application.Responses.UserDTO import PyObjectId, UserResponse
from Infrastructure.Repository.MongoDB import MongoDBRepository

repository = MongoDBRepository()

handler_get_id = GetUserByIdHandler(repository=repository)

handler_post = CreateUserHandler(repository=repository)

handler_get_user_name = GetUserByUserNameHandler(repository=repository)

app = FastAPI(
    title="Users API",
)


@app.get(path="/")
async def root() -> dict[str, str]:
    return {"message": "Hello World"}


@app.get(path="/users/{user_id}")
async def get_user_by_id(
    user_id: PyObjectId,
) -> UserResponse:
    return await handler_get_id.get_user_by_id(user_id=user_id)


@app.get(path="/users/{user_name}")
async def get_user_by_username(user_name: str) -> UserResponse:
    user: UserResponse = await handler_get_user_name.get_user_by_username(
        user_name=user_name
    )
    return user


@app.post(path="/users/")
async def post_user(create_user_command: CreateUserComandad):
    await handler_post.create_user(create_user=create_user_command)
