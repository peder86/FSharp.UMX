module FSharp.UMX.Tests

open System
open Xunit
open FSharp.UMX

[<Measure>] type skuId
[<Measure>] type km
[<Measure>] type foo

type Record =
    {
        skuId : string<skuId>
        foo : string<foo>
        distance : int<km>
    }

// Tests intentionally without assertions

[<Fact>]
let ``Simple unit of measure conversions``() =
    let x = Guid.NewGuid() |> UMX.tag<skuId>
    let y = (UMX.untag x).ToString("N") |> UMX.tag<skuId>
    let z = UMX.tag<km> 42
    let w = sprintf "%O %s %d" (UMX.untag x) (UMX.untag y) z
    ()

[<Fact>]
let ``Simple unit of measure conversions with cast operator``() =
    let x : Guid<skuId> = % Guid.NewGuid()
    let y : string<skuId> = % (%x).ToString()
    let z : int<km> = % 42
    let w : string<foo> = % sprintf "%O %s %d" %x %y %z
    let b : byte<foo> = % 1uy
    let s : int16<foo> = % 1s
    ()

[<Fact>]
let ``Simplt unit of measure operators``() =
    let d1 : DateTime<foo> = % DateTime.Today
    let d2 : DateTime<foo> = % DateTime.Today
    let t0 : TimeSpan<foo> = %TimeSpan.Zero
    let t1 = d2 - d1
    let d2 = d1 + t1
    let d3 = t0 + t1
    let d4 = d1 - t0
    let o1 : DateTimeOffset<foo> = %DateTimeOffset.Now
    let o2 : DateTimeOffset<foo> = %DateTimeOffset.Now
    let t2 = o2 - o1
    let o3 = o1 + t2
    let o4 = d1 - t0
    let z : int<km> = % 42
    let z' = 42<km>
    let z'' = z - z'
    let z''' = z + z'
    let b0 : byte<foo> = %3uy
    let b1 : byte<foo> = %4uy
    let b3 = b0 - b1

    let s1 = %"hello"
    let s2 = %" umx"
    let s3 = s1 + s2

    let b1 : bool<foo> = %true
    let b2 : bool<foo> = %true
    let b3 : bool<foo> = %(%b1 && %b2)

    ()

[<Fact>]
let ``Simple unit of measure conversions with UMX.tag function``() =
    let x = UMX.tag<skuId> (Guid.NewGuid())              
    let y = UMX.tag<skuId> ((%x).ToString())             
    let z = UMX.tag<km> (42)                          
    let w = UMX.tag<foo> (sprintf "%O %s %d" %x %y %z) 
    let b = UMX.tag<foo> (1uy)                         
    let s = UMX.tag<foo> (1s)                         
    ()

[<Fact>]
let ``Record with units of measure``() =
    let record = { skuId = % "skuId" ; foo = % "foo" ; distance = % 42 }
    let x = sprintf "%s %s %d" %record.skuId %record.foo %record.distance
    ()
