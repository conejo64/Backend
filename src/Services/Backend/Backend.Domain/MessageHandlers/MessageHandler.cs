namespace Backend.Domain.MessageHandlers;

public static class MessageHandler
{
    // Errors
    public const string AuthenticationError = "Usuario y/o contraseña incorrectos";
    public const string PasswordNotEquals = "La contraseña actual no coincide";


    public const string UserAlreadyRegistered = "No se puede registrar el usuario con la información suministrada";
    public const string GenericError = "Se ha producido un error. Por favor contacte al Administrador";
    public const string UserNotFound = "No se encuentra el usuario";
    public const string ProfileNotFound = "No se encuentra perfil";
    public const string PermissionNotFound = "No existen permisos en el sistema";
    public const string UserFound = "El usuario se encuentra registrado";
    public const string EmailFound = "El correo se encuentra registrado";
    public const string EmailNotFound = "Correo electrónico no se encuentra registrado";

    public const string ErrorEmailFormat = "No es una dirección válida de correo electrónico";


    //Data Users
    public const string DataUserGenerateTokenError = "Error generando token";


    public const string ProfileAlreadyExit = "No se puede registrar el perfil con la información suministrada";

    // User Manager
    public const string ManagerUsernameNotEmpty = "Campo Usuario es obligatorio";
    public const string ManagerFirstnameNotEmpty = "Campo Nombres es obligatorio";

    // User Member
    public const string MemberUsernameNotEmpty = "Campo Usuario es obligatorio";
    public const string MemberIdentificationTypeInvalid = "Campo Tipo de identificación es incorrecto";

    // Catalogs
    public const string OriginDocumentNotFound = "Origen de documento no encontrado";
    public const string BrandNotFound = "Marca no encontrada";
    public const string CaseNotFound = "Caso no encontrado";

}