open System
open System.Reflection

let seqType  = typedefof<seq<_>>
let optType  = typedefof<option<_>>

let checkSeqOrOpt item =
  match item.GetType () with
  | t when t = seqType  -> printfn "Sequence // %s" t.FullName
  | t when t = optType  -> printfn "Option   // %s" t.FullName
  | t                   -> printfn "%A :<UNKNOWN>"  item

do checkSeqOrOpt 24
do checkSeqOrOpt [1 .. 100]
do checkSeqOrOpt "foobar"
do checkSeqOrOpt (1,"x",true) 
do checkSeqOrOpt (Some 333.333)

(* ________________________________________________________________________________ *)

let checkOptOrSeq item =
  let t = item.GetType ()
  // check for seq<_>
  if t.GetInterface seqType.FullName <> null then 
    printfn "Sequence // %s" t.FullName
  // check for option<_>
  elif t.IsGenericType 
    && t.GetGenericTypeDefinition() = optType   
    && not t.ContainsGenericParameters then 
    printfn "Option   // %s" t.FullName
  // "other"
  else printfn "%A :<UNKNOWN>" item

do checkOptOrSeq 24
do checkOptOrSeq [1 .. 100]
do checkOptOrSeq "foobar"
do checkOptOrSeq (1,"x",true) 
do checkOptOrSeq (Some 333.333)
