module MasterPage

open Fable.Helpers.React
open ApplicationStateModel

type MasterPageMsg = Increment | Decrement 

type MasterPageModel = { Counter : int }

let view model dispatch =
    div[] [ ]

let MasterPageInit (model: MainApplicationStateModel) =
    div[] [ ]
    