namespace FsAlgOrdenamiento

module Ordenamiento =
    let rec Rapido (items: int list)=
        match items with
        | [] -> []
        | primerItem::otrosItems->
            let menoresItems=
                otrosItems
                |> List.filter (fun e->e < primerItem)
                |> Rapido
            let mayoresItems=
                otrosItems
                |> List.filter (fun e-> e>=primerItem)
                |>Rapido
            List.concat [menoresItems;[primerItem];mayoresItems]

