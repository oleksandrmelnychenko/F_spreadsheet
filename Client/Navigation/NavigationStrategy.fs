module NavigationStrategy

open Elmish.Browser.UrlParser
open Elmish.Browser.Navigation
open Fable.Helpers.React
open Fable.Core
open Fable.Import
open Elmish

type Page = Home
//| Blog of int | Search of string

type Model =
  { page : Page
    query : string
    cache : Map<string,string list> }

//let pageParser : Parser<Page->_,_> =
//    oneOf
//        [
//        //map Home (s "home")
//          //map Blog (s "blog" </> i32)
//          //map Search (s "search" </> str)
//        ]

let toHash = 
    function
    //| Blog id -> "#blog/" + (string id)
    //| Search query -> "#search/" + query
    | _ -> "#home"

let urlUpdate result model =
      match result with
      | Some page ->
          { model with page = page; query = "" }, []
          model, Navigation.newUrl "some_other_location"
      | None ->
          Browser.console.error("Error parsing url")  
          ( model, Navigation.modifyUrl (toHash model.page) )