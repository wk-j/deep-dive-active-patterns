# Pattern Matching

- [x] Map.TryFind
- [x] Data Decomposition

## Map.TryFind

```
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

## Single-case Total Patterns

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

- สามารถสร้าง Single-case pattern หลายอันแล้วทำการ Match cross กันได้

## Deep Dive Active Patterns

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

