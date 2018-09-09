module Client

open Elmish
open Elmish.React

open Fable.Helpers.React
open Elmish.Browser.Navigation

open Shared
open Fulma
open Fable.Import
open Elmish.Browser
open Elmish.Browser
open Elmish.Browser


#if DEBUG
open Elmish.Debug
open Elmish.HMR
open Elmish.Browser
open Elmish.ReactNative.Components


#endif

Program.mkProgram Bootstrapper.InitializeSoftware Bootstrapper.update Bootstrapper.View
#if DEBUG
|> Program.withConsoleTrace
|> Program.withHMR
#endif
|> Program.withReact "elmish-app"
#if DEBUG
|> Program.withDebugger
#endif
|> Program.run
