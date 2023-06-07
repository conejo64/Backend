using Newtonsoft.Json;

namespace Backend.Domain.DTOs.Responses;

public class DataManagerUsersResponse
{
    [JsonProperty(PropertyName = "Respuesta")]
    public ManagerUserResponse ManagerUserResponse { get; set; }

    [JsonProperty(PropertyName = "Resultado")]
    public ResultResponse ResultResponse { get; set; }
}

public class ManagerUserResponse
{
    [JsonProperty(PropertyName = "NumeroIdentificacion")]
    public string Identification { get; set; }

    [JsonProperty(PropertyName = "NombreCompleto")]
    public string FullName { get; set; }

    [JsonProperty(PropertyName = "PrimerApellido")]
    public string FirstSurname { get; set; }

    [JsonProperty(PropertyName = "SegundoApellido")]
    public string LastSurname { get; set; }

    [JsonProperty(PropertyName = "PrimerNombre")]
    public string FirstName { get; set; }

    [JsonProperty(PropertyName = "SegundoNombre")]
    public string LastName { get; set; }

    [JsonProperty(PropertyName = "EmailLaboral")]
    public string Email { get; set; }

    [JsonProperty(PropertyName = "DireccionMunicipal")]
    public string Address { get; set; }

    [JsonProperty(PropertyName = "DepartamentoMunicipal")]
    public string Department { get; set; }
}