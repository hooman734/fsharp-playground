open System
open System.ComponentModel.DataAnnotations
open System.Text.RegularExpressions

let change (c : Char) =
        if Char.IsDigit(c) then
            String.init  (Int32.Parse(c.ToString())) (fun i -> "1")
            else c.ToString()
        
let reformat_numbers (str : String) : String =
    String.collect change str


    
  
    
let Validator (words_pool : String List) (str : String) : Boolean =
     let matched_items = Regex("^[a-z]*|(?<=[a-z])[A-Z][a-z]*").Matches(str)
     let seq_to_string_list = List.map (fun elem -> $"{elem}".ToLower()) (List.ofSeq matched_items)
     let lowered_words_pool = List.map (fun (elem : String) -> elem.ToLower()) words_pool
     List.fold (fun acc elem1 -> acc && (List.exists (fun elem2 -> elem2 = elem1) lowered_words_pool)) true seq_to_string_list




[<EntryPoint>]
let main argv =
    Validator ["Hello"; "Seyed"; "Hooman"; "Hesamyan"; "World"] "seyedHoomanHesamyan" |> printfn "%A"
  
    0 // return an integer exit code
