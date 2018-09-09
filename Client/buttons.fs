module MyCustomButtons

open Fulma
open Fable.Helpers.React

type Condition = bool

let ExecuteButton (isEmpty:bool) (lbl:string) onClick =
        Button.button  [
            Button.CustomClass (if isEmpty then "my_class" else "")
            Button.OnClick onClick
        ] [str lbl]
            

        
