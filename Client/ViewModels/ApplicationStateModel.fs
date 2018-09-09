module ApplicationStateModel

type MainApplicationStateModel = {
    IsAuth: bool
}

type MessegeToApplicationCore = | Auth | Logout
