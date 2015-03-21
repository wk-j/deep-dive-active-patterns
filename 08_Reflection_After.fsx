open System
open System.Reflection

let (|Concrete|_|) (target:Type) (test:Type) = 
  match target.IsGenericTypeDefinition 
     && test.IsGenericType
     && not test.ContainsGenericParameters
     && test.GetGenericTypeDefinition() = target with
  | false -> None
  | true  -> Some test

let (|Interface|_|) (target:Type) (test:Type) = 
  if test.IsInterface
    then  match test with 
          | Concrete target iface -> Some iface
          | _                     -> None
    else  match test.GetInterface(target.FullName) with
          | null  -> None
          | iface -> Some iface
  
let (|IsOption|_|) t = (|Concrete|_|)  (typedefof<Option<_>>) t  
let (|IsSeq|_|)    t = (|Interface|_|) (typedefof<seq<_>>) t

let checkType item =
  match item.GetType() with
  | IsSeq     t -> printfn "Sequence // %s" t.FullName
  | IsOption  t -> printfn "Option   // %s" t.FullName
  | _           -> printfn "%A :<UNKNOWN>" item

do checkType 24
do checkType [1 .. 100]
do checkType "foobar"
do checkType (1,"x",true) 
do checkType (Some 333.333)
