using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.DTOs.Responses;

public class DataMemberUsersResponse
{
    [JsonProperty(PropertyName = "Respuesta")]
    public MemberUserResponse MemberUserResponse { get; set; }

    [JsonProperty(PropertyName = "Resultado")]
    public ResultResponse ResultResponse { get; set; }
}

public class MemberUserResponse
{
    [JsonProperty(PropertyName = "Identificacion")]
    public string Identification { get; set; }

    [JsonProperty(PropertyName = "Nombre")]
    public string Name { get; set; }

    [JsonProperty(PropertyName = "Sexo")] public string Sex { get; set; }

    [JsonProperty(PropertyName = "EstadoCivil")]
    public string CivilStatus { get; set; }

    [JsonProperty(PropertyName = "Email")] public string Email { get; set; }

    [JsonProperty(PropertyName = "Celular")]
    public object Mobile { get; set; }
}

public class ResultResponse
{
    [JsonProperty(PropertyName = "Respuesta")]
    public bool Respuesta { get; set; }

    [JsonProperty(PropertyName = "Titulo")]
    public string Titulo { get; set; }

    [JsonProperty(PropertyName = "TipoMensaje")]
    public int TipoMensaje { get; set; }

    [JsonProperty(PropertyName = "Mensajes")]
    public object[] Mensajes { get; set; }

    [JsonProperty(PropertyName = "TotalRowsCount")]
    public int TotalRowsCount { get; set; }
}