#light
open System

let (|Float|) x = float(x)

let (Float(x)) = 7 // convert 7 in float and x become the new value

let [<LiteralAttribute>] name = "Riccardo"

module Helper =
    let Print(value) =
        printfn "%A" value

type Gender =
    | Male 
    | Female

type person = {Name:string; Gender:Gender }
let persons = [ {Name="Riccardo"; Gender=Male}; {Name="Bryony"; Gender=Female} ] 

persons |> List.map (fun p -> p.Gender ) |> List.map (function Male -> 1 | Female -> 0)

 let obs =
    { new IObservable<'a> with
        member this.Subscribe(observable) =
            //let doSomething = ()
            { new IDisposable with
                member this.Dispose() =
                    () }
                        }

//        member this.Next(value) =
//            ()
//
//        member this.Completed() =
//            ()
//
//        member this.Error(err) =
//            () }
                        
let plus ls =
    ls |> List.fold (+) 0             


let ev = Event<int>()

let ob = Observable.subscribe

ev.Publish
    |> Observable.filter(fun x -> x % 2 = 0)
    //|> Observable.add(fun x -> printfn "%d" x)
    |> Observable.subscribe(fun x -> printfn "ciao %d" x)


ob.Next(8)


ev.Trigger 4



module Observable =
    let sample (interval: TimeSpan) (obs: IObservable<'a>) =
        Observable.Sample(obs, interval)