module Bootstrapper

open ApplicationStateModel
open Elmish
open Fulma
open Fable.Helpers.React
open Elmish.Debug
open Fable.Import
open Fable.PowerPack.Keyboard
open Fulma
open Fable.Import
open Microsoft.FSharp.Core
open Fable.Import
open Fulma
open Fable.Import
open Fable.Import

open Fable.Core.JsInterop
open Fable.Helpers.React.Props
open Fable.PowerPack.Keyboard
open Fable.Import
open Fable.Core

module R = Fable.Helpers.React

[<Emit("debugger;")>]
let debugger () : unit = jsNative

type Position = char * int

type Event = | StartEdit of Position
             | UpdatedValue of Position * string

type State =
            {
                Cols: char list
                Rows: int list
                Active: Position option
                Cells : Map<Position,string>
            }

let init =
    {
        Rows = [1..15]
        Cols = ['A'..'K']
        Active = None
        Cells = Map.empty
    }

let InitializeSoftware () : State * Cmd<Event> =
    init,Cmd.none

let update (event:Event) (state:State) : State * Cmd<Event> =
    match event with
    | StartEdit(pos) ->
        match state.Active with
        | Some(pos)-> { state with Active = None },Cmd.none
        | None _   -> { state with Active = Some pos },Cmd.none
    | UpdatedValue(pos,value) -> { state with Cells = Map.add pos value state.Cells },Cmd.none
       

let renderView dispatch pos value =
    td[
       OnClick (fun _-> dispatch(StartEdit(pos)))
    ][
        str value
    ]

let renderEditor dispatch pos value =
    td [][
      Input.text [ Input.Placeholder "Ex: Who created F#?"
                   Input.Value value
                   Input.Props [ OnChange (fun ev -> UpdatedValue(pos, unbox !!ev?target?value) |> dispatch ) ] ] 
     ]
     
let renderCell dispatch pos state =
    let value = Map.tryFind pos state.Cells
    
    if state.Active = Some pos then
        renderEditor dispatch pos (defaultArg value "")
    else
        renderView dispatch pos (defaultArg value "")


let View state dispatch =
        Table.table[ Table.IsFullWidth ][
            yield tr[][
                yield th[][]
                for col in state.Cols -> th[][ str (string col)]
            ]
            for row in state.Rows -> tr[][
                yield th[][str (string row)]
                for col in state.Cols -> renderCell dispatch (col,row) state
            ]
        ]
