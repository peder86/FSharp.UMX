namespace FSharp.UMX

// Units of Measure extensions
// Provides a mechanism for extending units of measure to non-numeric primitives

#nowarn "42"

open System

[<MeasureAnnotatedAbbreviation>] type bool<[<Measure>] 'm> = bool
[<MeasureAnnotatedAbbreviation>] type byte<[<Measure>] 'm> = byte
[<MeasureAnnotatedAbbreviation>] type uint64<[<Measure>] 'm> = uint64
[<MeasureAnnotatedAbbreviation>] type Guid<[<Measure>] 'm> = Guid
[<MeasureAnnotatedAbbreviation>] type string<[<Measure>] 'm> = string
[<MeasureAnnotatedAbbreviation>] type TimeSpan<[<Measure>] 'm> = TimeSpan
[<MeasureAnnotatedAbbreviation>] type DateTime<[<Measure>] 'm> = DateTime
[<MeasureAnnotatedAbbreviation>] type DateTimeOffset<[<Measure>] 'm> = DateTimeOffset

module private Unsafe =
    let inline cast<'a, 'b> (a : 'a) : 'b =
#if !FABLE_COMPILER
        (# "" a : 'b #)
#else
        unbox<'b> a
#endif

type UMX =

    static member inline tag<[<Measure>]'m> (x : bool) : bool<'m> = Unsafe.cast x
    static member inline tag<[<Measure>]'m> (x : byte) : byte<'m> = Unsafe.cast x
    static member inline tag<[<Measure>]'m> (x : int) : int<'m> = Unsafe.cast x
    static member inline tag<[<Measure>]'m> (x : int16) : int16<'m> = Unsafe.cast x
    static member inline tag<[<Measure>]'m> (x : int64) : int64<'m> = Unsafe.cast x
    static member inline tag<[<Measure>]'m> (x : uint64) : uint64<'m> = Unsafe.cast x
    static member inline tag<[<Measure>]'m> (x : float) : float<'m> = Unsafe.cast x
    static member inline tag<[<Measure>]'m> (x : decimal) : decimal<'m> = Unsafe.cast x
    static member inline tag<[<Measure>]'m> (x : Guid) : Guid<'m> = Unsafe.cast x
    static member inline tag<[<Measure>]'m> (x : string) : string<'m> = Unsafe.cast x
    static member inline tag<[<Measure>]'m> (x : TimeSpan) : TimeSpan<'m> = Unsafe.cast x
    static member inline tag<[<Measure>]'m> (x : DateTime) : DateTime<'m> = Unsafe.cast x
    static member inline tag<[<Measure>]'m> (x : DateTimeOffset) : DateTimeOffset<'m> = Unsafe.cast x

    static member inline untag<[<Measure>]'m> (x : bool<'m>) : bool = Unsafe.cast x
    static member inline untag<[<Measure>]'m> (x : byte<'m>) : byte = Unsafe.cast x
    static member inline untag<[<Measure>]'m> (x : int<'m>) : int = Unsafe.cast x
    static member inline untag<[<Measure>]'m> (x : int16<'m>) : int16 = Unsafe.cast x
    static member inline untag<[<Measure>]'m> (x : int64<'m>) : int64 = Unsafe.cast x
    static member inline untag<[<Measure>]'m> (x : uint64<'m>) : uint64 = Unsafe.cast x
    static member inline untag<[<Measure>]'m> (x : float<'m>) : float = Unsafe.cast x
    static member inline untag<[<Measure>]'m> (x : decimal<'m>) : decimal = Unsafe.cast x
    static member inline untag<[<Measure>]'m> (x : Guid<'m>) : Guid = Unsafe.cast x
    static member inline untag<[<Measure>]'m> (x : string<'m>) : string = Unsafe.cast x
    static member inline untag<[<Measure>]'m> (x : TimeSpan<'m>) : TimeSpan = Unsafe.cast x
    static member inline untag<[<Measure>]'m> (x : DateTime<'m>) : DateTime = Unsafe.cast x
    static member inline untag<[<Measure>]'m> (x : DateTimeOffset<'m>) : DateTimeOffset = Unsafe.cast x

    static member inline cast<[<Measure>]'m1, [<Measure>]'m2> (x : bool<'m1>) : bool<'m2> = Unsafe.cast x
    static member inline cast<[<Measure>]'m1, [<Measure>]'m2> (x : byte<'m1>) : byte<'m2> = Unsafe.cast x
    static member inline cast<[<Measure>]'m1, [<Measure>]'m2> (x : int<'m1>) : int<'m2> = Unsafe.cast x
    static member inline cast<[<Measure>]'m1, [<Measure>]'m2> (x : int16<'m1>) : int16<'m2> = Unsafe.cast x
    static member inline cast<[<Measure>]'m1, [<Measure>]'m2> (x : int64<'m1>) : int64<'m2> = Unsafe.cast x
    static member inline cast<[<Measure>]'m1, [<Measure>]'m2> (x : uint64<'m1>) : uint64<'m2> = Unsafe.cast x
    static member inline cast<[<Measure>]'m1, [<Measure>]'m2> (x : float<'m1>) : float<'m2> = Unsafe.cast x
    static member inline cast<[<Measure>]'m1, [<Measure>]'m2> (x : decimal<'m1>) : decimal<'m2> = Unsafe.cast x
    static member inline cast<[<Measure>]'m1, [<Measure>]'m2> (x : Guid<'m1>) : Guid<'m2> = Unsafe.cast x
    static member inline cast<[<Measure>]'m1, [<Measure>]'m2> (x : string<'m1>) : string<'m2> = Unsafe.cast x
    static member inline cast<[<Measure>]'m1, [<Measure>]'m2> (x : TimeSpan<'m1>) : TimeSpan<'m2> = Unsafe.cast x
    static member inline cast<[<Measure>]'m1, [<Measure>]'m2> (x : DateTime<'m1>) : DateTime<'m2> = Unsafe.cast x
    static member inline cast<[<Measure>]'m1, [<Measure>]'m2> (x : DateTimeOffset<'m1>) : DateTimeOffset<'m2> = Unsafe.cast x

    static member inline add<[<Measure>]'m> (t1: byte<'m>, t2: byte<'m>) : byte<'m> = UMX.tag(UMX.untag t1 + UMX.untag t2)
    static member inline add<[<Measure>]'m> (t1: int<'m>, t2: int<'m>) : int<'m> = UMX.tag(UMX.untag t1 + UMX.untag t2)
    static member inline add<[<Measure>]'m> (t1: int16<'m>, t2: int16<'m>) : int16<'m> = UMX.tag(UMX.untag t1 + UMX.untag t2)
    static member inline add<[<Measure>]'m> (t1: int64<'m>, t2: int64<'m>) : int64<'m> = UMX.tag(UMX.untag t1 + UMX.untag t2)
    static member inline add<[<Measure>]'m> (t1: uint64<'m>, t2: uint64<'m>) : uint64<'m> = UMX.tag(UMX.untag t1 + UMX.untag t2)
    static member inline add<[<Measure>]'m> (t1: float<'m>, t2: float<'m>) : float<'m> = UMX.tag(UMX.untag t1 + UMX.untag t2)
    static member inline add<[<Measure>]'m> (t1: decimal<'m>, t2: decimal<'m>) : decimal<'m> = UMX.tag(UMX.untag t1 + UMX.untag t2)
    static member inline add<[<Measure>]'m> (t1: string<'m>, t2: string<'m>) : string<'m> = UMX.tag(UMX.untag t1 + UMX.untag t2)
    static member inline add<[<Measure>]'m> (t1: TimeSpan<'m>, t2: TimeSpan<'m>) : TimeSpan<'m> = UMX.tag(UMX.untag t1 + UMX.untag t2)
    static member inline add<[<Measure>]'m> (t1: DateTime<'m>, t2: TimeSpan<'m>) : DateTime<'m> = UMX.tag(UMX.untag t1 + UMX.untag t2)
    static member inline add<[<Measure>]'m> (t1: DateTimeOffset<'m>, t2: TimeSpan<'m>) : DateTimeOffset<'m> = UMX.tag(UMX.untag t1 + UMX.untag t2)

    static member inline subtract<[<Measure>]'m> (t1: byte<'m>, t2: byte<'m>) : byte<'m> = UMX.tag(UMX.untag t1 - UMX.untag t2)
    static member inline subtract<[<Measure>]'m> (t1: int<'m>, t2: int<'m>) : int<'m> = UMX.tag(UMX.untag t1 - UMX.untag t2)
    static member inline subtract<[<Measure>]'m> (t1: int16<'m>, t2: int16<'m>) : int16<'m> = UMX.tag(UMX.untag t1 - UMX.untag t2)
    static member inline subtract<[<Measure>]'m> (t1: int64<'m>, t2: int64<'m>) : int64<'m> = UMX.tag(UMX.untag t1 - UMX.untag t2)
    static member inline subtract<[<Measure>]'m> (t1: uint64<'m>, t2: uint64<'m>) : uint64<'m> = UMX.tag(UMX.untag t1 - UMX.untag t2)
    static member inline subtract<[<Measure>]'m> (t1: float<'m>, t2: float<'m>) : float<'m> = UMX.tag(UMX.untag t1 - UMX.untag t2)
    static member inline subtract<[<Measure>]'m> (t1: decimal<'m>, t2: decimal<'m>) : decimal<'m> = UMX.tag(UMX.untag t1 - UMX.untag t2)
    static member inline subtract<[<Measure>]'m> (t1: DateTime<'m>, t2: DateTime<'m>) : TimeSpan<'m> = UMX.tag(UMX.untag t1 - UMX.untag t2)
    static member inline subtract<[<Measure>]'m> (t1: DateTime<'m>, t2: TimeSpan<'m>) : DateTime<'m> = UMX.tag(UMX.untag t1 - UMX.untag t2)
    static member inline subtract<[<Measure>]'m> (t1: DateTimeOffset<'m>, t2: DateTimeOffset<'m>) : TimeSpan<'m> = UMX.tag(UMX.untag t1 - UMX.untag t2)
    static member inline subtract<[<Measure>]'m> (t1: DateTimeOffset<'m>, t2: TimeSpan<'m>) : DateTimeOffset<'m> = UMX.tag(UMX.untag t1 - UMX.untag t2)

[<AutoOpen>]
module Operators =

  let inline private _cast< ^TC, ^xm, ^xn when (^TC or ^xm or ^xn) : (static member cast : ^xm -> ^xn)> (x : ^xm) =
      ((^TC or ^xm or ^xn) : (static member cast : ^xm -> ^xn) x)

  let inline private _add< ^TC, ^xm, ^xn, ^xo when (^TC or ^xm or ^xn or ^xo) : (static member add : ^xm -> ^xn -> ^xo)>
      (x : ^xm) (y : ^xn) =
      ((^TC or ^xm or ^xn or ^xo) : (static member add : ^xm -> ^xn -> ^xo) (x, y))

  let inline private _subtract< ^TC, ^xm, ^xn, ^xo when (^TC or ^xm or ^xn or ^xo) : (static member subtract : ^xm -> ^xn -> ^xo)>
      (x : ^xm) (y : ^xn) =
      ((^TC or ^xm or ^xn or ^xo) : (static member subtract : ^xm -> ^xn -> ^xo) (x, y))

  // NB the particular infix operator shadows the rarely used quotation splicing operator
  /// Infix operator used for tagging, untagging, or casting units of measure
  let inline (~%) (x : ^xm) : ^xn = _cast<UMX, ^xm, ^xn> x

  /// Infix operator used for adding values with compatible units of measure
  let inline (+) (x : ^xm) (y : ^xn) : ^xo = _add<UMX, ^xm, ^xn, ^xo> x y

  /// Infix operator used for subtracting values with compatible units of measure
  let inline (-) (x : ^xm) (y : ^xn) : ^xo = _subtract<UMX, ^xm, ^xn, ^xo> x y
