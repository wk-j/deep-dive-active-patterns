# Pattern Matching

- [x] Map.TryFind
- [x] Data Decomposition

## Map.TryFind

```fsharp
let rnd = Random DateTime.Now.Millisecond
let items = Map.ofSeq [ for n in  1  .. 26  do
                        for c in 'a' .. 'z' -> (n,c)]

let n = rnd.Next ()
match items.TryFind n with
| Some letter -> printfn "%i = %c" n letter
| None        -> printfn "key not found"
```

- TryFind ของ Map จะ return ค่าเป็น Option 't
- เมื่อใช้ `match items.TryFind n` จะได้ค่าที่เป็นไปได้สอบแบบ
    - `Some letter` คือหาค่าที่มี key `n` ใน Map เจอโดยค่านั้นคือ   `letter`
    - None ไม่เจอ key `n`

## Data Decomposition

```fsharp
for i in 1 .. 100 do
  match i % 3, i % 5 with
  | 0,0 -> printfn "FizzBuzz"
  | 0,_ -> printfn "Fizz"
  | _,0 -> printfn "Buzz"
  | _,_ -> printfn "%s" (string i)
```

- สามารถ match ค่ามากกว่า 1 pattern พร้อมกัน
- Match case ที่ได้จะถูก decompose เป็น tuple (ขั้นด้วยเครื่องหมาย `,`)

# Acitve Patterns

- [x] Single-case Total Patterns
- [ ] Multi-case Active Patterns
- [ ] Partial Patterns
- [ ] Parameterized Patterns
- [ ] First-class Patterns

## Single-case Active Patterns

```fsharp
let (|Rect|) (x :Complex) =
  Rect (x.Real,x.Imaginary)

let (|Polar|) (x :Complex) =
  Polar (x.Magnitude, x.Phase)

let add one two =
  match one,two with
  | Rect (r1,i1)
   ,Rect (r2,i2) -> Complex (r1 + r2,i1 + i2)

let mul one two =
  match one,two with
  | Polar (m1,p1)
   ,Polar (m2,p2) -> Complex (m1 + m2,p1 + p2)
```

- เป็น Active pattern ที่ case เดียว
- ประโยชน์คือใช้ transform input

```fsharp
let (|FileExtension|) filePath = Path.GetExtension(filePath)
let (|FileName|) filePath = Path.GetFileNameWithoutExtension(filePath)
let (|FileLocation|) filePath = Path.GetDirectoryName(filePath)
let determineFileType filePath =
    match filePath with
    | FileExtension ".jpg"
    | FileExtension ".png"
    | FileExtension ".gif"
    | FileName "logo"
    | FileLocation "c:\images"
        -> printfn "It is an image file"
    | FileName "readme"
        -> printfn "It is a Read Me file"
    | ext
        -> printfn "Unknown file type [%s]" filePath
```

- Single-case pattern หลายอันและสามารถ match cross กันได้

## Multi-case Acitve Patterns

```fsharp
let (|Fizz|Buzz|FizzBuzz|Num|) n =
  match n % 3, n % 5 with
  | 0,0 -> FizzBuzz
  | 0,_ -> Fizz
  | _,0 -> Buzz
  | _,_   -> Num n

for i in 1 .. 100 do
  match i with
  | FizzBuzz  -> printfn "FizzBuzz"
  | Fizz      -> printfn "Fizz"
  | Buzz      -> printfn "Buzz"
  | Num n     -> printfn "%s" (string n)
```

## Partial Active Patterns

```fsharp
let (|Fizz|_|) value =
  if value % 3 = 0 then Some () else None

let (|Buzz|_|) value =
  if value % 5 = 0 then Some () else None

for i in 1 .. 100 do
  match i with
  | Fizz & Buzz -> printfn "FizzBuzz"
  | Fizz        -> printfn "Fizz"
  | Buzz        -> printfn "Buzz"
  | n           -> printfn "%s" (string n)
```

## Parameterized Acitve Patterns

```fsharp
let (|Groups|_|) pattern value =
  let m = Regex.Match (value,pattern)
  match m.Success,m.Groups.Count with
  | true,n when n > 0 ->  [ for g in m.Groups -> g.Value ]
                          |> List.tail // drop "root" match
                          |> Some
  | _                 ->  None

match "37206" with
| Groups "(\d{5})([-]\d{4})?" [ zip; _ ] -> printfn "Postal code: %s" zip
| otherwise                              -> printfn "Can't ship to: %s" otherwise
```

## First-class Active Patterns

```fsharp
type Tree<'T> =
  | Leaf   of 'T
  | Branch of Tree<'T> * Tree<'T>

let (|Branch|_|) = function
  | Branch (l,r) -> Some (l,r)
  | _            -> None

let collect (|Pred|_|) root =
  let rec loop values node =
    match  node with
    | Pred (v,next) -> loop (v::values) next
    | _             -> List.rev values, root
  loop [] root

let (|Leaves|) root = collect (|Branch|_|) root

let tree = Branch (Branch (Branch (Leaf 2,Leaf 3),Leaf 7),Leaf 1)
match tree with
| Leaves (items,root) ->
    printfn "%A" root
    for item in items do
      printfn "%A" item
```

# Deep Dive Active Patterns

(Nearly) Everything you Ever Wanted to Know About Active Patterns (but Were Afraid to Ask)

Slides and scripts about using Active Patterns in F#.

So far, this talk has been given at:

* Code Mash 2015
* Philly Code Camp 2015.1
* Compose (NYC) 2016

## ไฟล์ต้นฉบับ

- โค้ดอยู่ใน `original`
- สไสลด์อยู่ใน `resource`

## Link

- http://www.devjoy.com/2014/08/active-patterns-single-case-total-pattern

