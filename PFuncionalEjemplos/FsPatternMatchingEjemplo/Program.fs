// Learn more about F# at http://fsharp.org

open System
open DataTypeFs

[<EntryPoint>]
let main argv =

    // asignaciona de valores
    let persona1:Persona={NombreCompleto="Bernardo Villefort"; NroDoc="11444444"; FechaNac=new System.DateTime(1999,4,4)}

    let persona2={NombreCompleto="Jhon Gal"; NroDoc="3333"; FechaNac=new System.DateTime(1992,5,4)}

    let persona3={NombreCompleto="Edmundo Dantes"; NroDoc="27961247"; FechaNac=new System.DateTime(1980,10,4)}

    let usuario1 = {IdUsuario=11111; Username="dog10101"; CtaCte=""; Balance=0.0; Persona=persona1}
    let usuario2 = {IdUsuario=4411; Username="fish200"; CtaCte=""; Balance=0.0; Persona=persona2}

    let usuario3 = {IdUsuario=4411; Username="fish200"; CtaCte=""; Balance=0.0; Persona=persona3}

    let clienteRegular1 = ClienteRegular usuario1
    let clienteRegular2 = ClienteRegular usuario2
    let productor = Productor (usuario3, [usuario1; usuario2])

    // funciones
    let JoinClientes list = 
        let ifEmpty str =  if str=String.Empty then String.Empty else str + ","
        list
            |>List.map (fun (item:Usuario )-> item.Username)
            |> List.fold (fun acc item -> $"{(ifEmpty acc)}{item}") String.Empty

    let PresentarUsuario userP =
        match userP with
            | ClienteRegular c -> printfn "Soy un cliente regular, mi nombre es %s" c.Username
            | Productor (self, asesorados) -> printfn $"Soy productor, mi username es {self.Username}. Mis clientes son: {(JoinClientes asesorados)}"

    
    // presentacion de valores
    //List.iter (fun user -> PresentarUsuario user) [clienteRegular1; clienteRegular2; productor1]
    [clienteRegular1; clienteRegular2; productor] |> List.iter (fun user -> PresentarUsuario user) 
    
    0 
