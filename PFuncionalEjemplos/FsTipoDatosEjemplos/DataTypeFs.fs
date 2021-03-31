module DataTypeFs
    //instancia ad-hoc de tupla
    let singleValue = true, System.DateTime.Now, "Error"

    //type Record (Sum Types)
    type Persona ={NombreCompleto:string; NroDoc:string;FechaNac:System.DateTime}
    
    type Usuario = {IdUsuario: int; Username: string;CtaCte: string;Balance:float; Persona:Persona}

    // type sum (discrimiated record)
    type UsuarioPlataforma =
        | ClienteRegular of Usuario
        | Productor of Cliente: Usuario * Asesorados: (Usuario list)

    

