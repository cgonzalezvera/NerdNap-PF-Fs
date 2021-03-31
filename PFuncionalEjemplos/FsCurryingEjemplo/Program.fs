// Learn more about F# at http://fsharp.org

open System

type FormaGeometrica =        // define a "union" of alternative structures
    | Circulo of radio:int
    | Rectangulo of alto:int * ancho:int
    | Punto of x:int * y:int
    | Poligono of listaPuntos:(int * int) list

let dibujar forma =    // define a function "draw" with a shape param
  match forma with
  | Circulo radio ->
      printfn "Es un circulo con un radio de %d" radio
  | Rectangulo (alto,ancho) ->
      printfn "El rectangulo tiene una altura de %d por %d de ancho" alto ancho
  | Poligono puntos ->
      printfn "Este poligono esta compuesto de estos puntos %A" puntos
  | _ -> printfn "Forma geometrica desconocida"




[<EntryPoint>]
let main argv =

    let circulo = Circulo(10)
    let rectangulo = Rectangulo(4,5)
    let punto = Punto(2,3)
    let poligono = Poligono( [(1,1); (2,2); (3,3)])
    

    // definir funciones
    let RecorrerDibujar (dibujarFunc:FormaGeometrica->unit  ) formas  = List.iter dibujarFunc formas

    //currying
    let DescripcionTextual formas = formas |> List.iter dibujar

    // =============================

    // dibujar
    
    [circulo; rectangulo; poligono; punto] |> List.iter dibujar

    printfn "\n\r"
    printfn "Dibujar sin 'currying'"
    printfn "=====================\n\r"
    [circulo; rectangulo; poligono; punto] |> RecorrerDibujar dibujar

    printfn "\n\r"
    printfn "Dibujar USANDO 'currying'"
    printfn "=======================\n\r"
    [circulo; rectangulo; poligono; punto]  |> DescripcionTextual 

    
    0 // return an integer exit code
