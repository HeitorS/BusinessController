//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessController.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MTUSUARIO
    {
        public int ID_LOGIN { get; set; }
        public string EMAIL { get; set; }
        public string SENHA { get; set; }
        public string ATIVO { get; set; }
        public string PERFIL { get; set; }
        public string NOME { get; set; }
        public string SOBRENOME { get; set; }
        public Nullable<int> IDPESSOA { get; set; }
    
        public virtual MTPESSOA MTPESSOA { get; set; }
    }
}
