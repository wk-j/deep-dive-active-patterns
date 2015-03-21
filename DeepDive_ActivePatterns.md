(Nearly) Everything You Ever Wanted to Know About Active Patterns (but were Afraid to Ask)
=====

Details   |
----------|---------------------------
When:     | January 9, 2015 12:15 PM
Speakers: | Paul Blasucci
Room:     | Salon H
Tags:     | .NET, Functional Programming
Category: | Regular Session (60 minutes)

-----

This presentation will provide a concise, but thorough, review of one of the more unique features of the F# language: active patterns. This feature allows one to extend the pattern-matching capabilities of the language. Active patterns may be put to great effect in taming unruly APIs, improving the declarative style of one’s code, constructing embedded DSLs, and much more. This talk will be given in a lecture format, interspersing digestible code samples with detailed breakdown of syntax. Additional consideration will be given, time permitting, to appropriate use-cases for active patterns and a discussion of the under-lying mechanics. The review is aimed at advanced beginners who are familiar with F#’s general syntax and usage. Also, while not strictly necessary, those wishing to follow along via computer are encouraged to have, at least, version 2.0 of the core F# tools. Information on obtaining the latest version of F# (for your platform of choice) may be found at: http://fsharp.org.

-----

### Disclaimer: ta'hell with the "about me". I'm not important -- but my ideas might be!

-----

### Disclaimer: if you're bothered by subjectivity, now's a great time to leave.

-----

1.  Hypothesis
    *   In so much as they expand the reach of pattern matching, _active patterns_ improve the readability of code.
2.  Background
    *   Pattern matching
        *   _From [MSDN](http://citation/needed.html):_ Patterns are rules for transforming input data. They are used throughout the F# language to compare data with a logical structure or structures, decompose data into constituent parts, or extract information from data in various ways.
        *   Compiler "knows" sixteen (16) patterns
            1.  Constant pattern
                *   Any numeric, character, or string literal, an enumeration constant, or a defined literal identifier
                *   `1.0`, `"test"`, `30`, `Color.Red`
            *   Null pattern
                *   null
                *   `null`
            *   Identifier pattern
                *   A case value of a discriminated union, an exception label, or an active pattern case
                *  ` Some(x)`,` Failure(msg)`
            *   Tuple pattern
                *   ( pattern_1, ... , pattern_n )
                *   `( a, b )`
            *   Record pattern
                *   { identifier1 = pattern_1; ... ; identifier_n = pattern_n }
                *   `{ Name = name; }`
            *   Cons pattern
                *   identifier :: list-identifier
                *   `h :: t`
            *   List pattern
                *   [ pattern_1; ... ; pattern_n ]
                *   `[ a; b; c ]`
            *   Array pattern
                *   [| pattern_1; ..; pattern_n ]
                *   `[| a; b; c |]`
            *   Variable pattern
                *   identifier
                *   `a`
            *   Pattern together with type annotation
                *   pattern : type
                *   `a : int`
            *   Type test pattern
                *   :? type [ as identifier ]
                *   `:? System.DateTime as dt`
            *   as pattern
                *   pattern as identifier
                *   `(a, b) as tuple1`
            *   OR pattern
                *   pattern1 | pattern2
                *   `([h] | [h; _])`
            *   AND pattern
                *   pattern1 & pattern2
                *   `(a, b) & (_, "test")`
            *   Parenthesized pattern
                *   ( pattern )
                *   `( a )`
            *   Wildcard pattern
                *   _
                *   `_`
        *   Limitations
            *   Compiler ONLY KNOWS a finite number of patterns
            *   Existing patterns not friendly with abstract data (typical of CLR langs)
    *   Active patterns
        *   _From [ICFP](http://citation/needed.html):_ An active pattern is a pattern defined without reference to a discriminated union type declaration. At a basic level an active pattern is just a regular function, but it is defined using a new syntactic element called a structured name which gives it special significance in the language.
        *   _From [ICFP](http://citation/needed.html):_ The ~~regular~~ structured name (more correctly, its constituent names) will also be added to the environment of patterns, enabling it to be used in patterns where it is in scope. Previously the only way of adding a new pattern was by defining a new union type.
        *   Make pattern matching extensible (dev makes the compiler smarter)
        *   Make analyses more expressive and declarative
        *   As always, it's (mostly) type safe
3.  Evidence
    *   Total patterns
        *   Have identity, can be checked for exhaustivity
        *   Single-case
            *   Provides alternate "view" of data
            *   `EX: ???`
        *   Multiple-case
            *   Partitions data into one of many "buckets"
            *   `EX: ???`
    *   Partial patterns
        *   No identity, not checked for exhaustivity
        *   Usefully as "application-focused (i.e. incomplete) view" of data
        *   `EX: ???`
    *   Parameterized patterns
        *   Improved the reuse and applicability of partial patterns
        *   `EX: ???`
    *   Higher-order patterns
        *   Active Patterns are just functions with special names
            *   Can be: composed, partially applied, treated as arguments
        *   `EX: ???`
    *   Nesting and combining
        *   Create more complex patterns
        *   Use `&` (dual to `|`) for combining
        *   `EX: ???`

-----

_(Optional) Mechanics_

Pattern                                  | Kind                | Type
---------------------------------------- | ------------------- | --------------------------
(&#124;A&#124;)                          | Single-case total   | 'T -> 'A
(&#124;A1&#124;...&#124;AN&#124;)        | Multi-case total    | 'T -> Choice<'A1, ...,'AN>
(&#124;A&#124;_&#124;)                   | Single-case partial | 'T -> 'A option

_Parameterized pattern => (as above table, but with more args)_

`TODO: desugared examples`

-----

### SLIDES
1.  Title & Speaker Info
*   Pattern Matching
    *   Definition
        *   Examples
    *   Limitations
*   Active Patterns
    *   Definition
    *   Total
        *   Single-case
            *   Examples
        *   Multiple-case
            *   Examples
    *   Partial
        *   Examples
    *   Parameterized
        *   Examples
    *   More Sophisticated Examples
        *   "Both" vs. "Either" patterns
        *   Nesting patterns
        *   Higher-order patterns
            *   Composition
            *   Partial application
            *   Patterns as input & output
*   Underlying mechanics (TIME PERMITTING)
*   Conclusion

-----

### Worked Examples
*   ???
    *   Pattern Matching Benefits
    *   Pattern Matching Limitations
*   Color-space conversion
    *   Single-case Total Patterns
    *   Multiple-case Total Patterns
*   ???
